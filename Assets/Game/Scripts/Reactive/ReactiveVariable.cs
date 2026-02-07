using System;

public class ReactiveVariable<T> : IReactiveVariable<T>
{
    public event Action<T> Changed;

    private T _value;

    public ReactiveVariable()
    {
        _value = default;
    }

    public ReactiveVariable(T value)
    {
        _value = value;
    }

    public T Value
    {
        get
        {
            return _value;
        }
        set
        {
            _value = value;
            Changed?.Invoke(_value);
        }
    }
}
