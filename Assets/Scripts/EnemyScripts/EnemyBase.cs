using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LaZZiiKings.Core
{
    public abstract class EnemyBase : MonoBehaviour
    {
        public virtual void Start()
        {
            
        }
        public abstract void Move();
    }
}

