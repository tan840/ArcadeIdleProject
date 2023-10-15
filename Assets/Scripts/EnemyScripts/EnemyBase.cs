using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

namespace LaZZiiKings.Core
{
    public abstract class EnemyBase : MonoBehaviour
    {
        [SerializeField] protected bool m_CanMove;
        [SerializeField] protected Transform m_Target;
        [SerializeField] protected Transform m_Tile;
        [SerializeField] protected Rigidbody m_RB;
        [SerializeField] protected float m_Speed = 10f;
        [SerializeField] protected int m_Damage = 10;
        [SerializeField] protected GroundTile TileScript;
        [SerializeField] protected Collider m_collider;
        [SerializeField] protected Animator m_Anim;
        public Action isDead;
        public abstract Transform Target { get; set; }
        public abstract Rigidbody RB { get; }
        public virtual void Start()
        {
            m_collider = GetComponent<Collider>();
            m_Anim = GetComponent<Animator>();
        }
        public virtual void OnDisable()
        {
            if (m_Tile != null)
            {
                GroundTile TileScript = m_Tile.GetComponent<GroundTile>();
                TileScript.OnTileDestroy -= OnTileDestroy;
            }
        }
        public virtual void FixedUpdate()
        {
            if (m_Target != null && m_CanMove)
            {
                Vector3 Direction = m_Target.position - transform.position;
                transform.forward = Direction.normalized;
                m_RB.velocity = Direction.normalized * m_Speed * Time.fixedDeltaTime;
                m_Anim.SetBool("Attack", false);
            }
            else
            {
                m_RB.velocity = Vector3.zero;
                m_RB.angularVelocity = Vector3.zero;
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
                    //TileScript.GetDamage();
                    m_Anim.SetBool("Attack", true);
                }
            }
        }
        public virtual void MelleAttack()
        {
            if (m_Tile != null)
            {
                print("Attacking");
                GroundTile TileScript = m_Tile.GetComponent<GroundTile>();
                TileScript.GetDamage(m_Damage);
            }
        }
        void OnTileDestroy()
        {
            m_CanMove = true;
            m_Anim.SetBool("Attack", false);
        }
        public abstract void OnDeath();
    }
}

