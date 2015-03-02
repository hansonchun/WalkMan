using UnityEngine;
using System.Collections;

public class GuardLightScript : MonoBehaviour {

	public GameObject RightLight;

	public Enemy enemy;

	// Use this for initialization
	void Start () {

		enemy = GetComponentInParent <Enemy> ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		FlipLight ();
	
	}

	void FlipLight()
	{
		if (enemy.facingRight) 
		{
			//transform = RightLight.transform;

		}

	}
}
