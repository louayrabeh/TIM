using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	
	public Transform target;
	public Vector3 offset;

	public bool offsetValues;
	public float rotateSpeed;

	public Transform pivot;

	void Start () {
		if (!offsetValues) {
			offset = target.position - transform.position;
		}

		pivot.transform.position = target.transform.position;
		//pivot.transform.parent = target.transform;
		pivot.transform.parent=null;
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {

		pivot.transform.position = target.transform.position;

		float horizental = Input.GetAxis ("Mouse X") * rotateSpeed;
		pivot.Rotate (0, horizental, 0);

		float vertical = Input.GetAxis ("Mouse Y") * rotateSpeed;
		pivot.Rotate (-vertical, 0, 0);


		float myYAngle = pivot.eulerAngles.y;
		float myXAngle = pivot.eulerAngles.x;
		Quaternion rotation = Quaternion.Euler (myXAngle, myYAngle, 0);
		transform.position = target.position - (rotation * offset);

		if (transform.position.y < target.position.y) 
		{
			transform.position = new Vector3 (transform.position.x, target.position.y, transform.position.z);
		}

		//transform.position = target.position - offset;
		transform.LookAt (target);
	}
}
