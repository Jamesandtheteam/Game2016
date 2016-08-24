using UnityEngine;
using System.Collections;

public class Plate : MonoBehaviour {
    public GameObject targetObjOff;
    public GameObject targetObjOn;
    public GameObject wire;

    void Awake()
    {
        if (wire != null)
            wire.GetComponent<Renderer>().material.color = Color.black;
    }

    void OnCollisionStay(Collision col)
    {
        if(targetObjOff != null)
            targetObjOff.SetActive(false);

        if (targetObjOn != null)
            targetObjOn.SetActive(true);

        if (wire != null)
            wire.GetComponent<Renderer>().material.color = Color.green;
    }

    void OnCollisionExit(Collision col)
    {
        if (targetObjOff != null)
            targetObjOff.SetActive(true);

        if (targetObjOn != null)
            targetObjOn.SetActive(false);

        if (wire != null)
            wire.GetComponent<Renderer>().material.color = Color.black;
    }
}
