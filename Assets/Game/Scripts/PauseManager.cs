using System;
using UnityEngine;

public class PauseManager : IDisposable
{
    private PlayerInput _inputs;

    public bool IsPause {get; private set;}

    public PauseManager(PlayerInput inputs, bool defaultState = default)
    {
        _inputs = inputs;
        _inputs.Player.Pause.performed += OnPauseButtonPressed;

        IsPause = defaultState;
        Debug.Log($"Is pause: {IsPause}");
    }

    private void OnPauseButtonPressed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        IsPause = !IsPause;
        Debug.Log($"Is pause: {IsPause}");
    }

    public void Dispose()
    {
        _inputs.Player.Pause.performed -= OnPauseButtonPressed;
    }
}
