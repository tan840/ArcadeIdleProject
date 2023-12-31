using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace LaZZiiKings.Core
{
    public class Sharks : EnemyBase
    {
        public override Transform Target { get => m_Target; set => m_Target = value; }

        public override Rigidbody RB => m_RB;

        public override void Start()
        {
            base.Start();
        }
        public override void FixedUpdate()
        {
            base.FixedUpdate();
        }
        public override void OnCollisionEnter(Collision other)
        {
            base.OnCollisionEnter(other);
        }
        public override void OnDeath()
        {
            gameObject.SetActive(false);
            isDead?.Invoke();
        }
        public override void MelleAttack()
        {
            base.MelleAttack();
        }
    }
}

