using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private PauseView _pauseView;
    [SerializeField] private PlayerHealthView _playerHealthView;

    [Header("Others")]
    [SerializeField] private InputController _inputController;
    [SerializeField] private Player _player;
    [SerializeField] private BaseGun _baseGun;

    private PauseManager _pauseManager;

    private void Awake()
    {
        _pauseManager = new();

        _player.Initialize(_pauseManager);

        _inputController.Initialize(_player, _pauseManager, _baseGun);

        //UI
        _pauseView.Initialize(_pauseManager.IsPause);
        _playerHealthView.Initialize(_player.CurrentHealth, _player.MaxHealth);
    }
}
