using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagebleObject : MonoBehaviour
{
    [SerializeField] private float _healthPoints;

    public void TakeDamage(float damage)
    {
        _healthPoints -= damage;
        print(_healthPoints);
        if (_healthPoints <= 0)
        {
            Death();
        }

        Debug.Log("Hit");
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
