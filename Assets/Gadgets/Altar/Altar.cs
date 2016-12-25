using UnityEngine;
using System.Collections;

public class Altar : MonoBehaviour {
    private GameObject[] players;
    private bool touching;
    private float maxDistance;
    public Vector3 revivePositionOffset;

    /*
    The Altar is pretty much the menu system of the game
    From here you can revive teammates, save level, load level, call votes on other players, etc
    */

	void Awake ()
    {
        players = GameObject.FindGameObjectsWithTag("Player");

        if(GetComponent<BoxCollider>().bounds.extents.x > GetComponent<BoxCollider>().bounds.extents.z)
            maxDistance = GetComponent<BoxCollider>().bounds.extents.x;
        else
            maxDistance = GetComponent<BoxCollider>().bounds.extents.z;
    }
	
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
            touching = true;
    }

	void Update () {
	    foreach(GameObject p in players)
        {
            float distance = Vector3.Distance(transform.position, p.transform.position);

            //if player close enough and button is pressed
            //that's a sick fucking line of code right there. I'm hella good at programming
            if (distance <= maxDistance && touching && Input.GetKeyUp("joystick " + p.name.Substring(p.name.Length - 1, 1) + " button 3"))
            {
                    //revive all dead players
                foreach (GameObject dp in GameObject.Find("Manager").GetComponent<DeathManager>().deadPlayers)
                {
                    if (dp != null)
                        Revive(dp);
                }
            }
        }
	}

    void Revive(GameObject p)
    {
        p.GetComponent<Dead>().Revive(transform.position + revivePositionOffset);
    }
}
