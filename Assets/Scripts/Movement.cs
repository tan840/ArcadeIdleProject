using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Movement : MonoBehaviour
{
    [Header("Control")]
    [SerializeField] DynamicJoystick m_Joystick;
    [SerializeField] float m_MoveSpeed = 10;
    NavMeshAgent m_Agent;
    PlayerAnimator m_PlayerAnim;
    PlayerBehaviour m_playerBehaviour;
    [Header("GroundChecker")]
    [SerializeField] float m_RayLength = 1.5f;
    [SerializeField] LayerMask m_layer;
    [SerializeField] bool m_isGrounded;
    [SerializeField] Vector3 m_Offset;

    private void Awake()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        m_PlayerAnim = GetComponent<PlayerAnimator>();
        m_playerBehaviour = GetComponent<PlayerBehaviour>();
    }
    void FixedUpdate()
    {
        GroundCheck();
        Move();
    }
    void Move()
    {
        if (m_isGrounded)
        {
            Vector3 Direction = new(m_Joystick.Horizontal, 0, m_Joystick.Vertical);
            Vector3 speed = m_MoveSpeed * Direction * Time.fixedDeltaTime;
            if (speed.magnitude > 0.01f)
            {
                m_Agent.Move(speed);
                m_PlayerAnim.SetAnim(speed);
                transform.forward = Direction.normalized;
            }
            else
            {
                m_PlayerAnim.SetAnim(speed);
            }
        }
        else if(!m_isGrounded)
        {
            m_playerBehaviour.OnDead?.Invoke();
        }
    }
    void GroundCheck()
    {
        RaycastHit m_hit;
        if (Physics.BoxCast(transform.position + m_Offset,Vector3.one * 0.25f, Vector3.down,out m_hit,Quaternion.identity, m_RayLength, m_layer))
        {
            m_isGrounded = true;
        }
        else
        {
            m_isGrounded = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position + m_Offset, Vector3.one * 0.25f);
    }
}
