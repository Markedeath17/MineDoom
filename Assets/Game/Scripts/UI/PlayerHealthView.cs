using UnityEngine;
using TMPro;

public class PlayerHealthView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _view;

    private IReactiveVariable<float> _current;
    private IReactiveVariable<float> _max;

    public void Initialize(IReactiveVariable<float> current, IReactiveVariable<float> max)
    {
        _current = current;
        _max = max;

        _current.Changed += CurrentHealthChanged;
        _max.Changed += MaxHealthChanged;

        UpdateUI();
    }

    private void MaxHealthChanged(float obj)
    {
        UpdateUI();
    }

    private void CurrentHealthChanged(float obj)
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        _view.text = $"{_current.Value}/{_max.Value}";
    }

    private void OnDestroy()
    {
        _current.Changed -= CurrentHealthChanged;
        _max.Changed -= MaxHealthChanged;
    }
}
