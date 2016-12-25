using UnityEngine;
using System.Collections;

public class XFix : MonoBehaviour {

	private Camera cam;

	void Awake(){
        cam = transform.parent.GetComponent<Camera>();
	}

	void FixedUpdate () {
		transform.localEulerAngles = new Vector3 (-cam.transform.eulerAngles.x, 0, 0);
	}
}
