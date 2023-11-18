using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadTest : MonoBehaviour
{
    private void Start() 
    {
        GameEventManager.Instance.playerEvent.OnPlayerDead += PlayerEvent_OnPlayerDead;
    }

    private void PlayerEvent_OnPlayerDead()
    {
        Debug.LogWarning("Player Dead");
    }
}
