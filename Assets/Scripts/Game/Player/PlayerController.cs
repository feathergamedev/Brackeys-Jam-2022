using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private EmojiController _emojiController;
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
        DetectEmojiInput();
        DetectMoveInput();
//        _emojiController            
    }

    private void DetectEmojiInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _emojiController.PlayEmoji(EEmojiType.GHOST);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            _emojiController.PlayEmoji(EEmojiType.SHINY_EYES);
        }
    }

    private void DetectMoveInput()
    {
        _currentMoveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        _isMoving = (_currentMoveDirection != Vector2.zero);
        _currentVelocity = _currentMoveDirection * _moveSpeed;

        _animator.SetBool("InputMoveUp", Input.GetAxisRaw("Vertical") > 0);
        _animator.SetBool("InputMoveDown", Input.GetAxisRaw("Vertical") < 0);
        _animator.SetBool("InputMoveRight", Input.GetAxisRaw("Horizontal") > 0);
        _animator.SetBool("InputMoveLeft", Input.GetAxisRaw("Horizontal") < 0);
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _currentVelocity;
    }
}
