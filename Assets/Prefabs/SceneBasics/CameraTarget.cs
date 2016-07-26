using UnityEngine;
using System.Collections;

public class CameraTarget : MonoBehaviour {
    [Range (1, 4)]
    public int players;
    public GameObject[] cameraTargets;
    public Vector3[] cameraTargetsPos;
    public Vector3 averagePos;
    public bool fixedY;
    public float yPos;

    void Awake()
    {
        gameObject.name = "*CameraTarget";
    }

	void Update () {
      
        if(players == 1)
        {
            cameraTargetsPos[0] = cameraTargets[0].transform.position;
        }
        if (players == 2)
        {
            cameraTargetsPos[0] = cameraTargets[0].transform.position;
            cameraTargetsPos[1] = cameraTargets[1].transform.position;
        }
        if (players == 3)
        {
            cameraTargetsPos[0] = cameraTargets[0].transform.position;
            cameraTargetsPos[1] = cameraTargets[1].transform.position;
            cameraTargetsPos[2] = cameraTargets[2].transform.position;
        }
        if (players == 4)
        {
            cameraTargetsPos[0] = cameraTargets[0].transform.position;
            cameraTargetsPos[1] = cameraTargets[1].transform.position;
            cameraTargetsPos[2] = cameraTargets[2].transform.position;
            cameraTargetsPos[3] = cameraTargets[3].transform.position;
        }

        averagePos = Vector3.zero;
        for(int i = 0; i < players; i++)
        {
            averagePos += cameraTargetsPos[i];
        }
        averagePos /= players;

        if (fixedY)
            averagePos = new Vector3(averagePos.x, yPos, averagePos.z);

        transform.position = averagePos;
	}
}
