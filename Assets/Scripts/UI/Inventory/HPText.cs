using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HPText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Health _health;
    private void Awake()
    {
        _text=GetComponent<TextMeshProUGUI>();
        _health.HealthChanged += HealthChanged;
    }

    private void OnDestroy()
    {
        _health.HealthChanged -= HealthChanged;
    }

    private void HealthChanged(float percantage)
    {
        _text.text = _health.currentHP.ToString();
    }
}
