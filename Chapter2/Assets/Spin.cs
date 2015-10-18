using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {

	public float speed = 3.0f;
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate (0, speed * Time.fixedDeltaTime, 0);
	}
}
