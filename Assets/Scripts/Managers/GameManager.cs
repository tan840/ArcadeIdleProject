using UnityEngine;
using System;
using Unity.AI.Navigation;
using System.Collections;

public class GameManager : Singleton<GameManager>
{
    [Header("Navmesh")]
    [SerializeField] NavMeshSurface m_NavmeshSurface;

    UIManager m_UIManager;

    public Action BakeNavmesh;
    public Action IsGameOver;


    private void Start()
    {
        m_UIManager = UIManager.Instance;
        BakeNavmesh += BakeNavMesh;
        IsGameOver += GameOver;
    }
    public void BakeNavMesh()
    {
        StartCoroutine(Bake());
    }
    IEnumerator Bake()
    {
        yield return null;
        m_NavmeshSurface.BuildNavMesh();
    }
    void GameOver()
    {
        m_UIManager.OnGameOver();
        m_UIManager.SwitchPannel(UIManager.UIType.Gameover);
    }
}
