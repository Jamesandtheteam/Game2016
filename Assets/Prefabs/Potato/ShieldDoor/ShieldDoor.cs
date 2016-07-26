using UnityEngine;
using System.Collections;

public class ShieldDoor : MonoBehaviour {

	void OnTriggerEnter(Collider col)
    {
        if (col.transform.parent == null && col.name == "Potato")
            col.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
