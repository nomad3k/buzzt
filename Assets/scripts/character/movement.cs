using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

	public float Speed = 20f;
	public float Rotation = 90f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Process Inputs
		var left = Input.GetKey("a") ? 1 : 0;
		var right = Input.GetKey("d") ? 1 : 0;
		var forward = Input.GetKey("w") ? 1 : 0;
		var backward = Input.GetKey("s") ? 1 : 0;

		// Turn inputs into direction
		var direction	= forward - backward;
		var turn 		= (right - left) * direction; // only turn when moving
		
		var body = GetComponent<Rigidbody>();

		// Turn it
		if (turn != 0) {
			var rot = new Vector3(0, Rotation, 0);
			var deltaRotation = Quaternion.Euler(rot * turn * Time.deltaTime);
			body.MoveRotation(body.rotation * deltaRotation);
		}

		// Move it
		if (direction != 0) {
			body.MovePosition(transform.position + transform.forward * (direction * Speed * Time.deltaTime));
		}
	}
}
