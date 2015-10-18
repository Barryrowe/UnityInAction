using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

	public enum RotationAxes {
		MouseXAndY = 0,
		MouseX = 1, 
		MouseY = 2
	}

	public RotationAxes axes = RotationAxes.MouseXAndY;

	public float sensitivityHorizontal = 9.0f;
	public float sensitivityVertical = 9.0f;

	public float minimumVert = -45.0f;
	public float maximumVert = 45.0f;

	private float _rotationX = 0;

	// Use this for initialization
	void Start () {
	
		Rigidbody rigidBody = GetComponent<Rigidbody> ();
		if (rigidBody != null) {
			rigidBody.freezeRotation = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (axes == RotationAxes.MouseX) {
			//horizontal rotation here
			float rotation = sensitivityHorizontal * Input.GetAxis("Mouse X");
			transform.Rotate (0, rotation, 0);
		} else if (axes == RotationAxes.MouseY) {
			//vertical rotation here
			_rotationX -= Input.GetAxis("Mouse Y") * sensitivityVertical;
			_rotationX = Mathf.Clamp (_rotationX, minimumVert, maximumVert);

			float rotationY = transform.localEulerAngles.y;
			transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
		} else {
			//Both rotation here
			_rotationX -= Input.GetAxis("Mouse Y") * sensitivityVertical;
			_rotationX = Mathf.Clamp (_rotationX, minimumVert, maximumVert);

			float delta = Input.GetAxis("Mouse X") * sensitivityHorizontal;
			float rotationY = transform.localEulerAngles.y + delta;

			transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
		}
	}
}
