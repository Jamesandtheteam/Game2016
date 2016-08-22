using UnityEngine;
using System.Collections;

public class Crusher : MonoBehaviour {
    private Rigidbody rig;
    private Vector3 originalPos;
    private bool retreat;

    void Awake()
    {
        originalPos = transform.position;
        rig = GetComponent<Rigidbody>();
    }

    //reverse direction when it collides
    void OnCollisionEnter(Collision col)
    {
        rig.velocity = Vector3.zero;
        rig.velocity = transform.forward * -12.5f;
        retreat = true;
    }

    //crush is triggered on objects with tag of player
    void OnTriggerStay(Collider coll)
    {
        if (coll.gameObject.tag == "Player" && !retreat)
            Crush();
    }

    //send crusher forward
    void Crush()
    {
        //rig.constraints = RigidbodyConstraints.FreezeRotation;
        rig.velocity = transform.forward * 25;
    }

    void Update()
    {
        Vector3 localVelocity = transform.InverseTransformDirection(rig.velocity);
        localVelocity.x = 0;
        localVelocity.y = 0;

        rig.velocity = transform.TransformDirection(localVelocity);

        //Check for when position is returned
        if (Vector3.Distance(transform.position, originalPos) < 0.2f && retreat)
        {
            rig.velocity = Vector3.zero;
            transform.position = originalPos;
            retreat = false;
        }
    }
}
