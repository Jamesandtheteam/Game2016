using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
    public float maximumHearingDistance;

	void Update ()
    {
        AudioSource[] audioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach(AudioSource aud in audioSources)
        {
            if(aud.GetComponent<SoundSupervisor>() != true)
            {
                aud.gameObject.AddComponent<SoundSupervisor>();
                aud.gameObject.GetComponent<SoundSupervisor>().maximumHearingDistance = maximumHearingDistance;
            }
        }
	}
}
