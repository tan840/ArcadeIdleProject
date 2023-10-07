using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace LaZZiiKings.Core
{
    public abstract class EnemyBase : MonoBehaviour
    {
        [SerializeField] protected bool m_CanMove;
        [SerializeField] protected Transform m_Target;
        [SerializeField] protected Transform m_Tile;
        [SerializeField] protected Rigidbody m_RB;
        [SerializeField] protected float m_Speed = 10f;
        [SerializeField] protected float m_Damage = 10f;
        [SerializeField] protected GroundTile TileScript;
        public abstract Transform Target { get; set; }
        public abstract Rigidbody RB { get; }
        public virtual void Start()
        {          
        }
        public virtual void FixedUpdate()
        {
            if (m_Target != null && m_CanMove)
            {
                Vector3 Direction = m_Target.position - transform.position;
                transform.forward = Direction.normalized;
                m_RB.velocity = Direction.normalized * m_Speed * Time.fixedDeltaTime;
            }
            else
            {
                m_RB.velocity = Vector3.zero;
            }
        }
        public virtual void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.layer == 6)
            {
                m_Tile = other.transform;
                if (m_Tile != null)
                {
                    m_CanMove = false;
                    GroundTile TileScript = m_Tile.GetComponent<GroundTile>();
                    TileScript.OnTileDestroy += OnTileDestroy;
                    TileScript.GetDamage();
                }
            }
        }
        void OnTileDestroy()
        {
            m_CanMove = true;
            print("Destroyed Tile");
        }
    }
}

