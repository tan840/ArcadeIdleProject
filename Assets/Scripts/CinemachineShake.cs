using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CinemachineShake : Singleton<CinemachineShake>
{
    [SerializeField] CinemachineVirtualCamera m_Cam;
    void Awake()
    {
        m_Cam = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    public void Shake(float Intensity, float Time)
    {

    }
}
