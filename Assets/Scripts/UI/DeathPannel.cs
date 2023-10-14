using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathPannel : PannelBase
{
    [SerializeField] Button m_Retry;
    [SerializeField] Button m_Quit;
    protected override void Start()
    {
        base.Start();
        m_Retry.onClick.AddListener(() => { OnRetry(); });
        m_Quit.onClick.AddListener(() => { OnQuit(); });
    }
    protected override void OnEnable()
    {
        base.OnEnable();
    }
    protected override void OnDisable()
    {
        base.OnDisable();
    }
    void OnRetry()
    {
        SceneManager.LoadScene(0);
    }
    void OnQuit()
    {
        Application.Quit();
    }
}
