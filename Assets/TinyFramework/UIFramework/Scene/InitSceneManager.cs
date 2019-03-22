using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitSceneManager : MonoBehaviour
{
    // Use this for initialization
    [SerializeField] private GameObject m_SystemRoot;
    [SerializeField] private String m_NextScene;

    void Start()
    {
        DontDestroyOnLoad(m_SystemRoot);
        if (string.IsNullOrEmpty(GemeApplication.RequestingScene))
        {
            GemeApplication.RequestingScene = m_NextScene;
            SceneManager.LoadScene(m_NextScene);
        }
        else
        {
            SceneManager.LoadScene(GemeApplication.RequestingScene);
        }
    }
}