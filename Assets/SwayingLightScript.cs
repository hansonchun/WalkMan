using UnityEngine;
using System.Collections;

public class SwayingLightScript : MonoBehaviour {

	private Light light;

	public float swaySpeed;

	// Use this for initialization
	void Start () {
	
		light = GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.rotation.y < 33)
		{
			transform.Rotate (new Vector3 (0, Mathf.PingPong (Time.time * swaySpeed, -1), 0));

			if (transform.rotation.y == 33)
			{
				transform.Rotate (new Vector3 (0, Mathf.PingPong (Time.time * swaySpeed, -1), 0));
			} 
		}

	}	
}
