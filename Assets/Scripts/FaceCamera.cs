using UnityEngine;
using System.Collections;

public class FaceCamera : MonoBehaviour {
    public Camera cam;

    void Update()
    {
        transform.eulerAngles = cam.transform.eulerAngles;
    }
}
