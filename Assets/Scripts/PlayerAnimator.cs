using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] Animator m_Anim;
    [SerializeField] float m_RunSpeedMultiplier;
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
            PlayRun();
        }
        else
        {
            PlayIdle();
        }
    }
    void PlayIdle()
    {
        m_Anim.Play("Idle");
    }
    void PlayRun()
    {
        m_Anim.Play("Fast Run");
    }
}
