using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    public RectTransform[] children;

    private void Awake()
    {
        children = this.GetComponentsInChildren<RectTransform>(true);
    }
    private void Start()
    {
        PauseAndStart();
    }

    public void ResumeAndPlay()
    {
        Time.timeScale = 1f;
        TurnOnTitles(false);
    }
    public void PauseAndStart()
    {
        Time.timeScale = 0f;
        TurnOnTitles(true);
    }

    private void TurnOnTitles(bool value)
    {
        for(int index = 1; index < children.Length; index ++)
        {
            children[index].gameObject.SetActive(value);
        }
    }

}
