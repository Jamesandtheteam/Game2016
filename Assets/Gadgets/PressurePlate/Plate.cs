using UnityEngine;
using System.Collections;

public class Plate : MonoBehaviour {
    [Header("Pressure Plate Objects")]
    public GameObject targetObjOff;
    public GameObject targetObjOn;

    [Header("Times Button Press Objects")]
    //if timed set time != 0
    public float time;
    public GameObject timedObjOn;
    public GameObject timedObjOff;
    [Space(20)]

    public GameObject wire;

    void Awake()
    {
        if (wire != null)
            wire.GetComponent<Renderer>().material.color = Color.black;
    }

    void OnCollisionEnter(Collision col)
    {
        if(time > 0)
        {

        }
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
