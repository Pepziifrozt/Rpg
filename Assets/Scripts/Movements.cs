using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rb;

    [SerializeField] private float _moveSpeed = 5f;
    private Vector2 _movement = new Vector2();

    public Vector3 CurrentMove()
    {
        return _movement * _moveSpeed;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        InputCode();
        AnimationCode();
    }
    private void FixedUpdate()
    {
        Movement();
    }

    private void InputCode()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        _movement = Vector2.ClampMagnitude(_movement, 1.0f);
    }

    private void AnimationCode()
    {
        _animator.SetFloat("Horizontal", _movement.x);
        _animator.SetFloat("Vertical", _movement.y);
        _animator.SetFloat("Speed", _movement.sqrMagnitude);
    }
    private void Movement()
    {
        _rb.MovePosition(_rb.position + _movement * _moveSpeed * Time.fixedDeltaTime);
        //_rb.velocity = _movement * _moveSpeed;
    }
}
