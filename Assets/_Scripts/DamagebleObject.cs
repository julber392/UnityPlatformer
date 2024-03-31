using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagebleObject : MonoBehaviour
{
    [SerializeField] private float _healthPoints;
    private Transform _transform;
    public Item[] _items;
    [SerializeField]private GameObject prefabToSpawn;
    private void Start()
    {

        _transform = GetComponent<Transform>();
    }

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
        DropItems(_transform);
        if(!gameObject.CompareTag("Player"))
        gameObject.GetComponent<EnemyPatrol>().point.GetComponent<Spawner>().DeathMonster(1);
        Destroy(gameObject);
    }
    void DropItems(Transform _position)
    {
        for (int i = 0; i < _items.Length; i++)
        {
            prefabToSpawn.GetComponent<ObjectOnGround>().item = _items[i];
            Instantiate(prefabToSpawn, _position.position + new Vector3(1, 0.5f, 0),
                Quaternion.identity);
        }
    }
}
