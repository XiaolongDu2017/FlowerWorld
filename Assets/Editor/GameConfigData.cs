using System;
using System.Collections.Generic;
using UnityEditor;
using LitJson;
using UnityEngine;
using System.IO;
using System.Text;

public class GameConfigData : Editor
{
    [MenuItem("Game/清理数据")]
    static void ClearAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}