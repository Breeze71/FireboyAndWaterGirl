using System;
using UnityEngine;

public class PlayerEvent
{
    private int currentEnterdoor = 0;

    public event Action OnPlayerDead;
    public void PlayerDeadEvent()
    {
        OnPlayerDead?.Invoke();
    }

    public event Action OnEnterDoor;
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

    public event Action OnExitDoor;
    public void ExitDoor()
    {
        OnExitDoor?.Invoke();
        currentEnterdoor--;
    }

    public event Action OnPlayerWin;
    #region Kaofish interface to _win
    //public int CurrententerDoor()
    //{
    //    return currentEnterdoor;
    //}
    #endregion
}
