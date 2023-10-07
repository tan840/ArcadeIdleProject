using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace LaZZiiKings.Core
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] List<Transform> m_SpawnPoints;
        [SerializeField] List<GameObject> m_SpawnPrefabs;
        [SerializeField] int m_MaxSpawnCount = 5;
        [SerializeField] float m_MinSpawnDelay = 8;
        [SerializeField] float m_MaxSpawnDelay = 10;
        [SerializeField] int Spawncount = 0;
        [SerializeField] Transform m_PlayerTransform;
        Coroutine Cor;
        private void Start()
        {
            if (Cor == null)
            {
                Cor = StartCoroutine(Spawn());
            }
        }
        IEnumerator Spawn()
        {
           
            while (Spawncount <= m_MaxSpawnCount)
            {
                yield return new WaitForSeconds(Random.Range(m_MinSpawnDelay, m_MaxSpawnDelay));
                GameObject Enemy = Instantiate(m_SpawnPrefabs[Random.Range(0, m_SpawnPrefabs.Count)], m_SpawnPoints[Random.Range(0, m_SpawnPoints.Count)].position, Quaternion.identity, transform);
                EnemyBase m_EnemyScript = Enemy.GetComponent<EnemyBase>();
                m_EnemyScript.Target = m_PlayerTransform;
                Spawncount++;
            }
            Cor = null;
        }

    }
}

