using UnityEngine;
using System.Collections;

public class Lurker : MonoBehaviour {
    private Rigidbody rig;
    public GameObject targetObj;
    public float speed;
	
	void Awake () {
        rig = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {
        transform.position = Vector3.MoveTowards(transform.position, targetObj.transform.position, Time.fixedDeltaTime * speed);
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            //calls detah function
            col.gameObject.GetComponent<Movement>().death();
            //play animation (currently replaced with turning player red)
            col.gameObject.GetComponent<Renderer>().material.color = Color.red;

            Destroy(gameObject);
        }
    }
}
