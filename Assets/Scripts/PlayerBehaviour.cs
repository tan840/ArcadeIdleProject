using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] Rigidbody m_RB;
    bool isDead = false;
    NavMeshAgent m_Agent;
    public UnityAction OnDead;
    GameManager m_GameManager;
    private void Awake()
    {
        m_RB = GetComponentInChildren<Rigidbody>();
        m_Agent = GetComponent<NavMeshAgent>();
        m_GameManager = GameManager.Instance;
        OnDead += MakeDead;
    }
    void MakeDead()
    {
        if (isDead) return;
        print("Dead");
        m_Agent.enabled = false;
        m_RB.isKinematic = false;
        isDead = true;
        m_GameManager.IsGameOver?.Invoke();
    }
}
