using UnityEngine;
using System.Collections;

public class KillZone : MonoBehaviour {

	void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            col.GetComponent<Movement>().death();
        }
    }
}
