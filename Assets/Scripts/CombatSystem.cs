using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class CombatSystem : MonoBehaviour
{
    [SerializeField] float m_AttackDistance = 1;
    [SerializeField] Transform m_Target;
    [SerializeField] LayerMask m_Layer;
    int frames = 0;
    PlayerAnimator m_PlayerAnimator;
    private void Start()
    {
        m_PlayerAnimator = GetComponent<PlayerAnimator>();
    }
    private void FixedUpdate()
    {
        frames++;
        if (frames % 10 == 0)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, m_AttackDistance, m_Layer);
            print(hitColliders.Length);
            if (hitColliders.Length >0)
            {
                foreach (var hitCollider in hitColliders)
                {
                    m_Target = hitCollider.transform;
                    if (m_Target != null)
                    {
                        Vector3 Direction = m_Target.position - transform.position;
                        transform.forward = Direction.normalized;
                        m_PlayerAnimator.IsAttacking = true;
                    }
                }
            }
            else
            {
                m_Target = null;
                m_PlayerAnimator.IsAttacking = false;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, m_AttackDistance);
    }
}
