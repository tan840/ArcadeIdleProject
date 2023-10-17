using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CinemachineShake : Singleton<CinemachineShake>
{
    [SerializeField] CinemachineVirtualCamera m_Cam;
    float startIntensity;
    float shakeTime;
    void Awake()
    {
        //m_Cam = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    public void Shake(float Intensity, float Time)
    {
        CinemachineBasicMultiChannelPerlin perlin =
           m_Cam.GetComponent<CinemachineBasicMultiChannelPerlin>();
        perlin.m_AmplitudeGain = Intensity;

        startIntensity = Intensity;
        shakeTime = Time;
    }
    private void Update()
    {
        if (shakeTime > 0)
        {
            shakeTime -= Time.deltaTime;
            if (shakeTime <= 0f)
            {

                CinemachineBasicMultiChannelPerlin perlin =
       m_Cam.GetComponent<CinemachineBasicMultiChannelPerlin>();
                perlin.m_AmplitudeGain = 0;
            }


        }
    }
}
