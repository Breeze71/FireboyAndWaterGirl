using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 冰人或火人踩到會死的 Pool
/// </summary>
public class PoolInteraction : InteractableBase
{
    public override void EnterTrigger(Collider2D _other)
    {
        // character dead
        GameEventManager.Instance.playerEvent.PlayerDeadEvent();
    }

    public override void ExitTrigger(Collider2D _other)
    {
        
    }

    public override void Interact()
    {
        
    }
}
