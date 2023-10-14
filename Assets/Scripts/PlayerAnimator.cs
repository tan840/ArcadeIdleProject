using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] Animator m_Anim;
    [SerializeField] float m_RunSpeedMultiplier;
    [SerializeField] bool m_isAttacking = false;
    int m_CurrentState;
    int IDLE_State = Animator.StringToHash("Idle");
    int RUN_State = Animator.StringToHash("Fast Run");
    int ATTACK_State = Animator.StringToHash("Attack");
    Coroutine AnimState;
    public bool IsAttacking { get => m_isAttacking; set => m_isAttacking = value; }

    void Start()
    {
        if (m_Anim == null)
        {
            m_Anim = GetComponentInChildren<Animator>();
        }
    }
    private void Update()
    {

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
    void SwitchState(int _State)
    {
        if (_State == m_CurrentState)
        {
            return;
        }
        m_CurrentState = _State;
        m_Anim.Play(m_CurrentState);
        if (AnimState != null)
        {
            StopCoroutine(AnimState);
        }
        AnimState = StartCoroutine(CheckAnimationCompleted(m_CurrentState));
    }
    public IEnumerator CheckAnimationCompleted(int CurrentAnim, Action Oncomplete = null)
    {
        //print(m_Anim.GetCurrentAnimatorStateInfo(0).shortNameHash);
        //print("CurrentAnim " + CurrentAnim);
        while (m_Anim.GetCurrentAnimatorStateInfo(0).shortNameHash == CurrentAnim)
        {
            //print(m_Anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
            yield return null;
        }
        Oncomplete?.Invoke();
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
