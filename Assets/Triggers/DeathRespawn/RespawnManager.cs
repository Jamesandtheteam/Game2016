using UnityEngine;
using System.Collections;

public class RespawnManager : MonoBehaviour {

    public Vector3[] respawnPoint;
    public int currentPoint;
	
	void Awake() {
        //must be named *RepawnManager in order for kill zones and respawn points to find this script
        if (gameObject.name != "*RespawnManager")
            print("Gameobject at " + gameObject.transform.position + " was renamed to *RepawnManager");
        gameObject.name = "*RespawnManager";
	}

    void Respawn(GameObject targetCharacter)
    {
        targetCharacter.transform.position = respawnPoint[currentPoint];
    }

    void SetRespawnPoint(int pointNum){
        currentPoint = pointNum;
    }
}