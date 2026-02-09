using UnityEngine;

public class PauseManager 
{
    private ReactiveVariable<bool> _isPause;

    public IReactiveVariable<bool> IsPause => _isPause;

    public PauseManager(bool defaultState = default)
    {
        _isPause = new(defaultState);

        Debug.Log($"Is pause: {_isPause.Value}");
    }

    public void ChangeState()
    {
        _isPause.Value = !_isPause.Value;
        Debug.Log($"Is pause: {_isPause.Value}");
    }
}
