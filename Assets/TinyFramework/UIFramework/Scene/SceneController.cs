using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SceneController : MonoBehaviour
{
    void Awake()
    {
#if UNITY_EDITOR
        if (Application.loadedLevelName != GemeApplication.RequestingScene &&
            string.IsNullOrEmpty(GemeApplication.RequestingScene))
        {
            GemeApplication.RequestingScene = Application.loadedLevelName;
            Application.LoadLevel(GemeApplication.InitSceneName);
        }
#endif
    }
}
