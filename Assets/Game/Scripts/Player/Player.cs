using UnityEngine;

public sealed class Player : MonoBehaviour, IDamageable
{
    [Header("References")]
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private PlayerCamera _camera;

    [Header("Player settings")]
    [SerializeField] private float _speed;

    [SerializeField] private float _startHealth;

    private PlayerInput _actions;
    private PauseManager _pauseManager;
    private Health _health;

    private bool IsPause => _pauseManager.IsPause.Value;

    public IReactiveVariable<float> CurrentHealth => _health.Current;
    public IReactiveVariable<float> MaxHealth => _health.Max;

    public void Initialize(PlayerInput actions, PauseManager pauseManager)
    {
        _actions = actions;
        _pauseManager = pauseManager;
        _health = new(_startHealth);

        _movement.Initialize(_actions, _speed);
        _camera.Initialize(_actions);
    }

    private void Update()
    {
        if(IsPause)
            return;

        Move();
    }

    private void LateUpdate()
    {
        if(IsPause)
            return;

        Look();
    }

    private void Move()
    {
        _movement.Move();
    }

    private void Look()
    {
        _camera.Look();
    }

    void IDamageable.TakeDamage(float damage)
    {
        _health.Reduce(damage);
    }
}
