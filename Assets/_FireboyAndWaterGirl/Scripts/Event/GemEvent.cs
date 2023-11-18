using System;
using UnityEngine;

public class GemEvent
{
    /// <summary>
    /// 當前關卡寶石數量
    /// </summary>
    public int currentGems{ get; private set;} = 0;


    public event Action OnGemCollected;
    public void CollectedGemEvent() 
    {
        OnGemCollected?.Invoke();
        currentGems++;
    }    

    public event Action OnAllGemsCollected;
    public void CollectAllGemsEvent()
    {
        OnAllGemsCollected?.Invoke();
    }
}
