using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GroundTile : MonoBehaviour
{
    [SerializeField] float m_TileHealth;
    public Action OnTileDestroy;
    bool m_TakeDamage = false;
    Coroutine m_DamageCoroutine;
    public bool TakeDamage { get => m_TakeDamage; set => m_TakeDamage = value; }
    public float TileHealth { get => m_TileHealth; }
    public void GetDamage()
    {
        if (m_DamageCoroutine == null)
        {
            m_TakeDamage = true;
            m_DamageCoroutine = StartCoroutine(DamageSequence());
        }
    }
    IEnumerator DamageSequence()
    {
        yield return null;
        while (m_TakeDamage)
        {
            yield return new WaitForSeconds(1f);
            m_TileHealth -= 10;
            if (m_TileHealth <= 0)
            {
                m_TakeDamage = false;
                StopCoroutine(m_DamageCoroutine);
                gameObject.SetActive(false);
            }
        }
    }
}
