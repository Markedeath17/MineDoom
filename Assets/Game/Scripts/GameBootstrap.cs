using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    [SerializeField] private PauseView _pauseView;
    [SerializeField] private PlayerHealthView _playerHealthView;

    [SerializeField] private Player _player;

    private PauseManager _pauseManager;

    private void Awake()
    {
        PlayerInput inputActions = new();
        inputActions.Enable();



        _pauseManager = new(inputActions);
        _pauseView.Initialize(_pauseManager.IsPause);

        _player.Initialize(inputActions, _pauseManager);
        _playerHealthView.Initialize(_player.CurrentHealth, _player.MaxHealth);
    }

    private void OnDestroy()
    {
        _pauseManager.Dispose();
    }
}
