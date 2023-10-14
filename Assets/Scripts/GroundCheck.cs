using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] bool m_isGrounded;
    [SerializeField] LayerMask m_layerMask;
    int frame = 0;
    public bool IsGrounded { get => m_isGrounded; set => m_isGrounded = value; }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            print("Grounded true");
            m_isGrounded = true;
        }
        else
        {
            m_isGrounded = false;
            print("Grounded false");
        }
    }
}
