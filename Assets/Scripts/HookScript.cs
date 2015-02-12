using UnityEngine;
using System.Collections;

public class HookScript : MonoBehaviour {

	public Transform player;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollision2D(Collision2D other) 
	{
		if (other.gameObject.tag == "Pullable") 
		{
			rigidbody2D.isKinematic = true;
		}
	}
}
