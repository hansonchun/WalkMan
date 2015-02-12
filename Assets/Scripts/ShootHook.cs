using UnityEngine;
using System.Collections;

public class ShootHook : MonoBehaviour {

	Player player;

	public int hookSpeedX;
	public int hookSpeedY;

	// Update is called once per frame
	void Update () {

			rigidbody2D.AddForce (new Vector2 (hookSpeedX * Time.deltaTime, hookSpeedY * Time.deltaTime), ForceMode2D.Impulse); 

			
	
	}

	void OnCollisionEnter2D (Collision2D other) 
	{
		if (other.gameObject.tag == "Pullable") {

			rigidbody2D.isKinematic = true;

		}
	}

}
