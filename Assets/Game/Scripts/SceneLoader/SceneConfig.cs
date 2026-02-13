using UnityEngine;

[CreateAssetMenu(fileName = "Scene", menuName = "Scenes/New Scene", order = 1)]
public sealed class SceneConfig : ScriptableObject
{
    [SerializeField] private string _name;

    public string Name => _name;
}
