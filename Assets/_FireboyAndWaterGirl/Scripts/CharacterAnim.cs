using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色動畫
/// </summary>
public class CharacterAnim : MonoBehaviour
{
    private const string IsRunning = "IsRunning";
    private const string YVelocity = "YVelocity";

    [SerializeField] private Movement movement;
    private Animator anim;

    private void Awake() 
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetBool(IsRunning, movement.IsWalking());
        anim.SetFloat(YVelocity, movement.ReturnYVelocity());
    }
}
