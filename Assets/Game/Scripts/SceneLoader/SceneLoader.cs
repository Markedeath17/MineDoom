using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class SceneLoader
{
    private SceneConfig _config;
    private Scene _current;

    public SceneLoader(SceneConfig config)
    {
        _config = config;
        _current = SceneManager.GetActiveScene();
    }

    public async void Load()
    {
        await SceneManager.LoadSceneAsync(_config.Name, LoadSceneMode.Additive);
        OnSceneLoaded();
    }

    private void OnSceneLoaded() => SceneManager.UnloadSceneAsync(_current);
}