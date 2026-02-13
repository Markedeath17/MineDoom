using System;

public class ReactiveVariable<T> : IReactiveVariable<T>
{
    public event Action<T> Changed;

    private T _value;

    public ReactiveVariable(T value = default)
    {
        _value = value;
    }

    public T Value
    {
        get => _value;
        set
        {
            _value = value;
            Changed?.Invoke(_value);
        }
    }
}
