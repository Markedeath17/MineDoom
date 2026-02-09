using System;
using UnityEngine;

public sealed class InputController : MonoBehaviour
{
    private IMoveable _player;
    private PauseManager _pauseManager;
    private BaseGun _baseGun;

    private PlayerInput _actions;

    public void Initialize(IMoveable player, PauseManager pauseManager, BaseGun baseGun)
    {
        _player = player;
        _pauseManager = pauseManager;
        _baseGun = baseGun;

        _baseGun.Initialize();

        _actions = new();
        _actions.Enable();

        _actions.Weapon.Attack.performed += AttackButtonPerformed;
        _actions.Weapon.Attack.canceled += AttackButtonCanceled;
        _actions.Weapon.Reload.performed += ReloadButtonPerformed;

        _actions.Player.Pause.performed += PauseButtonPerformed;
    }

    private void AttackButtonPerformed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        _baseGun.AttackButtonPerformed();
    }

    private void AttackButtonCanceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        _baseGun.AttackButtonCanceled();
    }

    private void ReloadButtonPerformed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        _baseGun.Reload();
    }

    private void PauseButtonPerformed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        _pauseManager.ChangeState();
    }

    private void Update()
    {
        if(_pauseManager.IsPause.Value) return;

        _player.Move(_actions.Player.Move.ReadValue<Vector2>());

    }

    private void LateUpdate()
    {
        if(_pauseManager.IsPause.Value) return;

        _player.Look(_actions.Player.Look.ReadValue<Vector2>());
    }

    private void OnDestroy()
    {
        _actions.Weapon.Attack.performed -= AttackButtonPerformed;
        _actions.Weapon.Attack.canceled -= AttackButtonCanceled;
        _actions.Weapon.Reload.performed -= ReloadButtonPerformed;

        _actions.Player.Pause.performed -= PauseButtonPerformed;
    }
}
