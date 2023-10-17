using DG.Tweening;
using LaZZiiKings.Core;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MenuPannel : PannelBase
{
    [SerializeField] int m_TileCost;
    [SerializeField] Button m_Tile;
    [SerializeField] int m_StrengthCost;
    [SerializeField] Button m_Strength;
    [SerializeField] int m_CannonCost;
    [SerializeField] Vector3 m_CannonOffset;
    [SerializeField] int m_CannonCount = 1;
    [SerializeField] Button m_Cannon;
    [SerializeField] Button m_Start;
    CurrencyManager m_CurrencyManager;
    GameManager m_GameManager;
    int spawnnedCannon = 0;
    protected override void Start()
    {
        base.Start();
        m_Tile.onClick.AddListener(() => { Tile(); });
        m_Strength.onClick.AddListener(() => { Strength(); });
        m_Cannon.onClick.AddListener(() => { Cannon(); });
        m_Start.onClick.AddListener(() => { StartWave(); });
        m_CurrencyManager = CurrencyManager.Instance;
        m_GameManager = GameManager.Instance;
    }
    protected override void OnEnable()
    {
        base.OnEnable();
    }
    protected override void OnDisable()
    {
        base.OnDisable();
    }
    void Tile()
    {
        if (m_TileCost <= m_CurrencyManager.TotalStarCount)
        {
            m_CurrencyManager.TotalStarCount -= m_TileCost;
            m_CurrencyManager.UpdateStar();
            foreach (var item in TileManager.Instance.Tiles)
            {
                if (item.TryGetComponent(out GroundTile Tile))
                {
                    if (!Tile.IsEnabled)
                    {
                        Tile.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
    }
    void Strength()
    {
        if (m_StrengthCost <= m_CurrencyManager.TotalStarCount)
        {
            m_CurrencyManager.TotalStarCount -= m_StrengthCost;
            m_CurrencyManager.UpdateStar();
            m_GameManager.PlayerCombatReference.AttackDamage++;
            m_GameManager.PlayerCombatReference.transform.DOPunchScale(GameManager.Instance.PlayerCombatReference.transform.localScale * 1.2f, 0.25f, 5, 0.5f);
        }
    }
    void Cannon()
    {
        if (m_CannonCost <= m_CurrencyManager.TotalStarCount)
        {
            m_CurrencyManager.TotalStarCount -= m_CannonCost;
            m_CurrencyManager.UpdateStar();
            foreach (var item in TileManager.Instance.CannonTile)
            {
                if (item.IsEnabled && m_CannonCount > spawnnedCannon)
                {
                    TileManager.Instance.CannonTile.Remove(item);
                    spawnnedCannon++;
                    m_GameManager.SpawnCannon(item.transform.position + m_CannonOffset);
                    break;
                }

            }
        }
    }
    void StartWave()
    {
        UIManager.Instance.SwitchPannel(UIManager.UIType.MainGameplay);
        EnemyController.Instance.SpawnWave();
        m_GameManager.BakeNavMesh();
    }
}
