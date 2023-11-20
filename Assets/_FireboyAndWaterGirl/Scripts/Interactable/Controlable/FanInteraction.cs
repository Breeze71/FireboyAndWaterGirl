using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 鼓风机
/// </summary>
public class FanInteraction : InteractableBase, IControlable
{
    public event Action<bool> OnIsEnable;   // IControlable

    [SerializeField] private float fanForce;
    [SerializeField] private ParticleSystem windParticle;

    private List<Movement> movementList = new List<Movement>();

    private bool isEnable = false;

    private void Start() 
    {
        OnIsEnable += FanInteraction_OnIsEnable;
    }
    private void OnDisable() 
    {
        OnIsEnable -= FanInteraction_OnIsEnable;  
    }

    /// <summary>
    /// Invoke Event
    /// </summary>    
    public void OnIsEnableEvent(bool _isEnable)
    {
        OnIsEnable?.Invoke(_isEnable);
    }

    /// <summary>
    /// Recive isEnable Event
    /// </summary>
    private void FanInteraction_OnIsEnable(bool _isEnable)
    {
        isEnable = _isEnable;

        if(_isEnable)
        {
            windParticle.gameObject.SetActive(true);
        }
        else
        {
            windParticle.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (isEnable && canInteract)
        {
            Interact();
        }
    }

    #region InteractableBase
    public override void Interact()
    {   
        foreach(Movement _movement in movementList)
        {
            _movement.rb.AddForce(fanForce * Vector2.up, ForceMode2D.Force);
        }
    }

    public override void EnterTrigger(Collider2D _other)
    {
        // 獲取所有進入範圍的 Character
        Movement _player = _other.GetComponent<Movement>();
        movementList.Add(_player);
    }
    public override void ExitTrigger(Collider2D _other)
    {
        Movement _player = _other.GetComponent<Movement>();
        movementList.Remove(_player);        
    }
    #endregion
}
