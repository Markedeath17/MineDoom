using System;
using UnityEngine;

public class PauseManager : IDisposable
{
    private PlayerInput _inputs;

    private ReactiveVariable<bool> _isPause;

    public IReactiveVariable<bool> IsPause => _isPause;

    public PauseManager(PlayerInput inputs, bool defaultState = default)
    {
        _inputs = inputs;
        _inputs.Player.Pause.performed += OnPauseButtonPressed;

        _isPause = new(defaultState);

        Debug.Log($"Is pause: {_isPause.Value}");
    }

    private void OnPauseButtonPressed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        _isPause.Value = !_isPause.Value;
        Debug.Log($"Is pause: {_isPause.Value}");
    }

    public void Dispose()
    {
        _inputs.Player.Pause.performed -= OnPauseButtonPressed;
    }
}
