using UnityEngine;
using System.Collections;

public class SoundSupervisor : MonoBehaviour
{
    private AudioSource aud;
    private GameObject[] players;
    private float origVolume;
    private float targetVolume;
    private float targetPan;

    [HideInInspector]
    public float maximumHearingDistance;

    void Awake()
    {
        aud = GetComponent<AudioSource>();
        players = GameObject.FindGameObjectsWithTag("Player");
        origVolume = aud.volume;
        aud.spatialBlend = 0;
        aud.volume = targetVolume;
    }

    void Update()
    {
        if (aud.isPlaying)
            CalcPositions();

        if (Mathf.Abs(aud.panStereo - targetPan) > 0.01f)
            aud.panStereo = targetPan;
        else
            aud.panStereo = Mathf.Lerp(aud.panStereo, targetPan, Time.fixedDeltaTime * 4);
    }

    void CalcPositions()
    {
        float minDist = Mathf.Infinity;
        float leftSideDist = 0;
        float rightSideDist = 0;
        foreach (GameObject p in players)
        {
            //finds distance from gameobject to closest player
            float dist = Vector3.Distance(p.transform.position, transform.position);
            if (dist < minDist)
            {
                minDist = dist;
            }
            //finds relative distance of players on left and right side of screen and pans audio accordingly
            if (Vector3.Distance(p.transform.position, transform.position) < maximumHearingDistance)
            {
                if (int.Parse(p.name.Substring(p.name.Length - 1, 1)) == 1 || int.Parse(p.name.Substring(p.name.Length - 1, 1)) == 3)
                    leftSideDist += Vector3.Distance(p.transform.position, transform.position);

                if (int.Parse(p.name.Substring(p.name.Length - 1, 1)) == 2 || int.Parse(p.name.Substring(p.name.Length - 1, 1)) == 4)
                    rightSideDist += Vector3.Distance(p.transform.position, transform.position);

                targetPan = (rightSideDist - leftSideDist) / (leftSideDist + rightSideDist);
            }
        }

        //creates and applies volume modifier
        float volumeModifier;

        if (minDist <= maximumHearingDistance)
            volumeModifier = 1 - (minDist / maximumHearingDistance);
        else
            volumeModifier = 0;

        targetVolume = origVolume * volumeModifier;

        if(targetVolume <= 0.1f)
            aud.volume = Mathf.Lerp(aud.volume, targetVolume, Time.fixedDeltaTime * 10);
        else
            aud.volume = targetVolume;
    }
}