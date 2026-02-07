using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    private PauseManager _pauseManager;

    private void Awake()
    {
        PlayerInput inputActions = new();
        inputActions.Enable();

        _pauseManager = new(inputActions);
    }

    private void OnDestroy()
    {
        _pauseManager.Dispose();
    }
}
