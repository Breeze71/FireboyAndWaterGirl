using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 冰人或火人踩到會死的 Pool
/// </summary>
public class PoolInteraction : InteractableBase
{
    #region Kaofish
    //[SerializeField]
    //private UnityEvent _Dead;
    #endregion
    public override void EnterTrigger(Collider2D _other)
    {
        // character dead
        GameEventManager.Instance.playerEvent.PlayerDeadEvent();
        #region Kaofish
        //_Dead?.Invoke();
        #endregion
    }

    public override void ExitTrigger(Collider2D _other)
    {
        
    }

    public override void Interact()
    {
        
    }
}
