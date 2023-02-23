using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    RectTransform[] StartScreenComponents;

    private void Awake()
    {
        StartScreenComponents = this.GetComponentsInChildren<RectTransform>(true);
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
        for(int index = 1; index < StartScreenComponents.Length; index ++)
        {
            StartScreenComponents[index].gameObject.SetActive(value);
        }
    }

}
