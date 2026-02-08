using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController _controller;
    private PlayerInput _actions;

    private float _speed;

    private Vector2 Input => _actions.Player.Move.ReadValue<Vector2>();

    private Vector3 Direction => transform.forward * Input.y + transform.right * Input.x;

    public void Initialize(PlayerInput actions, float speed)
    {
        _controller = GetComponent<CharacterController>();
        _actions = actions;

        _speed = speed;
    }

    public void Move()
    {
        _controller.Move(Direction * _speed * Time.deltaTime);
    }
}
