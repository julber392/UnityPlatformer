using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health stats")] 
    [SerializeField]
    public int maxHP = 100;
    public int currentHP;
    public event Action<float> HealthChanged;

    private void Start()
    {
        currentHP = maxHP;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ChangeHealth(-10);
        }
    }

    private void ChangeHealth(int value)
    {
        currentHP += value;
        if (currentHP <= 0)
        {
            Death();
        }
        else
        {
            float percentageCurrentHP = (float)currentHP / maxHP;
            HealthChanged?.Invoke(percentageCurrentHP);
        }
    }

    private void Death()
    {
        HealthChanged?.Invoke(0);
        Debug.Log("You are death");
    }
}
