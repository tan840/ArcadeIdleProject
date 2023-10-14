using LaZZiiKings.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] int m_Health = 100;
    [SerializeField] int m_CurrentHealth = 100;
    CurrencyManager m_currencyManager;
    EnemyBase m_enemy;
    public int CurrentHealth { get => m_CurrentHealth; set => m_CurrentHealth = value; }

    void Start()
    {
        m_CurrentHealth = m_Health;
        m_currencyManager = CurrencyManager.Instance;
        m_enemy = GetComponent<EnemyBase>();
    }
    public void TakeDamage(int _DamageAmount, Action OnComplete = null)
    {
        m_CurrentHealth -= _DamageAmount;
        OnComplete?.Invoke();
        if (m_CurrentHealth <= 0)
        {
            m_enemy.OnDeath();
            m_currencyManager.CollectStar(1);
        }
    }
}
