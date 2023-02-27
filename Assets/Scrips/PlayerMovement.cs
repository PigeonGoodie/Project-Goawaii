using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _turnSpeed = 360;
    [SerializeField] private float _dash = 500;

    public Transform _dashSparkle;

    private Vector3 _input;

    private void Start()
    {
        _dashSparkle.GetComponent<ParticleSystem>().enableEmission = false;
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
            _rb.AddForce(transform.forward * _dash);

            _dashSparkle.GetComponent<ParticleSystem>().enableEmission = true;
            StartCoroutine(stopDashSparkles());
 
            Debug.Log("dash");
        }
    }

    IEnumerator stopDashSparkles()
    {
        yield return new WaitForSeconds(.4f);
        _dashSparkle.GetComponent<ParticleSystem>().enableEmission = false;
    }
}

public static class Helpers
{
    private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
    public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);
}
