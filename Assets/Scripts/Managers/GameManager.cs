using UnityEngine;
using System;
using Unity.AI.Navigation;
using System.Collections;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject m_CannonPrefab;
    [Header("Navmesh")]
    [SerializeField] NavMeshSurface m_NavmeshSurface;
    [SerializeField] CombatSystem m_PlayerCombatReference;

    UIManager m_UIManager;

    public Action BakeNavmesh;
    public Action IsGameOver;

    public CombatSystem PlayerCombatReference { get => m_PlayerCombatReference; set => m_PlayerCombatReference = value; }

    private void Start()
    {
        m_NavmeshSurface = GameObject.FindAnyObjectByType<NavMeshSurface>();
        m_PlayerCombatReference = GameObject.FindAnyObjectByType<CombatSystem>();
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
    public void SpawnCannon(Vector3 _SpawnPoint)
    {
        GameObject Cannon = Instantiate(m_CannonPrefab, _SpawnPoint, Quaternion.identity, transform);
    }
}
