using UnityEngine;

public class PlayerView : MonoBehaviour
{
	private Transform _playerTransform;

	[SerializeField, Min(0.1f)] private float _sensitivity = 10f;
	[SerializeField] private bool _verticalInverted = false;
	[SerializeField] private bool _horizontalInverted = false;

	private float _xRotation = 0f;

	private const float MIN_X_ROTATION = -90f;
	private const float MAX_X_ROTATION = 90f;

	private void Awake()
	{
		_playerTransform = Player.Instance.transform;
	}

	private void Update()
	{
		Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

		float yRotation = mouseInput.x * _sensitivity * (_horizontalInverted ? -1 : 1);
		_playerTransform.Rotate(Vector3.up, yRotation);

		_xRotation -= mouseInput.y * _sensitivity * (_verticalInverted ? -1 : 1);
		_xRotation = Mathf.Clamp(_xRotation, MIN_X_ROTATION, MAX_X_ROTATION);
		transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
	}
}
