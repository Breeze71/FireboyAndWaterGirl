using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

/// <summary>
/// Facing Direction
/// </summary>
public enum FaceDirection
{
    None = 0,
    Left = -1,
    Right = 1,
}

/// <summary>
/// Character Movement
/// </summary>
public class Movement : MonoBehaviour
{
    [SerializeField] private PlayerInputSO inputSO;
    [SerializeField] private GameObject groundCheck;
    [SerializeField] private Animator anim;
    
    public Rigidbody2D rb { get; private set;}
    private int xInput;
    private bool isJumpKeyDown;
    private bool canMove;

    private FaceDirection facingDirection;


    #region Unity
    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();    
    }
    private void Start() 
    {
        canMove = true;
        facingDirection = FaceDirection.None;

        GameEventManager.Instance.playerEvent.OnPlayerDead += PlayerEvent_PlayerDeadEvent;
        GameEventManager.Instance.playerEvent.OnPlayerResume += PlayerEvent_PlayerResumeEvent;
        GameEventManager.Instance.playerEvent.OnPlayerOpenMenu += PlayerEvent_OnPlayerOpenMenu;
    }

    private void Update() 
    {
        if(!canMove)
        {
            return;
        }

        xInput = inputSO.HandleXInput();    
        isJumpKeyDown = inputSO.HandleJumpInput();

        Walk();
        Jump();
        BetterJump();

        CheckFlip();
    }
    private void OnDestroy() 
    {
        GameEventManager.Instance.playerEvent.OnPlayerDead -= PlayerEvent_PlayerDeadEvent;   
    }
    #endregion

    #region Event
    private void PlayerEvent_PlayerDeadEvent()
    {
        canMove = false;
    }
    private void PlayerEvent_OnPlayerOpenMenu()
    {
        canMove = false;
    }

    private void PlayerEvent_PlayerResumeEvent()
    {
        canMove = true;
    }
    #endregion

    #region Walk And Jump
    /// <summary>
    /// 角色从 0 到加速/减少到目标速度的加速度
    /// </summary>
    private void Walk()
    {
        Vector2 _targetVelocity = Vector2.zero;

        _targetVelocity = new Vector2(xInput * inputSO.MaxMoveSpeed, rb.velocity.y);

        rb.velocity = Vector2.Lerp(rb.velocity, _targetVelocity, inputSO.AccSpeed * Time.deltaTime);
    }

    /// <summary>
    /// 跳跃方法
    /// </summary>
    private void Jump()
    {
        if(IsOnGround() && isJumpKeyDown)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.velocity += Vector2.up * inputSO.JumpForce;
        }
    }
    private void BetterJump()
    {
        if(rb.velocity.y > 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (inputSO.lowJumpMutiplier - 1) * Time.deltaTime;
        }
    }
    #endregion

    #region Facing Diretion
    private void CheckFlip()
    {
        if(xInput != 0 && xInput != (int)facingDirection)
        {
            Flip();
        }
    }

    private void Flip()
    {
        if(facingDirection.Equals(FaceDirection.Left))
        {
            facingDirection = FaceDirection.Right;
        }
        else
        {
            facingDirection = FaceDirection.Left;
        }

        transform.Rotate(0f , 180f , 0f);        
    }
    #endregion

    #region 传递出的 Interface
    public bool IsWalking()
    {
        return xInput != 0;
    }
    public float ReturnYVelocity()
    {
        return rb.velocity.y;
    }

    /// <summary>
    /// 停止玩家移动
    /// </summary>
    public void DisableMovement()
    {
        canMove = false;
    }
    /// <summary>
    /// 启用玩家移动
    /// </summary>
    public void EnableMovement()
    {
        canMove = true;
    }
    #endregion
    

    /// <summary>
    /// Ground Check
    /// </summary>
    private bool IsOnGround()
    {
        return groundCheck.GetComponent<ICheck>().Check();
    }
}


