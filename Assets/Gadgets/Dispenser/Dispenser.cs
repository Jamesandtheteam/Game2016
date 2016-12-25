using UnityEngine;
using System.Collections;

public class Dispenser : MonoBehaviour {
    public GameObject obj;
    public float interval;
    private GameObject inObj;

    void OnEnable()
    {
        StartCoroutine(Dispense());
    }

    IEnumerator Dispense()
    {
        inObj = Instantiate(obj, transform.position, Quaternion.identity) as GameObject;
        if (inObj.GetComponent<Rigidbody>())
            inObj.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 5));
        yield return new WaitForSeconds(interval);
        StartCoroutine(Dispense());
    }

}
