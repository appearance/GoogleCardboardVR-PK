using UnityEngine;
using System.Collections;

public class FreeMove : MonoBehaviour {
	
	public static FreeMove Instance = null;
	
	public float turningSense = 20f;
	public float altitudeSense = 10f;
	public float speedSense = 8f;
	
	public float minimumY = -90;
	public float maximumY = 90F;
	
	public float rotationY = 0f;
	public float rotationX = 0f;

	public GameObject Head;
		
	FreeMove() { Instance = this; }
	
	// Use this for initialization
	void Start () {
		if (rigidbody)
			rigidbody.freezeRotation = true;
	}
	
	void OnEnable () {
		rotationY = -transform.localRotation.eulerAngles.x;
		rotationX = transform.localRotation.eulerAngles.y;
	}
	
	// Update is called once per frame
	void Update () {
		float speed = speedSense;
		bool shiftdown = false;
/*		if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) {
			shiftdown = true;
			speed *= 3;
		} else if (Input.GetKey (KeyCode.LeftControl) || Input.GetKey (KeyCode.RightControl)) {
			speed *= 0.5f;
		}
*/		float horizontal = Input.GetAxis ("Horizontal") * turningSense * Time.deltaTime;
		float vertical = Input.GetAxis ("Vertical") * speed * Time.deltaTime;
		float pan = 0f;
		if (horizontal != 0f)
			if (shiftdown)
				pan = Input.GetAxis ("Horizontal") * (turningSense * 0.25f) * Time.deltaTime;
		//transform.Translate (pan, 0f, vertical, Space.Self);
		transform.position += Head.transform.forward * vertical;
		transform.position += Head.transform.right * horizontal;
		
		rotationX = transform.localEulerAngles.y;
		if (!shiftdown)
			rotationX += horizontal;
		
		/*float altitude = Input.GetAxis("Altitude") * altitudeSense * Time.deltaTime;
		rotationY += altitude;
		rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
		transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);*/


	}
	
	/*float topLimit = 100;
	float bottomLimit = -5;
	float climbLimit = 40f;
	float diveLimit = 320;
	Quaternion defaultTilt;
	
	void Update () {
		Vector3 tempv3;
		
		defaultTilt = transform.localRotation;
		defaultTilt.x = 0;
		defaultTilt.z = 0;
		
		if(Input.GetAxis("Horizontal") > 0.0) {
			tempv3 = transform.localEulerAngles;
			tempv3.y += turningSense * Time.deltaTime;
			transform.localEulerAngles = tempv3;
		}
	
		if(Input.GetAxis("Horizontal") < 0.0) {
			tempv3 = transform.localEulerAngles;
			tempv3.y -= turningSense * Time.deltaTime;
			transform.localEulerAngles = tempv3;
		}
		
		float vertical = Input.GetAxis ("Vertical") * speedSense * Time.deltaTime;
		transform.Translate (0f, 0f, vertical, Space.Self);
		
		if(Input.GetAxis("Altitude") < 0.0) {
			if(transform.localEulerAngles.x < climbLimit || transform.localEulerAngles.x > 275) {
				tempv3 = transform.localEulerAngles;
				tempv3.x += altitudeSense * 5 * Time.deltaTime;
				transform.localEulerAngles = tempv3;
			}
		}
		
		if(Input.GetAxis("Altitude") > 0.0) {
			if(transform.localEulerAngles.x > diveLimit || transform.localEulerAngles.x < 275){
				tempv3 = transform.localEulerAngles;
				tempv3.x -= altitudeSense * 5 * Time.deltaTime;
				transform.localEulerAngles = tempv3;
			}
		}
		
		if(Input.GetAxis("Altitude") == 0.0f) {
			transform.localRotation = Quaternion.Slerp(transform.localRotation, defaultTilt, 2 * Time.deltaTime);
		}
		
		if (transform.localPosition.y < bottomLimit) {
			tempv3 = transform.localPosition;
			tempv3.y = bottomLimit;
			transform.localPosition = tempv3;
		}
		if (transform.position.y > topLimit) {
			tempv3 = transform.localPosition;
			tempv3.y = topLimit;
			transform.localPosition = tempv3;
		}
	}*/
}
