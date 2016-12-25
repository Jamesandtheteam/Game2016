using UnityEngine;
using System.Collections;

public class Plate : MonoBehaviour {
    [Header("Pressure Plate Objects")]
    //works if either targetObjOn or targetObjOn is defined
    public GameObject targetObjOn;
    public GameObject targetObjOff;

    [Header("Timed Button Press Objects")]
    //only works if timed set time != 0
    public float time;
    public GameObject timedObjOn;
    public GameObject timedObjOff;

    [Header("Switch Button Press Objects")]
    //only works if 'switchObj' is defined
    public bool on;
    public GameObject switchObj;
    public GameObject alternateSwitchObj;
    [Space(20)]

    public GameObject wire;

    void Awake()
    {
        if (wire != null)
            wire.GetComponent<Renderer>().material.color = Color.black;
        if (switchObj != null)
        {
            if (!on)
            {
                switchObj.SetActive(false);
                if (alternateSwitchObj != null)
                    alternateSwitchObj.SetActive(true);
                gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
            else
            {
                switchObj.SetActive(true);
                if (alternateSwitchObj != null)
                    alternateSwitchObj.SetActive(false);
                gameObject.GetComponent<Renderer>().material.color = Color.green;
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(time > 0)
        {

        }
        if(switchObj != null)
        {
            if (!on)
            {
                on = true;
                switchObj.SetActive(true);
                if(alternateSwitchObj != null)
                    alternateSwitchObj.SetActive(false);
                gameObject.GetComponent<Renderer>().material.color = Color.green;
            }
            else
            {
                on = false;
                switchObj.SetActive(false);
                if (alternateSwitchObj != null)
                    alternateSwitchObj.SetActive(true);
                gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
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
