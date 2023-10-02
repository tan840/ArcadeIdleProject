using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] DynamicJoystick m_Joystick;
    [SerializeField] float m_MoveSpeed = 10;
    CharacterController m_CharacterController;
    void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        if (m_Joystick.MoveThreshold > 0.05f)
        {
            Vector3 Direction = new Vector3(m_Joystick.Direction.x, 0, m_Joystick.Direction.y);
            Vector3 m_speed = m_MoveSpeed * Direction.normalized;
            m_CharacterController.SimpleMove(m_speed);
            transform.forward = Direction.normalized;
        }
    }
}
