using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    [SerializeField] private PauseView _pauseView;
    [SerializeField] private PlayerHealthView _playerHealthView;

    private PauseManager _pauseManager;
    private Health _health;

    private void Awake()
    {
        PlayerInput inputActions = new();
        inputActions.Enable();

        _health = new(100);
        _playerHealthView.Initialize(_health.Current, _health.Max);

        _pauseManager = new(inputActions);
        _pauseView.Initialize(_pauseManager.IsPause);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            _health.Reduce(10);
        }
    }

    private void OnDestroy()
    {
        _pauseManager.Dispose();
    }
}
