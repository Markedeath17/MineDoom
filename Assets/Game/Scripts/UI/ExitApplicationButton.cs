using UnityEngine;

public sealed class ExitApplicationButton : BaseButton
{
    public override void OnClick()
    {
        Application.Quit();
    }
}
