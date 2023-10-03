using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    [Header("Control")]
    [SerializeField] DynamicJoystick m_Joystick;
    [SerializeField] float m_MoveSpeed = 10;
    CharacterController m_CharacterController;
    PlayerAnimator m_PlayerAnim;
    void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();
        m_PlayerAnim = GetComponent<PlayerAnimator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        Vector3 m_speed = Vector3.zero;
        if (m_Joystick.MoveThreshold > 0.05f)
        {
            Vector3 Direction = new Vector3(m_Joystick.Direction.x, 0, m_Joystick.Direction.y);
            m_speed = m_MoveSpeed * new Vector3(m_Joystick.Horizontal, 0 , m_Joystick.Vertical) * Time.fixedDeltaTime;
            m_CharacterController.SimpleMove(m_speed);
            transform.forward = Direction.normalized;
            m_PlayerAnim.SetAnim(m_speed);
        }
        else
        {
            m_PlayerAnim.SetAnim(m_speed);
        }
    }
}
