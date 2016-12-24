using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

    void Awake()
    {
        //gameObject.hideFlags = HideFlags.HideInHierarchy;
    }

	void FixedUpdate ()
    {
        transform.localEulerAngles = transform.localEulerAngles + new Vector3(0, 0, -4);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player" && GetComponent<Dead>().enabled == false)
            StartCoroutine(Collected());
    }

    IEnumerator Collected()
    {
        yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
        Destroy(gameObject);
    }
}
