using UnityEngine;
using System.Collections;

public class Dead : MonoBehaviour {
    private Rigidbody rig;
    private GameObject[] players;
    private int h;

    void Awake()
    {
        rig = GetComponent<Rigidbody>();
        players = GameObject.FindGameObjectsWithTag("Player");
    }

	void OnEnable ()
    {
        GetComponent<Movement>().enabled = false;
        rig.constraints = RigidbodyConstraints.None;
        GetComponent<Renderer>().material.color = Color.red;
    }

    void Update()
    {
        for (int i = 1; i < 5; i++)
        {
            if(Input.GetKeyDown("joystick " + i.ToString() + " button 3"))
            {
                if(gameObject.name != "Player" + i.ToString() && Vector3.Distance(GameObject.Find("Player" + i.ToString()).transform.position, transform.position) < 4)
                {
                    h++;
                }
            }
        }
        if (h >= 15)
        {
            h = 0;
            Revive();
        }
    }

    public void Revive()
    {
        transform.eulerAngles = Vector3.zero;
        rig.constraints = RigidbodyConstraints.FreezeRotation;
        GetComponent<Renderer>().material.color = Color.white;
        GetComponent<Movement>().enabled = true;
        this.enabled = false;
    }
}
