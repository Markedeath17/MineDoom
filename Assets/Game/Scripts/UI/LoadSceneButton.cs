using UnityEngine;

public sealed class LoadSceneButton : BaseButton
{
    [SerializeField] private SceneConfig _config;

    public override void OnClick()
    {
        SceneLoader loader = new(_config);
        loader.Load();
    }
}
