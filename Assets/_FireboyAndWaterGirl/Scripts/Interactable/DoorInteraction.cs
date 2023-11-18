using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : InteractableBase
{
    public override void EnterTrigger(Collider2D _other)
    {
        GameEventManager.Instance.playerEvent.EnterDoor();
    }

    public override void ExitTrigger(Collider2D _other)
    {
        GameEventManager.Instance.playerEvent.ExitDoor();
    }

    public override void Interact()
    {
        
    }
}
