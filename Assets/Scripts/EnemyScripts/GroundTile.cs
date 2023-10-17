using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class GroundTile : MonoBehaviour
{
    [SerializeField] float m_TileHealth;
    [SerializeField] float m_MoveDownDistance;
    public Action OnTileDestroy;
    bool m_TakeDamage = false;
    bool isEnabled = true;
    Coroutine m_DamageCoroutine;
    GameManager m_GameManager;
    Vector3 InitialPosition;
    public bool TakeDamage { get => m_TakeDamage; set => m_TakeDamage = value; }
    public float TileHealth { get => m_TileHealth; }
    public bool IsEnabled { get => isEnabled; set => isEnabled = value; }

    private void Start()
    {
        m_GameManager = GameManager.Instance;
        InitialPosition = transform.position;
    }
    private void OnEnable()
    {
        isEnabled = true;
    }
    private void OnDisable()
    {
        isEnabled = false;
        if (m_DamageCoroutine != null)
        {
            StopCoroutine(m_DamageCoroutine);

        }
        transform.position = InitialPosition;
    }
    public void GetDamage(int _DamageAmount)
    {
        if (isEnabled)
        {
            m_DamageCoroutine = StartCoroutine(DamageSequence(_DamageAmount));

        }
    }
    IEnumerator DamageSequence(int _DamageAmount)
    {
        yield return null;
        bool m_BellowBreakthreshold = false;
        //yield return new WaitForSeconds(0.8f);
        m_TileHealth -= _DamageAmount;
        if (m_TileHealth < 50 && !m_BellowBreakthreshold)
        {
            m_BellowBreakthreshold = true;
            SinkTile();
        }
        if (m_TileHealth <= 0)
        {
            m_TakeDamage = false;
            m_GameManager.BakeNavmesh?.Invoke();
            OnTileDestroy?.Invoke();
            StopCoroutine(m_DamageCoroutine);
            isEnabled = false;
            gameObject.SetActive(false);
        }
    }
    void SinkTile()
    {
        transform.DOLocalMoveY(m_MoveDownDistance, 1f);
        //transform.DORotate(new Vector3(transform.rotation.x , transform.rotation.y, transform.rotation.z), 1f);
    }
}
