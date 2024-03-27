using System;
using UnityEngine;

public class EnemyMoveController : MonoBehaviour
{
    private Vector3 _flipSprite = new Vector3(0, 180, 0);
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private float _signPrevious;
    private float _signCurrent;
    private Vector2 _speed;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Flip();
    }

    private void Flip()
    {
        _signCurrent = _rigidbody.velocity.x == 0 ? _signPrevious : MathF.Sign(_rigidbody.velocity.x);
        if (_signCurrent!=_signPrevious)
        {
            transform.rotation = Quaternion.Euler(_rigidbody.velocity.x < 0 ? _flipSprite:Vector3.zero);
        }
        _signPrevious = _signCurrent;
    }

    public void Move(float speed)
    {
        _speed.Set(speed,_rigidbody.velocity.y);
        _rigidbody.velocity = _speed;
    }
}
