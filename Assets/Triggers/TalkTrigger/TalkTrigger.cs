using UnityEngine;
using System.Collections;

public class TalkTrigger : MonoBehaviour {
	public GameObject targetTalker;
	private Talk t;
	private GameObject c;

	void Awake(){
		t = targetTalker.GetComponent<Talk> ();
	}

	void OnTriggerEnter(Collider col){
		//this is where I'll put the part where I'll make the little bubble input prompt appear
		c = col.gameObject;
	}

	void OnTriggerExit(Collider col){
		if (col.gameObject == c) {
			c = null;
		}
	}

	void FixedUpdate(){
		if (c != null && Input.GetButtonDown("Enter") && t.speaking == false) {
			activate();
		}
	}

	void activate(){
		t.SendMessage ("FreezePlayer", c);
		t.SendMessage ("_update", c);
	}
}