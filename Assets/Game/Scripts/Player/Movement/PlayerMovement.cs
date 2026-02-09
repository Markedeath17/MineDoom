using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController _controller;

    private float _speed;

    public void Initialize(float speed)
    {
        _controller = GetComponent<CharacterController>();

        _speed = speed;
    }

    public void Move(Vector2 input)
    {
        Vector3 direction = transform.forward * input.y + transform.right * input.x;

        _controller.Move(direction.normalized * _speed * Time.deltaTime);
    }
}
