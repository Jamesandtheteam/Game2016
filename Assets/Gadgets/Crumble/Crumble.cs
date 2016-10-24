using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Crumble : MonoBehaviour {
    private Rigidbody[] rigChildren;
    private bool fade;
    public GameObject crumblePrefab;

    void Awake()
    {
        rigChildren = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody r in rigChildren)
        {
            r.angularDrag = 10;
            r.gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        StartCoroutine(CrumbleGo());
    }

    IEnumerator Disappear(GameObject g)
    {
        yield return new WaitForSeconds(7 + Random.Range(-1f, 1f));
        fade = true;
        yield return new WaitForSeconds(3);
        fade = false;
        Destroy(g);
    }

    void Update()
    {
        if (fade)
        {
            foreach (Rigidbody r in rigChildren)
            {
                r.GetComponent<Renderer>().material.color = Color.Lerp(r.GetComponent<Renderer>().material.color, Color.clear, Time.fixedDeltaTime / 2);
            }
        }
    }

    IEnumerator CrumbleGo()
    {
        yield return new WaitForSeconds(0.25f);
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        foreach (Rigidbody r in rigChildren)
        {
            r.gameObject.SetActive(true);
            StartCoroutine(Disappear(r.gameObject));
        }
    }
}
