using UnityEngine;
using System.Collections;

public class TouchSound : MonoBehaviour {
    public bool playerOnly;
    public AudioClip audio;
    [Range(0, 1)]
    public float volume;

    void Awake()
    {
        if (GetComponent<AudioSource>() == false)
            gameObject.AddComponent<AudioSource>();

        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().volume = volume;
        GetComponent<AudioSource>().clip = audio;
    }

    void OnCollisionEnter(Collision col)
    {
        if (playerOnly)
        {
            if (col.gameObject.tag == "Player")
            {
                GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            GetComponent<AudioSource>().Play();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (playerOnly)
        {
            if (col.gameObject.tag == "Player")
            {
                GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
