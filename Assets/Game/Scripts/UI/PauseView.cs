using TMPro;
using UnityEngine;

public class PauseView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _view;

    private IReactiveVariable<bool> _isPause;

    public void Initialize(IReactiveVariable<bool> isPause)
    {
        _isPause = isPause;
        isPause.Changed += Changed;

        Changed(_isPause.Value);
    }

    private void Changed(bool obj)
    {
        _view.gameObject.SetActive(obj);        
    }

    private void OnDestroy()
    {
        _isPause.Changed -= Changed;
    }

}
