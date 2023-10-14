using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainGamePlayPannel : PannelBase
{
    [SerializeField] Button m_Retry;
    [SerializeField] TMP_Text m_Instructiontext;
    int ShowInstruction = 0;
    protected override void Start()
    {
        base.Start();
        m_Retry.onClick.AddListener(() => { OnRetry(); });
        ShowInstruction = PlayerPrefs.GetInt("INSTRUCTIONDATA", 0);
        print(ShowInstruction);
        if (ShowInstruction < 2)
        {
            ShowInstruction++;
            PlayerPrefs.SetInt("INSTRUCTIONDATA", ShowInstruction);
            m_Instructiontext.gameObject.SetActive(true);
            Invoke(nameof(DisableInstructionText), 3f);
        }
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
    void DisableInstructionText()
    {
        m_Instructiontext.gameObject.SetActive(false);
    }
}
