using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obj;
    private float randomX;
    private Vector2 whereToSpawn;
    public float spawnDelay;
    private float nextSpawn=0.0f;

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnDelay;
            randomX = Random.Range(-8, 8);
            whereToSpawn = new Vector2(randomX, transform.position.y);
            GameObject Enemy = Instantiate(obj, whereToSpawn,Quaternion.identity);
        }
    }
}
