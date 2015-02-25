using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour {

	public bool playerInSight;
	
	public Transform sightStart;
	public Transform sightEnd;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Raycasting ();
	}

	void Raycasting() 
	{
		Debug.DrawLine (sightStart.position, sightEnd.position, Color.red);
		playerInSight = Physics2D.Linecast(sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("Player"));
	}

}
