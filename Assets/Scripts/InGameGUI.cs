using UnityEngine;
using System.Collections;

public class InGameGUI : MonoBehaviour {
    [HideInInspector]
    public GameObject targetCam;
    [HideInInspector]
    public bool dontClone;
    [HideInInspector]
    public int x;

    private Transform[] children;

	void Start ()
    {
        if (!dontClone)
        {
            gameObject.layer = 28;
            targetCam = GameObject.Find("Camera1");
            children = GetComponentsInChildren<Transform>();
            foreach (Transform c in children)
                c.gameObject.layer = gameObject.layer;
            for (int i = 1; i < 4; i++)
            {
                GameObject clone = Instantiate(gameObject, transform.position, Quaternion.identity) as GameObject;
                clone.GetComponent<InGameGUI>().dontClone = true;
                clone.layer = gameObject.layer + i;
                children = clone.GetComponentsInChildren<Transform>();
                foreach (Transform c in children)
                    c.gameObject.layer = gameObject.layer + i;
                clone.GetComponent<InGameGUI>().targetCam = GameObject.Find("Camera" + (i + 1).ToString());
                clone.name = gameObject.name + " clone " + (i + 1).ToString();
            }
        }
	}

    void LateUpdate()
    {
        transform.forward = -targetCam.transform.forward;
    }
}
