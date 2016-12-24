using UnityEngine;
using System.Collections;

public class LandMine : MonoBehaviour {
    private Vector3 initialPos;
    private Quaternion initialRot;
    private float explosionRadius = 4;

    public bool fixedPosition;
    [HideInInspector]
    public bool exploding;
    public AudioClip audioClip;

    void Awake()
    {
        name = "LandMine";

        exploding = false;

        initialPos = transform.position;
        initialRot = transform.rotation;

        if (fixedPosition)
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }

        //set up audio component
        if (GetComponent<AudioSource>() == false)
            gameObject.AddComponent<AudioSource>();
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().volume = 0.8f;
        GetComponent<AudioSource>().clip = audioClip;
    }

	void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.GetComponent<Rigidbody>() == true)
            Explode();
    }

    public void Explode()
    {
        exploding = true;
        Collider[] cols = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider hit in cols)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null && hit.gameObject != gameObject)
            {
                rb.AddExplosionForce(2000, transform.position + (Vector3.up * 3), explosionRadius, 30);
            }
            //kill players
            if (hit.tag == "Player")
                hit.GetComponent<Movement>().death();
            //explode other mines nearby
            if (hit.GetComponent<LandMine>() == true && hit.gameObject != gameObject && hit.GetComponent<LandMine>().exploding == false)
                hit.GetComponent<LandMine>().Explode();
        }
        GetComponent<AudioSource>().Play();
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        foreach(Transform c in transform)
            c.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        GameObject mine = Instantiate(gameObject, initialPos, initialRot) as GameObject;
        mine.GetComponent<Collider>().enabled = true;
        mine.GetComponent<MeshRenderer>().enabled = true;
        foreach (Transform c in mine.transform)
            c.GetComponent<MeshRenderer>().enabled = true;
        Destroy(gameObject);
    }
}
