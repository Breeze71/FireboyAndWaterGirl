using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private PlayerInputSO inputSO;
    [SerializeField] private GameObject groundCheck;
    

    private Rigidbody2D rb;
    private int xInput;
    private bool isJumpKeyDown;
    private int facingDirection;

    /// <summary>
    /// 暫停或死亡時 = false
    /// </summary>
    private bool canMove;

    /// <summary>
    /// anim
    /// </summary>
    [SerializeField] private Animator anim;


    #region Unity
    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();    
    }
    private void Start() 
    {
        canMove = true;
        facingDirection = 1;
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

        CheckFlip();
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
    #endregion

    #region Facing Diretion
    private void CheckFlip()
    {
        if(xInput != 0 && xInput != facingDirection)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingDirection *= -1;

        transform.Rotate(0f , 180f , 0f);        
    }
    #endregion

    #region 傳遞給 CharacterAnimtor 的 Interface
    public bool IsWalking()
    {
        return xInput != 0;
    }
    public float ReturnYVelocity()
    {
        return rb.velocity.y;
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
