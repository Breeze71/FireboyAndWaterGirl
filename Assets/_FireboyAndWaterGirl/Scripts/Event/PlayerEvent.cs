using System;

public class PlayerEvent
{
    public event Action OnPlayerDead;
    public void PlayerDeadEvent()
    {
        OnPlayerDead?.Invoke();
    }

    public event Action OnFireboyEnterDoor;
    public void FireboyEnterDoor()
    {

    }
}
