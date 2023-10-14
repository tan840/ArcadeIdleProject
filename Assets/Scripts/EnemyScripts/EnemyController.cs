using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace LaZZiiKings.Core
{
    public class EnemyController : Singleton<EnemyController>
    {
        [SerializeField] List<Transform> m_SpawnPoints;
        [SerializeField] List<GameObject> m_SpawnPrefabs;
        [SerializeField] List<EnemyWave> m_EnemyWave;
        [SerializeField] int m_MaxSpawnCount;
        [SerializeField] float m_MinSpawnDelay = 8;
        [SerializeField] float m_MaxSpawnDelay = 10;
        [SerializeField] int Spawncount = 0;
        [SerializeField] Transform m_PlayerTransform;
        [SerializeField] int SpawnIndex = 0;
        Coroutine Cor;
        int m_EnemykilledCount = 0;
        private void Start()
        {
            SpawnWave();
        }
        public void SpawnWave()
        {
            if (Cor == null)
            {
                Cor = StartCoroutine(Spawn());
            }
        }
        IEnumerator Spawn()
        {
            //for (int i = 0; i < m_EnemyWave[i].MaxSpawnCount; i++)
            //{
            //    yield return new WaitForSeconds(Random.Range(m_MinSpawnDelay, m_MaxSpawnDelay));
            //    GameObject Enemy = Instantiate(m_EnemyWave[i]
            //        .SpawnPrefabs[Random.Range(0, m_SpawnPrefabs.Count)], m_SpawnPoints[Random.Range(0, m_SpawnPoints.Count)].position, Quaternion.identity, transform);
            //    EnemyBase m_EnemyScript = Enemy.GetComponent<EnemyBase>();
            //    m_EnemyScript.Target = m_PlayerTransform;
            //    Spawncount++;

            //}
            m_MaxSpawnCount = m_EnemyWave[SpawnIndex].MaxSpawnCount;
            while (Spawncount < m_MaxSpawnCount)
            {
                yield return new WaitForSeconds(Random.Range(m_MinSpawnDelay, m_MaxSpawnDelay));
                GameObject Enemy = Instantiate(m_EnemyWave[SpawnIndex].SpawnPrefabs[Random.Range(0, m_SpawnPrefabs.Count)], m_SpawnPoints[Random.Range(0, m_SpawnPoints.Count)].position, Quaternion.identity, transform);
                EnemyBase m_EnemyScript = Enemy.GetComponent<EnemyBase>();
                m_EnemyScript.isDead += EnemyDeadCount;
                m_EnemyScript.Target = m_PlayerTransform;
                Spawncount++;
            }
            SpawnIndex++;
            Cor = null;
        }
        void EnemyDeadCount()
        {
            m_EnemykilledCount++;
            print("Killed " + m_MaxSpawnCount + " " + m_EnemykilledCount);
            if (m_MaxSpawnCount <= m_EnemykilledCount)
            {
                Invoke(nameof(SwitchUI), 3f);
            }
        }
        void SwitchUI()
        {
            UIManager.Instance.SwitchPannel(UIManager.UIType.MainMenu);
        }
    }
    [System.Serializable]
    public class EnemyWave
    {
        public int MaxSpawnCount;
        public int NextWaveDelay;
        public GameObject[] SpawnPrefabs;
    }
}

