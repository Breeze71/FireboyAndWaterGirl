
using System;

/// <summary>
/// 一切機關皆用 IsEnable 控制啟用
/// </summary>
public interface IControlable
{
    public event Action<bool> OnIsEnable;

    public void OnIsEnableEvent(bool _isEnable);
}
