using UnityEngine;

public class TestEnemy : MonoBehaviour, IDamageable
{
    [SerializeField] private float _startHealth;

    private Health _health;

    void Awake()
    {
        _health = new(_startHealth);
    }

    void IDamageable.TakeDamage(float damage)
    {
        _health.Reduce(damage);
        Debug.Log($"I took damage, health left: {_health.Current.Value}/{_health.Max.Value}");

        if(_health.Current.Value <= 0)
        {
            Destroy(gameObject);
        }
    }
}
