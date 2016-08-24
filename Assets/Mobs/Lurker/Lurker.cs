using UnityEngine;
using System.Collections;

public class Lurker : MonoBehaviour {
    private Rigidbody rig;
    private GameObject[] players;
    private Vector3 fwd;

    public GameObject targetObj;
    public float speed;

	void Awake () {
        rig = GetComponent<Rigidbody>();

        players = GameObject.FindGameObjectsWithTag("Player");

        speed += Random.Range(-1, 1);
	}
	
	void FixedUpdate () {
        //finds closest object with tag "player" and chases it

        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject t in players)
        {
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = t.transform;
                minDist = dist;
            }
        }
        targetObj = tMin.gameObject;

        transform.position = Vector3.MoveTowards(transform.position, targetObj.transform.position, Time.fixedDeltaTime * speed);

        //look toward movement
        fwd = new Vector3(rig.velocity.x, 0, rig.velocity.z);
        if (fwd.sqrMagnitude != 0)
            gameObject.transform.forward = Vector3.Lerp(gameObject.transform.forward, fwd, Time.deltaTime * 10);
    }



    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            //calls death function
            col.gameObject.GetComponent<Movement>().death();
        }
    }
}
