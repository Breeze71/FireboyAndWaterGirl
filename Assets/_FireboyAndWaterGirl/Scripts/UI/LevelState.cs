using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelState : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefs.SetString("Lv0", "Successed");
    }
    
}
