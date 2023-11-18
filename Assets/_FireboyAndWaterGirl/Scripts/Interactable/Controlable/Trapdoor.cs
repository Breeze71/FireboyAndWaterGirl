using System;
using DG.Tweening;
using UnityEngine;

/// <summary>
/// 活板门
/// </summary>
public class Trapdoor : MonoBehaviour, IControlable
{
    public event Action<bool> OnIsEnable;

    [SerializeField] private GameObject trapdoor;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform openTransform;
    [SerializeField] private Transform closeTransform;

    private void Start() 
    {
        OnIsEnable += Trapdoor_ChangeActiveEvent;
    }
    private void OnDisable() 
    {
        OnIsEnable -= Trapdoor_ChangeActiveEvent;  
    }

    /// <summary>
    /// Invoke Event
    /// </summary>
    public void OnIsEnableEvent(bool _isEnable)
    {
        OnIsEnable?.Invoke(_isEnable);
    }

    /// <summary>
    /// Recive Event
    /// </summary>
    private void Trapdoor_ChangeActiveEvent(bool _isEnable)
    {
        if(_isEnable)
        {
            trapdoor.transform.DOMove(openTransform.position, 2f / moveSpeed);
        }   
        else
        {
            trapdoor.transform.DOMove(closeTransform.position, 2f / moveSpeed);
        }         
    }
}
