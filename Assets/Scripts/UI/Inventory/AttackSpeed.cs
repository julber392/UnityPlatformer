using System;
using TMPro;
using UnityEngine;

public class AttackSpeed : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private AttackController _attackSpeed;
    private void Awake()
    {
        _text=GetComponent<TextMeshProUGUI>();
        _text.text=((float)(1/_attackSpeed.attackDelay)).ToString("0.0");
    }

    private void OnEnable()
    {
        _attackSpeed.AttackSpeedChanged += Attack;
    }
    
    private void OnDisable()
    {
        _attackSpeed.AttackSpeedChanged += Attack;
    }

    private void Attack(float attackSpeed)
    {
        _text.text = ((float)(1/attackSpeed)).ToString("0.0");
    }
}