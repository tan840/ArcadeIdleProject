using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] Animator m_Anim;
    [SerializeField] float m_RunSpeedMultiplier;
    [SerializeField] bool m_isAttacking = false;
    string m_CurrentState;
    const string IDLE_State = "Idle";
    const string RUN_State = "Fast Run";
    const string ATTACK_State = "Attack";
    public bool IsAttacking { get => m_isAttacking; set => m_isAttacking = value; }

    void Start()
    {
        if (m_Anim == null)
        {
            m_Anim = GetComponentInChildren<Animator>();
        }
    }
    public void SetAnim(Vector3 _Movement)
    {

        if (_Movement.magnitude > 0)
        {
            m_Anim.SetFloat("MoveSpeed", _Movement.magnitude * m_RunSpeedMultiplier);
            SwitchState(RUN_State);
        }
        else if (m_isAttacking)
        {
            SwitchState(ATTACK_State);
        }
        else
        {
            SwitchState(IDLE_State);
        }
    }
    void SwitchState(string _State)
    {
        if (_State == m_CurrentState)
        {
            return;
        }
        m_CurrentState = _State;
        m_Anim.Play(m_CurrentState);
    }
    //void PlayIdle()
    //{
    //    m_Anim.Play("Idle");
    //}
    //void PlayRun()
    //{
    //    m_Anim.Play("Fast Run");
    //}
    //void PlayAttack()
    //{
    //    m_Anim.Play("Attack");
    //}
}
