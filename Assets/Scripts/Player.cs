using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region ===== REFERENCES =====
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    [SerializeField] private int _lifes = 3;

    [SerializeField] private GameObject _flipFlopPrefab;
    [SerializeField] private Transform _throwPoint;
    private int _flipFlopNum = 1;

    [SerializeField] private float _movementSpeed;
    [SerializeField] private int _jumpForce;
    [SerializeField] private int _jumpCounter = 1;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private float _checkGroundDistance;

    public int Lifes { get => _lifes; set => _lifes = value; }
    #endregion

    #region ===== MONOBEHAVIOUR =====
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        Movement();
        PlayerInputs();
        OnFlipFlopReturn();
     
    }
    #endregion  

    private void PlayerInputs()
    {
        if (IsGrounded() == true && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        //sprint
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _movementSpeed *= 2;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            FlipFlopThrow();
        }
    }

    private void FlipFlopThrow()
    {
        Instantiate(_flipFlopPrefab, _throwPoint.position, _throwPoint.rotation);
        _flipFlopNum--;
    }

    private void OnFlipFlopReturn()
    {
        if (_flipFlopNum == 0)
        {
            _flipFlopNum++;
        }
    
    }

    //private bool HasFlipFlop()
    //{
    //    if (_flipFlopNum == 0) return false;
    //    if (_flipFlopNum == 1) return true;
    //}
        

    public void GotHit()
    {
        _lifes--;

        if (_lifes <= 0)
        {
            Destroy(gameObject);
            //para o jogo
            //chama a gameover screen
        }
    }

    private void OnCollect()
    {
        ICollectable collectable = GetComponent<ICollectable>();

        if (collectable != null)
        {
            collectable.Collect();
        }
    }


    #region ===== MOVEMENT AND JUMP =====
    private void Movement()
    {
        float movementInput = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(movementInput, _movementSpeed);

        _rigidbody.velocity = new Vector2(movement.x * _movementSpeed, _rigidbody.velocity.y);
    }


    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, _checkGroundDistance, _whatIsGround);

        if (hit)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
    #endregion
}
