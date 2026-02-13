public sealed class PauseManager
{
    private ReactiveVariable<bool> _isPause;

    public PauseManager(bool startValue = default)
    {
        _isPause = new(startValue);
    }

    public IReactiveVariable<bool> IsPause => _isPause;

    public void ChangeState()
    {
        _isPause.Value = !_isPause.Value;
    }
}
