using UnityEngine;
using System;
using Unity.AI.Navigation;
using System.Collections;

public class GameManager : Singleton<GameManager>
{
    public delegate void OnTileDestroy();
    public OnTileDestroy BakeNavmesh;
    [SerializeField] NavMeshSurface m_NavmeshSurface;
    private void Start()
    {
        BakeNavmesh += BakeNavMesh;
    }
    public void BakeNavMesh()
    {
        print("Bake");
        StartCoroutine(Bake());
    }
    IEnumerator Bake()
    {
        yield return null;
        m_NavmeshSurface.BuildNavMesh();
    }
}
