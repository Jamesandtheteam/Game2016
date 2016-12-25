using UnityEngine;
using System.Collections;

public class RepeatSound : MonoBehaviour {
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume;
    public float timeInterval;
    private bool play = true;

    void Awake ()
    {
        if (GetComponent<AudioSource>() == false)
            gameObject.AddComponent<AudioSource>();
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().volume = volume;
        GetComponent<AudioSource>().clip = audioClip;

        StartCoroutine(Cycle());
    }

    IEnumerator Cycle()
    {
        if (play)
            GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(timeInterval);
        if (play)
            play = false;
        else
            play = true;
        StartCoroutine(Cycle());
    }
}
