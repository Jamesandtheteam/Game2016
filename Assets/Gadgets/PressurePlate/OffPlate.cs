using UnityEngine;
using System.Collections;

public class OffPlate : MonoBehaviour {
    public GameObject targetObjOff;
    public GameObject targetObjOn;

    void OnCollisionStay(Collision col)
    {
        if(targetObjOff != null)
            targetObjOff.SetActive(false);

        if (targetObjOn != null)
            targetObjOn.SetActive(true);
    }

    void OnCollisionExit(Collision col)
    {
        if (targetObjOff != null)
            targetObjOff.SetActive(true);

        if (targetObjOn != null)
            targetObjOn.SetActive(false);
    }
}
