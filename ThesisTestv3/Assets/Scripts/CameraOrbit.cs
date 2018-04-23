using UnityEngine;
using System.Collections;

public class CameraOrbit : MonoBehaviour 
{

	protected Transform _XForm_Camera;
	protected Transform _XForm_Parent;

	protected Vector3 _LocalRotation;
	protected float _CameraDistance = 10f;

	public float MouseSensitivity = 4f;
	public float ScrollSensitvity = 2f;
	public float OrbitDampening = 10f;
	public float ScrollDampening = 6f;

	public bool CameraDisabled = false;

	public Vector3 plusX = new Vector3 (90f, 0f, 0f);

	//Camera snap values
	//y can be any value
	//aslong as (x is greater than 0 and less than 180) and z 
	public Vector3 cameraXPos = new Vector3 (0f, 0f, 90f);
	public Vector3 cameraXNeg = new Vector3 (0f, 0f, -90f);

	//y can be any value
	//aslong as x,z = 0, yneg can range for -360 to 360
	public Vector3 cameraYPos = new Vector3 (-180f, 0f, 0f);
	//aslong as x=-180 (or greater than -90 and less than -270) and z = 0 (or greater than -90 and less than 90)
	public Vector3 cameraYNeg = new Vector3 (0f, 0f, 0f);

	//z can be any value

	public Vector3 cameraZPos = new Vector3 (0f, 90f, -90f);
	public Vector3 cameraZNeg = new Vector3 (0f, 90f, 90f);


	// Use this for initialization
	void Start() {
		this._XForm_Camera = this.transform;
		this._XForm_Parent = this.transform.parent;
	}


	void LateUpdate() {


		if (Input.GetKeyDown(KeyCode.LeftShift))
			CameraDisabled = !CameraDisabled;
		
		if (CameraDisabled)
		{
			//Rotation of the Camera based on Mouse Coordinates
			if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
			{
				_LocalRotation.x += Input.GetAxis("Mouse X") * MouseSensitivity;
				_LocalRotation.y += Input.GetAxis("Mouse Y") * MouseSensitivity;

				//Clamp the y Rotation to horizon and not flipping over at the top
				//if (_LocalRotation.y < 0f)
					//_LocalRotation.y = 0f;
				//else if (_LocalRotation.y > 90f)
					//_LocalRotation.y = 90f;
			}
			//Zooming Input from our Mouse Scroll Wheel
			if (Input.GetAxis("Mouse ScrollWheel") != 0f)
			{
				float ScrollAmount = Input.GetAxis("Mouse ScrollWheel") * ScrollSensitvity;

				ScrollAmount *= (this._CameraDistance * 0.3f);

				this._CameraDistance += ScrollAmount * -1f;

				this._CameraDistance = Mathf.Clamp(this._CameraDistance, 1.5f, 100f);
			}
		}

		//Actual Camera Rig Transformations
		Quaternion QT = Quaternion.Euler(_LocalRotation.y, _LocalRotation.x, 0);
		this._XForm_Parent.rotation = Quaternion.Lerp(this._XForm_Parent.rotation, QT, Time.deltaTime * OrbitDampening);

		if ( this._XForm_Camera.localPosition.z != this._CameraDistance * -1f )
		{
			this._XForm_Camera.localPosition = new Vector3(0f, 0f, Mathf.Lerp(this._XForm_Camera.localPosition.z, this._CameraDistance * -1f, Time.deltaTime * ScrollDampening));
		}

	}
}
