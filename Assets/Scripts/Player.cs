using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Player mechanics
	public bool facingRight;

	// Movement mechanics
	public float speed;
	public float horizontalMovement = 0;
	public float verticalMovement = 0;

	// Jump mechanics
	public int jumpSpeed;
	public int minusJumpSpeed;
	public bool inJump = false;
	public bool cancelJump = false;

	// Walled mechanics
	public bool touchingWallLeft;
	public Transform wallPointOneLeft;
	public Transform wallPointTwoLeft;
	public bool touchingWallRight;
	public Transform wallPointOneRight;
	public Transform wallPointTwoRight;
	public LayerMask onlyWallMask;

	// Grounded mechanics
	public bool isGrounded;
	public Transform pointOne;
	public Transform pointTwo;
	public LayerMask onlyGroundMask;

	// Death mechanics
	public float playerHeight;
	public float deathHeight;
	private Vector2 spawn;

	// Animator
	Animator anim;
	
	// Use this for initialization
	void Start () {
	
		anim = GetComponent<Animator> ();
		spawn = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		touchingWallRight = Physics2D.OverlapArea (wallPointOneRight.position, wallPointTwoRight.position, onlyWallMask);
		touchingWallLeft = Physics2D.OverlapArea (wallPointOneLeft.position, wallPointTwoLeft.position, onlyWallMask);
		isGrounded = Physics2D.OverlapArea (pointOne.position, pointTwo.position, onlyGroundMask);

		Jump ();
		WallJump ();
		AnimatePlayer ();
	}

	void Jump() {

		if (Input.GetKeyDown (KeyCode.Space) && isGrounded) {
			inJump = true;
		}
		
		if (verticalMovement > 0) {
			if (Input.GetKeyUp (KeyCode.Space) && !isGrounded) {
				cancelJump = true;		
				
			}
		}
	
	}
	
	void WallJump() {

		if (Input.GetKeyDown (KeyCode.Space) && !isGrounded && (touchingWallLeft || touchingWallRight)) {
			GetComponent<Rigidbody2D>().AddForce(new Vector2 (0, jumpSpeed * Time.deltaTime), ForceMode2D.Impulse);
		}

	}
	

	void FixedUpdate() {

		horizontalMovement = Input.GetAxis ("Horizontal");
		verticalMovement = GetComponent<Rigidbody2D>().velocity.y;

		playerHeight = transform.position.y;

		// movements
		GetComponent<Rigidbody2D>().velocity = new Vector2 (horizontalMovement * speed * Time.deltaTime, verticalMovement);


		// jumps
		if (inJump) {
			GetComponent<Rigidbody2D>().AddForce (new Vector2 (0, jumpSpeed * Time.deltaTime), ForceMode2D.Impulse);
			inJump = false;
			}

		if (cancelJump) {
			GetComponent<Rigidbody2D>().AddForce (new Vector2 (0, minusJumpSpeed * Time.deltaTime), ForceMode2D.Impulse);
			cancelJump = false;
			}

		// flips sprite
		if (horizontalMovement < 0 && !facingRight) {
			Flip ();
		}

		if (horizontalMovement > 0 && facingRight) {
			Flip ();		
		}

		// player death
		if (playerHeight < deathHeight) {

			Die();
		}
	
	}

	void Flip() {

		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	
	}

	void Die() {

		transform.position = spawn;
	}

	void AnimatePlayer() {

		int zeroVSpeed = (int)verticalMovement;


		anim.SetInteger ("zeroVSpeed", zeroVSpeed);
		anim.SetFloat ("Speed", Mathf.Abs (horizontalMovement));
		anim.SetFloat ("vSpeed", verticalMovement);
		anim.SetBool ("Grounded", isGrounded);
		anim.SetBool ("TouchingWall", touchingWallRight);

	}


	                                         

	
}
	

	




