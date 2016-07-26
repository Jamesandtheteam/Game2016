using UnityEngine;
using System.Collections;

public class StickyPlatform : MonoBehaviour {

	void Awake(){
		//fix scale, because local scale must be uniform
		if (transform.localScale.x != ((transform.localScale.y + transform.localScale.z) / 2)) {
			transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.x, transform.localScale.x);
			print (gameObject.name + "'s scale has been adjusted for stickey platform functionality at location " + transform.position);
		}
	}

	void OnCollisionEnter(Collision c){
		if (c.gameObject.GetComponent<Rigidbody> () == true) {
			c.transform.parent = gameObject.transform;
		}
	}
	void OnCollisionStay(Collision c){
		if (c.gameObject.GetComponent<Rigidbody> () == true) {
			c.transform.parent = gameObject.transform;
		}
	}
	void OnCollisionExit(Collision c){
		if (c.gameObject.GetComponent<Rigidbody> () == true) {
			c.transform.parent = null;
		}
	}
}
