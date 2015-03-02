using UnityEngine;
using System.Collections;

public class CrumblingWallScript : MonoBehaviour {

	public float destroyTime;

	// Use this for initialization
	void Start () {
	}

	void OnCollisionEnter2D (Collision2D other) 
	{
		if (other.gameObject.tag == "Player") 
		{
			Invoke ("DestroyWall", destroyTime * Time.deltaTime);
		}
	}
	
	// Update is called once per frame


	void DestroyWall () 
	{
		Destroy (gameObject);
		Debug.Log ("Wall crumbling");
	}
}
