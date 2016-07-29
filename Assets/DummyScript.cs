using UnityEngine;
using System.Collections;

public class DummyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Light lt = GetComponent<Light> ();

		lt.intensity = 1+ Mathf.PingPong (Time.time, 5f);
	}
}
