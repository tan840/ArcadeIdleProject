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
    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        m_PlayerAnim = GetComponent<PlayerAnimator>();
    }

    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        Vector3 Direction = new Vector3(m_Joystick.Horizontal, 0, m_Joystick.Vertical);
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
}
