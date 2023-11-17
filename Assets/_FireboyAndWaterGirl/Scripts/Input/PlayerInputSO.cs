using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 處理玩家 Gameplay 輸入以及 data 
/// </summary>
[CreateAssetMenu(menuName = "ScriptableObject/PlayerSO/Input", order = 0)]
public class PlayerInputSO : ScriptableObject
{
    public KeyCode LeftKey;
    public KeyCode RightKey;
    public KeyCode JumpKey;

    public float AccSpeed;
    public float MaxMoveSpeed;
    public float JumpForce;    

    #region Player Input
    /// <summary>
    /// 移动输入
    /// </summary>
    public int HandleXInput()
    {
        int _xInput;

        if(Input.GetKey(LeftKey))
        {
            _xInput = -1;
        }  
        else if(Input.GetKey(RightKey))
        {
            _xInput = 1;
        }    
        else
        {
            _xInput = 0;
        }

        return _xInput;
    }

    /// <summary>
    /// 跳跃输入
    /// </summary>
    public bool HandleJumpInput()
    {
        bool _isJumpKeyDown = false;

        if(Input.GetKeyDown(JumpKey))
        {
            _isJumpKeyDown = true;
        }
        else if(Input.GetKeyUp(JumpKey))
        {
            _isJumpKeyDown = false;
        }

        return _isJumpKeyDown;
    }
    #endregion
}
