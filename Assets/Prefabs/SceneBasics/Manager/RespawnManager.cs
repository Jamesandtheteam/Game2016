using UnityEngine;
using System.Collections;

public class RespawnManager : MonoBehaviour {

    public Vector3[] respawnPoint;
    public int currentPoint;

    void Respawn(GameObject targetCharacter)
    {
        targetCharacter.transform.position = respawnPoint[currentPoint];
    }

    void SetRespawnPoint(int pointNum){
        currentPoint = pointNum;
    }
}