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
            if (other.gameObject.layer == 6 && TileScript != null)
            {
                print("TakeDamage");

            }
        }

    }
}

