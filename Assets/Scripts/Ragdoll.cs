using UnityEngine;
using System.Collections;

public class Ragdoll : MonoBehaviour {
	private Rigidbody rig;
	private float g;

	private Vector3 moveVector;

	void Awake () {
		rig = GetComponent<Rigidbody> ();
		rig.useGravity = false;
		g = -Physics.gravity.y;
	}
	

	void FixedUpdate () {
		processGravity ();
		processMotion ();
	}

	void processGravity(){
		moveVector = new Vector3 (rig.velocity.x, rig.velocity.y - g / 10, rig.velocity.z);
	}

	void processMotion(){
		rig.velocity = transform.TransformDirection(moveVector);
	}
}
