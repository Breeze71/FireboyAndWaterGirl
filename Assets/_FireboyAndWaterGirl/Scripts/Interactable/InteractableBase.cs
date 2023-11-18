using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 進入範圍的 基類
/// </summary>
[RequireComponent(typeof(Collider2D))]
public abstract class InteractableBase : MonoBehaviour
{
    [SerializeField, Tooltip("可互動的 Layer")] protected LayerMask interactLayer;

    protected bool canInteract;
    protected Collider2D coll;
    private void Start() 
    {
        coll = GetComponent<Collider2D>();    
    }

    /// <summary>
    /// 進入範圍時調用
    /// </summary>
    public abstract void EnterTrigger(Collider2D _other);
    /// <summary>
    /// 於 Update 中調用
    /// </summary>
    public abstract void Interact();
    /// <summary>
    /// 離開範圍時調用
    /// </summary>
    public abstract void ExitTrigger(Collider2D _other);

    protected virtual void OnTriggerEnter2D(Collider2D _other)
    {
        if ((interactLayer.value & (1 << _other.gameObject.layer)) > 0)
        {
            canInteract = true;

            EnterTrigger(_other);
        }
    }
    protected virtual void OnTriggerExit2D(Collider2D _other)
    {
        if ((interactLayer.value & (1 << _other.gameObject.layer)) > 0)
        {
            canInteract = false;

            ExitTrigger(_other);
        }
    }
}
