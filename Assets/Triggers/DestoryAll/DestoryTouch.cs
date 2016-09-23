using UnityEngine;
using System.Collections;

public class DestoryTouch : MonoBehaviour {

	void OnTriggerEnter(Collider col)
    {
        if(col.tag != "Player")
            Destroy(col.gameObject);
    }
}
