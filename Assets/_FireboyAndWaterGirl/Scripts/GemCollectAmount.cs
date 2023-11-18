using UnityEngine;

public class GemCollectAmount : MonoBehaviour
{
    private int currentGems = 0;
    [SerializeField, Tooltip("最大可獲得寶石")] private int gemsMax = 5;

    public void Start()
    {
        GameEventManager.Instance.gemEvent.OnGemCollected += GemEvent_OnGemCollected;
    }

    private void GemEvent_OnGemCollected()
    {
        if(currentGems < gemsMax)
        {
            currentGems++;
            Debug.Log("current gems" + currentGems);
        }

        if(currentGems >= gemsMax)
        {
            GameEventManager.Instance.gemEvent.CollectAllGemsEvent();
        }
    } 
}
