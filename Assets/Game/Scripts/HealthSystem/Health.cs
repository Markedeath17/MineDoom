using System;

public class Health
{
    private ReactiveVariable<float> _current; 
    private ReactiveVariable<float> _max;

    public Health(float startValue)
    {
        if(startValue <= 0) 
            throw new ArgumentOutOfRangeException($"Invalid param [{nameof(startValue)}]: {startValue}");

        _max = new(startValue);
        _current = new(startValue);
    }

    public IReactiveVariable<float> Current => _current;
    public IReactiveVariable<float> Max => _max;

    public void Reduce(float value)
    {
         if(value <= 0) 
            throw new ArgumentOutOfRangeException($"Invalid param [{nameof(value)}]: {value}");

        _current.Value -= value;
    }

}
