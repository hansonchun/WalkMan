using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerGrappleShoot : MonoBehaviour 
{
	public Transform grappleStart;
	public Transform grappleEnd;
	
	public GameObject hook;
	
	public bool pullable = false;
	public bool isHooked;

	public float xSpeed;
	public float ySpeed;
	
	public SpringJoint2D springJoint;
	public Rigidbody2D hookBody;

	GameObject clone;
	public float time;

	public Player player;

	void Awake()
	{
		CheckHooked ();
	}

	// Use this for initialization
	void Start () 
	{
		springJoint = GetComponent<SpringJoint2D> ();
		player = GetComponent<Player> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Raycasting ();
		Grapple ();
		CheckHooked ();
		
	}

	void Raycasting() 
	{
		Debug.DrawLine (grappleStart.position, grappleEnd.position, Color.red);
		pullable = Physics2D.Linecast (grappleStart.position, grappleEnd.position, 1 << LayerMask.NameToLayer("Pullable"));	
	}

	void Grapple()
	{
		if (Input.GetKeyDown (KeyCode.LeftShift) ) 
		{
			hook.renderer.enabled = true;

			if (pullable) 
			{
				isHooked = true;
				hook.transform.position = grappleEnd.transform.position;
			
			}
			else 
			{
				isHooked = false;
			}

			if (!pullable) 
			{
				LaunchGrapple ();
			}

		}

	}

	void CheckHooked() 
	{
		if (!isHooked) 
		{
			hook.renderer.enabled = false;
			hook.transform.position = transform.position;

		}
	}

	void LaunchGrapple()
	{
		if (!player.facingRight) 
		{
			clone = Instantiate (hook, hook.transform.position, hook.transform.rotation) as GameObject;
			Destroy (clone.rigidbody2D);
			//clone.rigidbody2D.velocity = transform.TransformDirection (new Vector2 (xSpeed * Time.deltaTime, ySpeed * Time.deltaTime));
			clone.transform.Translate (new Vector2(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime), Space.Self);
			//clone.transform.position = new Vector3(Mathf.PingPong (Time.time, 10), grappleEnd.transform.position.y, grappleEnd.transform.position.z); 
			Destroy (clone, time);
		}
		else
		{
			clone = Instantiate (hook, hook.transform.position, hook.transform.rotation) as GameObject;
			Destroy (clone.rigidbody2D);
			//clone.rigidbody2D.velocity = transform.TransformDirection (new Vector2 (-xSpeed * Time.deltaTime, ySpeed * Time.deltaTime));
			clone.transform.Translate (new Vector2(-xSpeed * Time.deltaTime, ySpeed * Time.deltaTime), Space.Self);
			Destroy (clone, time);
		}
	}


}
