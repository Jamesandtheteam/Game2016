using UnityEngine;
using System.Collections;

public class Activator : MonoBehaviour {

    private float ready;

    [Header("Door")]
    public GameObject doorObject;

    void OnCollisionEnter(Collision c)
    {
        activated();
    }

	void activated () {

        if (doorObject != null)
        {
            doorObject.GetComponent<Door>().activate();
        }

	}

}
