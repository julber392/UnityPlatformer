using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public int positionOfPatrol;
    public Transform point;
    private bool sideGoing = true;
    private Transform player;
    public float distanceForStopAgr;
    private SpriteRenderer _sprite;
    private float x1;
    private float x2;

    public Dictionary<string, bool> states = new Dictionary<string, bool>()
    {
        { "StayOnPoint", false },
        { "AttackPlayer", false },
        { "Back", false }
    };
    void Start()
    {
        _sprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    void Update()
    {
        x1 =_sprite.transform.position.x;
        if (Vector2.Distance(transform.position, point.position) < positionOfPatrol
            &&states["AttackPlayer"] ==false)
        {
            states["StayOnPoint"] = true;
        }

        if (Vector2.Distance(transform.position, player.position) < distanceForStopAgr)
        {
            states["AttackPlayer"] = true;
            states["StayOnPoint"] = false;
            states["Back"] = false;
        }
        if (Vector2.Distance(transform.position, player.position) > distanceForStopAgr)
        {
            states["Back"] = true;
            states["AttackPlayer"] = false;
        }

        if (states["StayOnPoint"])
        {
            StayOnPoint();
        }
        else if (states["AttackPlayer"])
        {
            AttackPlayer();
        }
        else if (states["Back"])
        {
            Back();
        }

        x2 = _sprite.transform.position.x;
        if(x1-x2<0)
        {
            _sprite.flipX = true;
        }
        else
        {
            _sprite.flipX = false;
        }
    }

    void StayOnPoint()
    {
        if (transform.position.x>point.position.x+positionOfPatrol)
        {
            sideGoing = false;
        }
        else if (transform.position.x < point.position.x - positionOfPatrol)
        {
            sideGoing = true;
        }

        if (sideGoing)
        {
            _sprite.flipX = true;
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime,transform.position.y);
        }
        else
        {
            _sprite.flipX = false;
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime,transform.position.y);
        }
    }

    void AttackPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    void Back()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
    }
}
