using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class DogNavyMovement : MonoBehaviour
{
    [SerializeField] private LayerMask _ground;

    private float _speed = 5;
    private float _killZoneY = -6;
    private float _offset = 0.45f;
    private BoxCollider2D _collider;

    void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        _speed *= -Mathf.Sign(transform.position.x);
        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * Mathf.Sign(-_speed), transform.localScale.y);
    }

    private void FixedUpdate()
    {
        if (IsCanMove(_speed < 0))
        {
            _speed = -_speed;
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * Mathf.Sign(-_speed), transform.localScale.y);
        }

        if (transform.position.y < _killZoneY)
        {
            Destroy(gameObject);
        }

        transform.position += new Vector3(_speed * Time.fixedDeltaTime, 0, 0);
    }

    private bool IsCanMove(bool isLeft)
    {
        Vector2 side = isLeft ? Vector2.left : Vector2.right;

        return Physics2D.BoxCast(_collider.bounds.center, _collider.bounds.extents, 0f, side, _offset, _ground);
        //return !Physics2D.Raycast(_collider.bounds.center, side, _collider.bounds.size.x + _offset);
    }
}
