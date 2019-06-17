using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	float Speed;
	//public Rigidbody theRB;
	public float jumpForce;

	public CharacterController controller;

	private Vector3 moveDirection;
	public float gravityScale;

	public Animator anim;

	public Transform pivot ;

	public float rotateSpeed;
	public GameObject playerModel;

	public float knockbackForce;
	public float knockbackTime;
	public float knockbackCounter;

	void Start () {
		//theRB = GetComponent<Rigidbody> ();	
		controller = GetComponent<CharacterController>();
		//anim=GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//anim.SetFloat ("speed", Mathf.Abs (Input.GetAxis ("Vertical")) + Mathf.Abs (Input.GetAxis ("Horizintal")));
		if(knockbackCounter <= 0)
		{
		float yStore = moveDirection.y;
		//moveDirection = new Vector3 (Input.GetAxis("Horizontal")  * moveSpeed , moveDirection.y , Input.GetAxis("Vertical") * moveSpeed);
		moveDirection = (transform.forward * Input.GetAxis ("Vertical")) + (transform.right * Input.GetAxis ("Horizontal"));
		moveDirection = moveDirection.normalized * moveSpeed;
		moveDirection.y = yStore;

			if (controller.isGrounded) {
				moveDirection.y = 0f;
				if (Input.GetButtonDown ("Jump")) {
					moveDirection.y = jumpForce;
				}
			}
			} 
			else
			{
				knockbackCounter -= Time.deltaTime;
			}
	
			moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
			controller.Move(moveDirection * Time.deltaTime);

		if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 ) 
			{
			transform.rotation = Quaternion.Euler (0f, pivot.rotation.eulerAngles.y, 0f);
			Quaternion newRotation = Quaternion.LookRotation (new Vector3 (moveDirection.x, 0f, moveDirection.z));
			playerModel.transform.rotation = Quaternion.Slerp (playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
			}

		anim.SetBool("isgrounded", controller.isGrounded);

		anim.SetFloat ("Speed", (Mathf.Abs(Input.GetAxis ("Vertical"))+ Mathf.Abs(Input.GetAxis("Horizontal"))));


			}
	
	public void knockback(Vector3 direction)
	{
		knockbackCounter = knockbackTime;
		moveDirection = direction * knockbackForce;
		moveDirection.y = knockbackForce;
	}
}