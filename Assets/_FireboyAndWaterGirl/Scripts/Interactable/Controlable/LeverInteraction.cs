using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// 判斷角色在保持触碰时由锐角侧向钝角侧移动
/// </summary>
public class LeverInteraction : InteractableBase
{    
    [SerializeField, Tooltip("控制的機關")] private GameObject controllMachine;
    [SerializeField] private GameObject leverRotate;

    private ControlState leverState = ControlState.Disable;



    public override void EnterTrigger(Collider2D _other)
    {
        Vector2 _triggerDirection = (coll.bounds.center - _other.transform.position).normalized;

        if(leverState == ControlState.Disable && _triggerDirection.x < 0)
        {
            leverState = ControlState.Enable;

            controllMachine.GetComponent<IControlable>().OnIsEnableEvent(true);

            // 左至右動畫
            leverRotate.transform.DORotate(new Vector3(0, 0, 45f), 1f);
        }

        else if(leverState == ControlState.Enable && _triggerDirection.x > 0)
        {
            leverState = ControlState.Disable;

            controllMachine.GetComponent<IControlable>().OnIsEnableEvent(false);

            // 右至左動畫
            leverRotate.transform.DORotate(new Vector3(0, 0, -45f), 1f);
        }
    }

    public override void ExitTrigger(Collider2D _other)
    {
        
    }

    public override void Interact()
    {
        
    }
}
