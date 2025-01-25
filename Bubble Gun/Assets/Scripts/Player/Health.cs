using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 12;
    private int _currentHealth;

    public Action<int> OnDamage;
    public Action OnKilled;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        OnDamage?.Invoke(_currentHealth);

        if(_currentHealth <= 0)
        {
            OnKilled?.Invoke();
        }
    }
}
