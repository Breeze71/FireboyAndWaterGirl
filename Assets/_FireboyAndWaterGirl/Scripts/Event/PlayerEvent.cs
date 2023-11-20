using System;
using UnityEngine;

public class PlayerEvent
{
    private int currentEnterdoor = 0;

    /// <summary>
    /// Player Dead
    /// </summary>
    public event Action OnPlayerDead;
    public void PlayerDeadEvent()
    {
        OnPlayerDead?.Invoke();
    }

    /// <summary>
    /// Player Enter Door
    /// </summary>
    public event Action OnEnterDoor;
    public event Action OnPlayerWin;
    public void EnterDoor()
    {
        OnEnterDoor?.Invoke();
        currentEnterdoor++;

        if(currentEnterdoor == 2)
        {
            Debug.Log("You Win");
            OnPlayerWin?.Invoke();
        }
    }

    /// <summary>
    /// Exit Door
    /// </summary>
    public event Action OnExitDoor;
    public void ExitDoor()
    {
        OnExitDoor?.Invoke();
        currentEnterdoor--;
    }

    public event Action OnPlayerResume;
    public void PlayerResumeEvent()
    {
        OnPlayerResume?.Invoke();
    }

    public event Action OnPlayerOpenMenu;
    public void PlayerOpenMenuEvent()
    {
        OnPlayerOpenMenu?.Invoke();
    }

    #region Kaofish interface to _win
    //public int CurrententerDoor()
    //{
    //    return currentEnterdoor;
    //}
    #endregion
}
