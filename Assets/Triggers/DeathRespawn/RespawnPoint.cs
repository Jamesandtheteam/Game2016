using UnityEngine;
using System.Collections;

public class RespawnPoint : MonoBehaviour {

    public int respawnNumber;
    private RespawnManager respawnManager;

    void Awake()
    {
        respawnManager = GameObject.Find("Manager").GetComponent<RespawnManager>();
    }

	void OnCollisionEnter(Collision c)
    {
        respawnManager.SendMessage("SetRespawnPoint", respawnNumber);
        //to show that it has now become active
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}
