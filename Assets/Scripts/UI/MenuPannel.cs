using LaZZiiKings.Core;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class MenuPannel : PannelBase
{
    [SerializeField] int m_TileCost;
    [SerializeField] Button m_Tile;
    [SerializeField] int m_StrengthCost;
    [SerializeField] Button m_Strength;
    [SerializeField] int m_CannonCost;
    [SerializeField] Button m_Cannon;
    [SerializeField] Button m_Start;
    CurrencyManager m_CurrencyManager;
    protected override void Start()
    {
        base.Start();
        m_Tile.onClick.AddListener(() => { Tile(); });
        m_Strength.onClick.AddListener(() => { Strength(); });
        m_Cannon.onClick.AddListener(() => {  Cannon(); });
        m_Start.onClick.AddListener(() => {  StartWave(); });
        m_CurrencyManager = CurrencyManager.Instance;
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
            //for (int i = 0; i < TileManager.Tiles.Count; i++)
            //{
            //    if (TileManager.Tiles[i].TryGetComponent(out GroundTile Tile))
            //    {
            //        if (!Tile.IsEnabled)
            //        {
            //            Tile.gameObject.SetActive(true);
            //            break;
            //        }
            //    }
            //}
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

    }
    void Cannon()
    {

    }
    void StartWave()
    {
        UIManager.Instance.SwitchPannel(UIManager.UIType.MainGameplay);
        EnemyController.Instance.SpawnWave();
    }
}
