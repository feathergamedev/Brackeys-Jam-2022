using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private BoxCollider2D _collider;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _renderer;


    [Header("Movement")]
    [SerializeField] private float _moveSpeed;
    private Vector2 _currentMoveDirection;
    private Vector2 _currentVelocity;
    private bool _isMoving;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        _currentMoveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        _isMoving = (_currentMoveDirection != Vector2.zero);
        _currentVelocity = _currentMoveDirection * _moveSpeed;

        _animator.SetBool("IsMoving", _isMoving);

        if (Input.GetAxisRaw("Horizontal") > 0)
            _renderer.flipX = false;
        else if (Input.GetAxisRaw("Horizontal") < 0)
            _renderer.flipX = true;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _currentVelocity;
    }
}
