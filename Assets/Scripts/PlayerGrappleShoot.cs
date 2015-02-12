using UnityEngine;
using System.Collections;

public class PlayerGrappleShoot : MonoBehaviour 
{
	public Transform grappleStart;
	public Transform grappleEnd;
	
	public GameObject hook;
	
	public bool pullable = false;

	public bool isHooked;
	
	public SpringJoint2D springJoint;

	// Use this for initialization
	void Start () 
	{
		springJoint = GetComponent<SpringJoint2D> ();

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
			hook.transform.position = grappleEnd.transform.position;
				if (pullable) 
				{
					isHooked = true;
				}
		}
		
	}

	void CheckHooked() 
	{
		if (!isHooked) 
		{
			hook.transform.position = transform.position;
		}
	}


}
