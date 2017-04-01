using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : Unit {

	public float speed;
	public float jumpheight;


	public float bulletprefab;


	private Transform camPivot;
	private float RaycastDistance = 5f;

	// We can override virtual methods. This means the start method in the player conroller is called instead of the start in the unit.
	protected override void Start ()
	{


		base.Start ();
		// Here I can put whatever I want which will execute the start of the PlayerController

		camPivot = transform.Find ("CamPivot");

	}



	// Update is called once per frame
	void Update () {


		// Add a dash effect to make the player dash when pressed a specific key
		// NOTE TO SELF CHANGE THESE TWO METHODS LATER AND MAKE IT BETTER

		if (Input.GetKeyDown (KeyCode.K)) {

			transform.position += new Vector3 (speed * Time.deltaTime, 0.0f, 40f);

		}

		// add a dash effect in the opposite direction

		if (Input.GetKeyDown (KeyCode.J)) {

			transform.position += new Vector3 (speed * Time.deltaTime, 0.0f, -40f);

		}

		if (Input.GetKeyDown (KeyCode.Delete)) {



		}



		// Create dodge roll effect


		if (Input.GetKeyDown (KeyCode.D)) {



		}



		//Lock the cursor 
		Cursor.lockState = CursorLockMode.Locked;

		float horizontalInput = Input.GetAxis ("Horizontal");
		float verticalInput = Input.GetAxis ("Vertical");




		if (Input.GetKeyDown (KeyCode.K)) {

			transform.position += new Vector3 (speed * Time.deltaTime, 0.1f, 0.0f);


		}

		// We normalized our input vetor to make sure our input value always has a length of 1



		Vector3 input = new Vector3 (horizontalInput, 0, verticalInput).normalized * speed;

		if (Input.GetKeyDown (KeyCode.Space) && IsGrounded()) {

			input.y = jumpheight;
			anim.SetTrigger ("Jump");


		} else

		{

			// We make sure that the Y value of input is not 0, if it would always be 0 the Y velociaty would always be set to 0 as well.
			input.y = rb.velocity.y;

		}





		// We clamp the mangnitude to ensure the input has a max length of speed
		input = Vector3.ClampMagnitude (input, speed);


		// Rotates a vector from local to world space
		rb.velocity = transform.TransformVector(input);

		// Now we get the delta movement of the mouse

		float mouseXInput = Input.GetAxis("Mouse X");

		transform.Rotate (0, mouseXInput, 0);

		float mouseYInput = Input.GetAxis ("Mouse Y");
		camPivot.Rotate (-mouseYInput, 0, 0);

		anim.SetFloat ("HorizontalSpeed", horizontalInput);
		anim.SetFloat ("VerticalSpeed", verticalInput);



	}

	bool IsGrounded ()
	{
		// Shooting a raycast down will return true if hit something
		return Physics.Raycast (transform.position, Vector3.down, RaycastDistance);


	}

	// Create method to shoot the bullet here

	void bullet () {



		//if (Input.GetKeyDown (KeyCode.F11) ()) {


		//print("ShotBullet") ;

		//}


		}


	}
