using UnityEngine;

/// <summary>
/// 寶石收集
/// </summary>
public class CollectGemsInteraction : InteractableBase
{
    public override void EnterTrigger(Collider2D _other)
    {
        GameEventManager.Instance.gemEvent.CollectedGemEvent();
        
        Destroy(gameObject);
    }

    public override void ExitTrigger(Collider2D _other)
    {
        
    }

    public override void Interact()
    {
        
    }
}

