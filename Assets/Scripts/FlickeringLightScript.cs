using UnityEngine;
using System.Collections;

public class FlickeringLightScript : MonoBehaviour {

	Light light;
	public int flickerSpeed;

	// Use this for initialization
	void Start () {
	
		light = GetComponent <Light> ();
	}
	
	// Update is called once per frame
	void Update () {

		//light.intensity = Mathf.PingPong (Time.time * Random.Range (1f, 1.03f) * flickerSpeed, 8);
		light.intensity = Random.Range (1f, 3f) * flickerSpeed;
	
	}
}
