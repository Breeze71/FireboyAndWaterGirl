using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorInteraction : InteractableBase
{
    #region Kaofish
    //[SerializeField]
    //private UnityEvent _Win;
    #endregion
    public override void EnterTrigger(Collider2D _other)
    {
        GameEventManager.Instance.playerEvent.EnterDoor();
        #region Kaofish
        //if (GameEventManager.Instance.playerEvent.CurrententerDoor() == 2)
        //    _Win?.Invoke();
        #endregion
    }

    public override void ExitTrigger(Collider2D _other)
    {
        GameEventManager.Instance.playerEvent.ExitDoor();
    }

    public override void Interact()
    {
        
    }
}
