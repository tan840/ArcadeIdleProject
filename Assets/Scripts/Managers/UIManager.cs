using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    [Header("UIPannels")]
    [SerializeField] GameObject m_MainGameplay;
    [SerializeField] GameObject m_Menu;
    [SerializeField] GameObject m_GameOver;
    [Header("GameplayUI")]
    [SerializeField] Transform m_StarIcon;
    [SerializeField] TMP_Text m_StarText;
    [SerializeField] UIType m_UIPannel;

    public UIType UIPannel { get => m_UIPannel; set => m_UIPannel = value; }

    public enum UIType
    {
        MainMenu = 0,
        Gameover = 1,
        MainGameplay = 2
    }
    void Start()
    {
        SetText(0);
    }
    public void SetText(int _Coin)
    {
        m_StarText.text = _Coin.ToString();
    }

    public void OnRestart()
    {
        m_Menu.SetActive(false);
        m_MainGameplay.SetActive(true);
    }
    public void OnGameOver()
    {
        m_MainGameplay.SetActive(false);
        m_Menu.SetActive(true);
    }    
    public void SwitchPannel(UIType _UiPannel)
    {
        switch (_UiPannel)
        {
            case UIType.MainMenu:
                m_Menu.gameObject.SetActive(true);
                m_MainGameplay.gameObject.SetActive(false);
                m_GameOver.gameObject.SetActive(false);
                break;
            case UIType.Gameover:
                m_GameOver.gameObject.SetActive(true);
                m_Menu.gameObject.SetActive(false);
                m_MainGameplay.gameObject.SetActive(false);
                break;
            case UIType.MainGameplay:
                m_MainGameplay.gameObject.SetActive(true);
                m_Menu.gameObject.SetActive(false);
                m_GameOver.gameObject.SetActive(false);
                break;
            default:
                print("NoPannelShown");
                break;
        }
    }
}
