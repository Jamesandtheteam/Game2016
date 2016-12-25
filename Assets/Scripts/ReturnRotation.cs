using UnityEngine;
using System.Collections;

public class ReturnRotation : MonoBehaviour {
    private Quaternion origRot;
    public float returnSpeed = 10;

    void Awake()
    {
        origRot = transform.rotation;
    }

    void FixedUpdate ()
    {
	    if(transform.rotation != origRot)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, origRot, Time.deltaTime * returnSpeed);
        }
	}
}
