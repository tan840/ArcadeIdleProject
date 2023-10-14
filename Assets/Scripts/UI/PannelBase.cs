using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PannelBase : MonoBehaviour
{
    protected CanvasGroup m_canvasGroup;
    protected virtual void Start()
    {
        m_canvasGroup = GetComponent<CanvasGroup>();
    }
    protected virtual void OnEnable()
    {
        if(m_canvasGroup == null) m_canvasGroup = GetComponent<CanvasGroup>();
        float val = 0f;
        DOTween.To(() => val, x => val = x, 1f, 0.5f).OnUpdate(() =>
        {
            m_canvasGroup.alpha = val;
        });
    }
    protected virtual void OnDisable()
    {
        m_canvasGroup.alpha = 0;
    }
}
