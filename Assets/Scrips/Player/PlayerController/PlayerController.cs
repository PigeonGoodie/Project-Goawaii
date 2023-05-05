using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _turnSpeed = 360;
    [SerializeField] private float _dashDistance = 1;
    [SerializeField] private float _dashSpeed = 1;

    [SerializeField] private LayerMask _wallMask;

    private Rigidbody _rb;

    private bool _doDash;

    public Transform _dashSparkle;
    private ParticleSystem.EmissionModule _dashSparkleParticles;

    private Vector3 _dashPos;

    private Vector3 _input;

    public int maxHp = 4;
    private int hp;
    private PlayerHealth _healthUIManager;

    // public Animator animator;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _healthUIManager = GetComponent<PlayerHealth>();
        hp = maxHp;
        _healthUIManager.UpdateHealth(hp);

        _dashSparkleParticles = _dashSparkle.GetComponent<ParticleSystem>().emission;
        _dashSparkleParticles.enabled = false;
        //   animator = GetComponent<Animator>();
    }

    private void Update()
    {
        GatherInput();
        Look();
        Dash();

        if (Input.GetKeyDown(KeyCode.F))
            TakeDamage(1);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void GatherInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    private void Look()
    {
        if (_input == Vector3.zero) return;

        var rot = Quaternion.LookRotation(_input.ToIso(), Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnSpeed * Time.deltaTime);
    }

    private void Move()
    {
        _rb.MovePosition(transform.position + _input.normalized.magnitude * _speed * Time.deltaTime * transform.forward);

    }

    private void Dash()
    {
        if (Input.GetKeyDown("space"))
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, _dashDistance, _wallMask))
                _dashPos = hit.point;
            else
                _dashPos = transform.position + transform.forward * _dashDistance;
            _doDash = true;
            StartCoroutine(DoSparkle());
            Debug.Log("dash");
        }

        if (_doDash)
        {
            transform.position = Vector3.MoveTowards(transform.position, _dashPos, _dashSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, _dashPos) < 0.001f)
                _doDash = false;
        }
    }

    public void TakeDamage(int dmg)
    {
        hp -= dmg;
        if (hp <= 0)
            Debug.Log("Ded");

        _healthUIManager.UpdateHealth(hp);
    }

    IEnumerator DoSparkle()
    {
        _dashSparkleParticles.enabled = true;
        yield return new WaitForSeconds(.1f);
        _dashSparkleParticles.enabled = false;
    }
}

public static class Helpers
{
    private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
    public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);
}
