using UnityEngine;
using System.Collections;

public class GrappleScript : MonoBehaviour 
{

	public Transform grapple;
	public GameObject hook;

	public bool pullable = false;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Raycasting ();
		Grapple ();
	}

	void FixedUpdate()
	{
	
	}

	void Raycasting() 
	{
		Debug.DrawLine (grapple.position, hook.transform.position, Color.red);
		pullable = Physics2D.Linecast (grapple.position, hook.transform.position, 1 << LayerMask.NameToLayer("Pullable"));
	}

	void Grapple() 
	{
		if (Input.GetKeyDown(KeyCode.LeftShift) && pullable) 
		{
		
		}
	}



}
