using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	void FixedUpdate ()
    {
        transform.localEulerAngles = transform.localEulerAngles + new Vector3(0, 0, -7);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
            StartCoroutine(Collected());
    }

    IEnumerator Collected()
    {
        yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
        Destroy(gameObject);
    }
}
