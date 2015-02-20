using UnityEngine;
using System.Collections;

public class HookLine : MonoBehaviour {

	public LineRenderer hookLine;

	public Transform player;
	public Transform hook;

	public Vector3 grapplePoint;
	public Vector3 hookPoint;

	public float dist;

	public float lineDrawSpeed = 6f;
	

	// Use this for initialization
	void Start () {

		hookLine = GetComponent<LineRenderer> ();

	}
	
	// Update is called once per frame
	void Update () {

		DrawLine ();
	
	}

	void DrawLine() 
	{
		grapplePoint = new Vector3 (player.position.x, player.position.y, 0);
		hookPoint = new Vector3 (hook.position.x, hook.position.y, 0);

		dist = (int) Vector3.Distance (grapplePoint, hookPoint);
		if (dist == 0) 
		{
			hookLine.SetPosition (0, grapplePoint);
			hookLine.SetPosition (1, grapplePoint);
		}
		else 
		{
			hookLine.SetPosition (0, grapplePoint);
			hookLine.SetPosition (1, hookPoint);
		}


	}
}