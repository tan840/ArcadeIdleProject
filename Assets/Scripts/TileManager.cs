using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : Singleton<TileManager>
{
    [SerializeField] List<GroundTile> m_Tiles = new();
    [SerializeField] List<GroundTile> m_CannonTile = new();

    public List<GroundTile> Tiles { get => m_Tiles; set => m_Tiles = value; }
    public List<GroundTile> CannonTile { get => m_CannonTile; set => m_CannonTile = value; }

    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.TryGetComponent(out GroundTile m_Tile))
            {
                if (!m_Tiles.Contains( m_Tile))
                {
                    m_Tiles.Add(m_Tile);
                }
            }
        }
    }

}
