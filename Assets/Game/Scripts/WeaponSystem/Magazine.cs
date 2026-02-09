using System;
using System.Collections;
using UnityEngine;

public sealed class Magazine
{
    private ReactiveVariable<int> _bullets;
    private ReactiveVariable<int> _size;

    private MonoBehaviour _context;

    private float _reloadTime;

    public bool IsEmpty => _bullets.Value <= 0;
    public bool IsReloading {get; private set;}

    public IReactiveVariable<int> Bullets => _bullets;
    public IReactiveVariable<int> Size => _size;

    public Magazine(MonoBehaviour context, int size, float reloadTime)
    {
        if(size <= 0) throw new ArgumentOutOfRangeException(nameof(size));
        if(reloadTime <= 0) throw new ArgumentOutOfRangeException(nameof(reloadTime));

        _context = context;
        _size = new(size);
        _bullets = new(_size.Value);
        _reloadTime = reloadTime;
    }

    public void OnShooted()
    {
        if(IsEmpty) return;

        _bullets.Value--;
    }

    public void Reload()
    {
        if(IsReloading) return;

        _context.StartCoroutine(ReloadOperation());
    }

    private IEnumerator ReloadOperation()
    {
        IsReloading = true;

        yield return new WaitForSeconds(_reloadTime);
        _bullets.Value = _size.Value;
        IsReloading = false;
        Debug.Log($"I reloaded: {Bullets.Value}/{Size.Value}");
    }
}
