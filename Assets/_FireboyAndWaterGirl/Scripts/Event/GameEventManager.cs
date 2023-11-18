using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 管理遊戲中僅需實例化一個的事件，例如寶石收集，UI開關 etc
/// </summary>
public class GameEventManager : MonoBehaviour
{
    public static GameEventManager Instance { get; set; }

    public GemEvent gemEvent;
    public PlayerEvent playerEvent;

    private void Awake() 
    {
        if(Instance != null)
        {
            Debug.LogError("More than One GameEvent Manager");
        }    
        Instance = this;

        gemEvent = new GemEvent();
        playerEvent = new PlayerEvent();
    }
}
