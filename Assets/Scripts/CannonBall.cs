using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] float m_Speed = 2f;
    [SerializeField] int m_Damage = 30;

    public int Damage { get => m_Damage; set => m_Damage = value; }

    void Update()
    {
        transform.position += transform.forward * m_Speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
        if (other.gameObject.layer == 7)
        {
            if (other.gameObject.TryGetComponent(out HealthSystem m_Health))
            {
                m_Health.TakeDamage(m_Damage);
                Destroy(gameObject);
            }
        }
    }
}
