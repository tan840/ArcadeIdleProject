using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : Singleton<CurrencyManager>
{
    [SerializeField] int m_TotalStarCount = 0;
    UIManager m_UIManager;

    public int TotalStarCount { get => m_TotalStarCount; set => m_TotalStarCount = value; }

    private void Start()
    {
        m_UIManager = UIManager.Instance;
    }

    public void CollectStar(int _Value)
    {
        m_TotalStarCount += _Value;
        m_UIManager.SetText(m_TotalStarCount);
    }
}
