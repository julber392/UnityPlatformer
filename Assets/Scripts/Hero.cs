using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float lives = 5;
    [SerializeField] private float jumpForce = 1f;
    private bool isGrounded = true;
    [SerializeField] private float _radiusGroundCheck = 0.01f;
    [SerializeField] private GameObject _groundCheckObj;
    [SerializeField] private LayerMask _groundMask;
    private Rigidbody2D _rigidbody2D;
    private bool jumpControl;
    private int jumpIteration = 0;
    public int jumpValueIteration = 60;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        CheckOnGround();
    }

    private void Update()
    {
        if (isGrounded) State = States.idle;
        if (Input.GetButton("Horizontal")) Run();
        Jump();

    }

    private void Run()
    {
        if (isGrounded) State = States.run;
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position =
            Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        _spriteRenderer.flipX = dir.x < 0.0f;
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (isGrounded)
            {
                jumpControl = true;
            }
        }
        else
        {
            jumpControl = false;
        }

        if (jumpControl)
        {
            if (jumpIteration++ < jumpValueIteration)
            {
                _rigidbody2D.AddForce(Vector3.up * jumpForce / jumpIteration);
            }
        }
        else
        {
            jumpIteration = 0;
        }
    }

    private void CheckOnGround()
    {
        isGrounded = Physics2D.OverlapCircle(_groundCheckObj.transform.position, _radiusGroundCheck, _groundMask);
        if (!isGrounded) State = States.jump;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(_groundCheckObj.transform.position, _radiusGroundCheck);
    }

    private States State
    {
        get { return (States)_animator.GetInteger("state"); }
        set { _animator.SetInteger("state", (int)value); }
    }

    public enum States
    {
        idle,
        run,
        jump
    }
}
