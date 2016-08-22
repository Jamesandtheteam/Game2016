using UnityEngine;
using System.Collections;

public class TouchDeath : MonoBehaviour {

	void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<Movement>())
        {
            col.gameObject.GetComponent<Movement>().death();
        }
    }
}
