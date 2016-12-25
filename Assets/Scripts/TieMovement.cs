using UnityEngine;
using System.Collections;

public class TieMovement : MonoBehaviour {
    public GameObject targetObj;

	void Update ()
    {
        targetObj.transform.position = transform.position;
	}
}
