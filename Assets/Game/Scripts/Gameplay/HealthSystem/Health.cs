using System;

public sealed class Health 
{
    private ReactiveVariable<float> _current;
    private ReactiveVariable<float> _max;

    public Health(float max)
    {
        if(max <= 0) throw new ArgumentOutOfRangeException($"Value can`t be 0 or less: {nameof(max)}");

        _max = new(max);
        _current = new(max);
    }

    public IReactiveVariable<float> Current => _current;
    public IReactiveVariable<float> Max => _max;

    public void Reduce(float value)
    {
        if(value < 0) throw new ArgumentOutOfRangeException($"Value can`t be less than 0: {nameof(value)}");

        if(_current.Value - value < 0)
        {
            float newValue = _current.Value;
            _current.Value -= newValue;
            return;
        }

        _current.Value -= value;
    }
}
