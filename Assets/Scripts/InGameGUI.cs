using UnityEngine;
using System.Collections;

public class InGameGUI : MonoBehaviour {
    [HideInInspector]
    public int x;
	
	void Start ()
    {
        gameObject.layer = 28;
        GameObject clone = Instantiate(gameObject, transform.position, Quaternion.identity) as GameObject;
        clone.GetComponent<InGameGUI>().enabled = false;
	}

}
