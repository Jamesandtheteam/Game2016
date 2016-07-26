using UnityEngine;
using System.Collections;

public class SpeedBoost : MonoBehaviour {

	public float runTime = 10;
	private bool running;
	private bool lerpDown;
	private GameObject g;
	private Vector2 speedAndJumpValues;

	void OnTriggerEnter (Collider c) {
		if (c.gameObject.GetComponent<Movement> () == true && !running) {
			g = c.gameObject;
			speedAndJumpValues = new Vector2 (c.gameObject.GetComponent<Movement> ().speed, c.gameObject.GetComponent<Movement> ().jumpHeight);
			StartCoroutine (boost ());
			running = true;
		}
	}

	void FixedUpdate(){
		if (lerpDown) {
			g.gameObject.GetComponent<Movement> ().speed = Mathf.Lerp (g.gameObject.GetComponent<Movement> ().speed, speedAndJumpValues.x, Time.deltaTime);
			g.gameObject.GetComponent<Movement> ().jumpHeight = Mathf.Lerp (g.gameObject.GetComponent<Movement> ().jumpHeight, speedAndJumpValues.y, Time.deltaTime);
		}
	}

	IEnumerator boost(){
		g.gameObject.GetComponent<Movement> ().speed *= 2;
		g.gameObject.GetComponent<Movement> ().jumpHeight *= 1.25f;
		yield return new WaitForSeconds (runTime * 0.8f);
		lerpDown = true;
		yield return new WaitForSeconds (runTime * 0.2f);
		lerpDown = false;
		g.gameObject.GetComponent<Movement> ().speed = speedAndJumpValues.x;
		g.gameObject.GetComponent<Movement> ().jumpHeight = speedAndJumpValues.y;
		speedAndJumpValues = Vector2.zero;
		g = null;
		running = false;
	}
}