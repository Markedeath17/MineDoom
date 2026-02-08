using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform _body;

    [Header("Camera settings")]
    [SerializeField][Range(0, -90)] private float _upViewAngle;
    [SerializeField][Range(0, 90)] private float _downViewAngle;
    [SerializeField][Min(1)] private float _sensitivity;

    private PlayerInput _actions;

    private float _xRotation;

    private Vector2 Input => _actions.Player.Look.ReadValue<Vector2>();

    public void Initialize(PlayerInput actions)
    {
        _actions = actions;
    }

    public void Look()
    {
        _xRotation -= Input.y * _sensitivity * Time.deltaTime;
        _xRotation = Mathf.Clamp(_xRotation, _upViewAngle, _downViewAngle);

        transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        _body.Rotate(Vector2.up * Input.x * _sensitivity * Time.deltaTime);
    }
}
