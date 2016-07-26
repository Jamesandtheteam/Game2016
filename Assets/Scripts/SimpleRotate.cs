using UnityEngine;
using System.Collections;

public class SimpleRotate : MonoBehaviour {
	public float xSpeed;
	public float ySpeed;
	public float zSpeed;

	void FixedUpdate () {
		transform.localEulerAngles = transform.localEulerAngles + new Vector3 (xSpeed, ySpeed, zSpeed);
	}
}