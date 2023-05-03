using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _turnSpeed = 360;
    [SerializeField] private float _dashDistance = 1;
    [SerializeField] private float _dashSpeed = 1;

    [SerializeField] private LayerMask _wallMask;

    private bool _doDash;

    public float maxMana;
    public float mana;

    public Transform _dashSparkle;
    private ParticleSystem.EmissionModule _dashSparkleParticles;

    private Vector3 _dashPos;

    private Vector3 _input;

    // public Animator animator;
    private void Start()
    {
        // J: Saved particle object to avoid multiple GetComponent calls and remove warnings
        _dashSparkleParticles = _dashSparkle.GetComponent<ParticleSystem>().emission;
        _dashSparkleParticles.enabled = false;
        //   animator = GetComponent<Animator>();
    }

    private void Update()
    {
        GatherInput();
        Look();
        Dash();

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
        _rb.MovePosition(transform.position + transform.forward * _input.normalized.magnitude * _speed * Time.deltaTime);

    }

    private void Dash()
    {
        if (Input.GetKeyDown("space"))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, _dashDistance, _wallMask))
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

    public void AddMana()
    {
        mana += 1;
        if (mana > maxMana)
            mana = maxMana;
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
