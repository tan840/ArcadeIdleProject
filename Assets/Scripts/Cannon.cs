using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Cannon : MonoBehaviour
{
    [SerializeField] float m_AttackDistance = 1;
    [SerializeField] int m_AttackDamage = 10;
    [SerializeField] Transform m_Target;
    [SerializeField] LayerMask m_Layer;
    [SerializeField] bool m_CanShoot = true;

    [Header("Cannon")]
    [SerializeField] GameObject m_BallPrefab;
    [SerializeField] Transform m_ShootPos;

    int frames = 0;
    private void FixedUpdate()
    {
        frames++;
        if (frames % 10 == 0)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, m_AttackDistance, m_Layer);
            if (hitColliders.Length > 0)
            {
                foreach (var hitCollider in hitColliders)
                {
                    m_Target = hitCollider.transform;
                    if (m_Target != null)
                    {
                        Vector3 Direction = m_Target.position - transform.position;
                        transform.forward = Direction.normalized;
                        //m_PlayerAnimator.IsAttacking = true;
                        if (m_CanShoot)
                        {
                            m_CanShoot = false;
                            StartCoroutine(Shoot());
                        }
                    }
                }
            }
            else
            {
                m_Target = null;
                //m_PlayerAnimator.IsAttacking = false;
            }
        }
    }
    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(1f);
        //_HealthSystem.TakeDamage(m_AttackDamage);
        while (m_Target != null)
        {
            GameObject ball = Instantiate(m_BallPrefab, m_ShootPos.position, m_ShootPos.rotation, transform);
            ball.GetComponent<CannonBall>().Damage = m_AttackDamage;
            yield return new WaitForSeconds(5f);
        }
        m_CanShoot = true;
    }
    public void RegisterGround(GroundTile _Tile)
    {
        _Tile.OnTileDestroy += OnGroundTileDestroyed;
    }
    void OnGroundTileDestroyed()
    {
        StopAllCoroutines();
        gameObject.SetActive(false);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, m_AttackDistance);
    }
}
