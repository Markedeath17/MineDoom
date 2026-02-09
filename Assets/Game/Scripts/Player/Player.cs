using UnityEngine;

public sealed class Player : MonoBehaviour, IMoveable ,IDamageable
{
    [Header("References")]
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private PlayerCamera _camera;

    [Header("Player settings")]
    [SerializeField] private float _speed;

    [SerializeField] private float _startHealth;

    private PauseManager _pauseManager;
    private Health _health;

    private bool IsPause => _pauseManager.IsPause.Value;

    public IReactiveVariable<float> CurrentHealth => _health.Current;
    public IReactiveVariable<float> MaxHealth => _health.Max;

    public void Initialize(PauseManager pauseManager)
    {
        _pauseManager = pauseManager;
        _health = new(_startHealth);

        _movement.Initialize(_speed);
        _camera.Initialize();
    }

    void IMoveable.Move(Vector2 input)
    {
        _movement.Move(input);
    }

    void IMoveable.Look(Vector2 input)
    {
        _camera.Look(input);
    }

    void IDamageable.TakeDamage(float damage)
    {
        _health.Reduce(damage);
    }
}
