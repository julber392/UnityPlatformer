using System;
using UnityEngine;

public class MonsterAI : DamagebleObject
{
    public float Speed;
    private EnemyMoveController _enemyMoveController;
    private void Awake()
    {
        _enemyMoveController = GetComponent<EnemyMoveController>();
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _enemyMoveController.Move(Speed);
    }
}
