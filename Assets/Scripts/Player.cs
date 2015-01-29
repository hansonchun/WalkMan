using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Movement mechanics
	public int speed;
	public float horizontalMovement = 0;
	public float verticalMovement = 0;

	// Jump mechanics
	public int jumpSpeed;
	public int jumpSpeedShort;
	public int minusJumpSpeed;
	public bool inJump = false;
	public bool cancelJump = false;

	// Grounded mechanics
	public bool isGrounded;
	public Transform pointOne;
	public Transform pointTwo;
	public LayerMask onlyGroundMask;

	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		isGrounded = Physics2D.OverlapArea (pointOne.position, pointTwo.position, onlyGroundMask);

		if (Input.GetKey (KeyCode.Space) && isGrounded) {
			inJump = true;
		}

		if (verticalMovement > 0) {
			if (Input.GetKeyUp (KeyCode.Space) && !isGrounded) {
			cancelJump = true;		
			
			}
		}

	}
	

	void FixedUpdate() {

		horizontalMovement = Input.GetAxis ("Horizontal");
		verticalMovement = rigidbody2D.velocity.y;

		// movements
		rigidbody2D.velocity = new Vector2 (horizontalMovement * speed * Time.deltaTime, verticalMovement);

		//jumps
		if (inJump) {
			rigidbody2D.AddForce (new Vector2 (0, jumpSpeed * Time.deltaTime), ForceMode2D.Impulse);
			inJump = false;
			}

		if (cancelJump) {
			rigidbody2D.AddForce (new Vector2 (0, minusJumpSpeed * Time.deltaTime), ForceMode2D.Impulse);
			cancelJump = false;
			}


	
	}
}
	

	




