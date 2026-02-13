using System;
using UnityEngine;

public interface IReactiveVariable<T>
{
    T Value {get;}
    event Action<T> Changed;
}
