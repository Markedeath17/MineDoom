using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    [SerializeField] private PauseView _pauseView;

    private PauseManager _pauseManager;

    private void Awake()
    {
        PlayerInput inputActions = new();
        inputActions.Enable();

        _pauseManager = new(inputActions);
        _pauseView.Initialize(_pauseManager.IsPause);
    }

    private void OnDestroy()
    {
        _pauseManager.Dispose();
    }
}
