using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform _body;

    [Header("Camera settings")]
    [SerializeField][Range(0, -90)] private float _upViewAngle;
    [SerializeField][Range(0, 90)] private float _downViewAngle;
    [SerializeField][Min(1)] private float _sensitivity;

    private float _xRotation;

    public void Initialize()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Look(Vector2 input)
    {
        _xRotation -= input.y * _sensitivity * Time.deltaTime;
        _xRotation = Mathf.Clamp(_xRotation, _upViewAngle, _downViewAngle);

        transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        _body.Rotate(Vector2.up * input.x * _sensitivity * Time.deltaTime);
    }
}
