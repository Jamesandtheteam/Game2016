using UnityEngine;
using System.Collections;

public class Launcher : MonoBehaviour {
	public Vector3 launchVelocity;

	void OnCollisionStay(Collision col){
		if (col.gameObject.GetComponent<Movement> () == true) {
			col.gameObject.GetComponent<Movement> ().upVel = launchVelocity.y;
		}

		else if (col.gameObject.GetComponent<Rigidbody> () == true) {
			col.gameObject.GetComponent<Rigidbody> ().velocity = (launchVelocity);
		}
	}
}