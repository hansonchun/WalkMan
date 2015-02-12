using UnityEngine;
using System.Collections;

public class PlayerGrappleShoot : MonoBehaviour 
{


	public GameObject hookPrefab;

	public SpringJoint2D springJoint;

	public float fireDelay = 0.25f;
	float cooldownTimer = 0;

	// Use this for initialization
	void Start () 
	{
		springJoint = GetComponent<SpringJoint2D> ();

	}
	
	// Update is called once per frame
	void Update () 
	{

		cooldownTimer -= Time.deltaTime;

		if (Input.GetKeyDown (KeyCode.LeftShift) && cooldownTimer <= 0)
		{
			Rigidbody2D hookInstance;

			Debug.Log("Shot Grapple");
			cooldownTimer = fireDelay;
			hookInstance = Instantiate (hookPrefab, transform.position, transform.rotation) as Rigidbody2D;

			springJoint.connectedBody = hookInstance;

		}

	
	}


}
