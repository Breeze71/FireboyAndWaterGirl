using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ButtonInteraction : InteractableBase
{    
    [SerializeField, Tooltip("控制的機關")] private GameObject controllMachine;
    [SerializeField] private GameObject buttonVisual;
    [SerializeField] private Transform openTransform;
    [SerializeField] private Transform closeTransform;


    public override void EnterTrigger(Collider2D _other)
    {
        controllMachine.GetComponent<IControlable>().OnIsEnableEvent(true);

        // 下降
        buttonVisual.transform.DOMove(openTransform.position, 1f);
    }


    public override void ExitTrigger(Collider2D _other)
    {
        controllMachine.GetComponent<IControlable>().OnIsEnableEvent(false);

        // 上升    
        buttonVisual.transform.DOMove(closeTransform.position, 1f); 
    }

    public override void Interact()
    {
        
    }


}
