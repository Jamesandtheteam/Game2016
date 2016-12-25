using UnityEngine;
using System.Collections;

public class Dead : MonoBehaviour {
    private Rigidbody rig;
    private Transform targetSpawn;
    private int targetSpawnNum;
    private int h;

    void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

	void OnEnable ()
    {
        targetSpawn = transform;
        targetSpawnNum = int.Parse(gameObject.name.Substring(gameObject.name.Length - 1, 1));
        GetComponent<Movement>().enabled = false;
        rig.constraints = RigidbodyConstraints.None;
        GetComponent<Renderer>().material.color = Color.red;
    }

    void Update()
    {
        //if player is close and presses Y 15 times, player is healed
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
            Revive(transform.position);
        }


        //spawn on any teammate once dead

        //use RB and LB to cycle through spawns
        if (Input.GetKeyDown("joystick " + name.Substring(gameObject.name.Length - 1, 1) + " button 5"))
        {
            if (targetSpawnNum < 4)
                targetSpawnNum++;
            else
                targetSpawnNum = 1;
        }
        if (Input.GetKeyDown("joystick " + name.Substring(gameObject.name.Length - 1, 1) + " button 4"))
        {
            if (targetSpawnNum > 1)
                targetSpawnNum--;
            else
                targetSpawnNum = 4;
        }

        targetSpawn = GameObject.Find("Player" + (targetSpawnNum).ToString()).transform;
        GameObject.Find("Camera" + name.Substring(gameObject.name.Length - 1, 1)).GetComponent<CameraController>().targetLookAt = targetSpawn;

        //if dead player presses Y
        if (Input.GetKeyDown("joystick " + name.Substring(gameObject.name.Length - 1, 1) + " button 3"))
        {
            //if target player is not moving and dead player presses Y
            //actually, SHOULD PLAYER EVEN HAVE TO BE STILL? WHY? if I want to change it back, code is located right below this
            //Vector3.Distance(targetSpawn.GetComponent<Rigidbody>().velocity, Vector3.zero) < 0.25f
            if (targetSpawn.GetComponent<Dead>().enabled == false)
            {
                Revive(targetSpawn.position);
            }
        }
    }

    public void Revive(Vector3 revivePos)
    {
        GameObject.Find("Camera" + name.Substring(gameObject.name.Length - 1, 1)).GetComponent<CameraController>().targetLookAt = transform;
        transform.position = revivePos;
        transform.eulerAngles = Vector3.zero;
        rig.velocity = Vector3.zero;
        rig.constraints = RigidbodyConstraints.FreezeRotation;
        GetComponent<Renderer>().material.color = Color.white;
        GetComponent<Movement>().enabled = true;
        this.enabled = false;
    }
}
