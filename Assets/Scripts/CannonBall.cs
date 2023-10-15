using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] float m_Speed = 2f;
    void Update()
    {
        transform.position += transform.forward * m_Speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
        if (other.gameObject.layer == 7)
        {
            if (other.gameObject.TryGetComponent(out HealthSystem m_Health))
            {
                m_Health.TakeDamage(100);
                Destroy(gameObject);
            }
        }
    }
}
