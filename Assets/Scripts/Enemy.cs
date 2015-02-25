using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public Transform[] patrolPoints;
	public float moveSpeed;
	private int currentPoint;

	public bool facingRight;

	// Use this for initialization
	void Start () {

		transform.position = patrolPoints [0].position;
		currentPoint = 0;

	}
	
	// Update is called once per frame
	void Update () 
	{
		Patrol ();

	}

	// This function handles all the enemy patrolling.
	void Patrol() 
	{
		// <summary>
		// Current point denotes the next position the enemy is headed towards. Increase size variable to increase the patrol points.
		// </summary>
		if (transform.position == patrolPoints[currentPoint].position) {
			currentPoint++;
		}
		if (currentPoint >= patrolPoints.Length) {
			currentPoint = 0;
		}
		transform.position = Vector3.MoveTowards (transform.position, patrolPoints [currentPoint].position, moveSpeed * Time.deltaTime);

		// <summary>
		// This part flips the enemy sprite based on its path points.
		// </summary>
		if (transform.position.x < patrolPoints[currentPoint].position.x && !facingRight) {
			Flip ();
		}
		
		if (transform.position.x > patrolPoints [currentPoint].position.x && facingRight) {
			Flip ();
		}

	}

	// Flips the sprite.
	void Flip()
	{
		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
