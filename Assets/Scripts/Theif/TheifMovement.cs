using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Theif))]

public class TheifMovement : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce = 500;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private float _offset = 0.07f;

    private Theif _theif;
    private Rigidbody2D _rigidbody2D;
    private BoxCollider2D _collider;
    private float _targetSpeed;

    private UnityEvent _moved = new UnityEvent();
    private UnityEvent _stayed = new UnityEvent();

    public event UnityAction Moved
    {
        add => _moved.AddListener(value);
        remove => _moved.RemoveListener(value);
    }

    public event UnityAction Stayed
    {
        add => _stayed.AddListener(value);
        remove => _stayed.RemoveListener(value);
    }

    private void Awake()
    {
        _theif = GetComponent<Theif>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
        }
    }

    private void FixedUpdate()
    {
        if (_theif.IsDead)
        {
            _jumpForce = 0;
            _speed = 0;
            return;
        }

        _targetSpeed = Input.GetAxisRaw("Horizontal") * _speed;

        if (_targetSpeed != 0)
        {
            Move(_targetSpeed);
            _moved.Invoke();
        }
        else
        {
            _stayed.Invoke();
        }
    }

    private void Move(float speed)
    {
        if (IsCanMove(speed < 0))
        {
            _transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            _transform.localScale = new Vector3(Mathf.Abs(_transform.localScale.x) * Mathf.Sign(speed), _transform.localScale.y);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(_collider.bounds.center, _collider.bounds.size, 0f, Vector2.down, _offset, _ground);
    }

    private bool IsCanMove(bool isLeft)
    {
        Vector2 side = isLeft ? Vector2.left : Vector2.right;

        return !Physics2D.BoxCast(_collider.bounds.center, _collider.bounds.size, 0f, side, _offset, _ground);
    }
}
