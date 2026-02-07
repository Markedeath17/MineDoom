using System;

public interface IReactiveVariable<T>
{
    event Action<T> Changed;
    T Value {get;}
}
