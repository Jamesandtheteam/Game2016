using UnityEngine;
using System.Collections;

public class HighFive : MonoBehaviour {
    private GameObject[] players;
    [HideInInspector]
    public GameObject targetPlayer;
    [HideInInspector]
    public float t;

    enum state {none, host, guest}
    state playerState;

    void Awake()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        t = 0;
    }

	void Update ()
    {
        if (playerState == state.none)
        {
            if (Input.GetKeyDown("joystick " + name.Substring(name.Length - 1, 1) + " button 1"))
            {
                targetPlayer = null;
                float minDist = Mathf.Infinity;
                foreach (GameObject p in players)
                {
                    if (p != gameObject && p.GetComponent<HighFive>().playerState == state.none)
                    {
                        float dist = Vector3.Distance(p.transform.position, transform.position);
                        if (dist < minDist)
                        {
                            targetPlayer = p;
                            minDist = dist;
                        }
                    }
                }
                //if button is pressed and player is close enough, tag them
                if (minDist < 4)
                {
                    targetPlayer.GetComponent<HighFive>().t = 0;
                    targetPlayer.GetComponent<HighFive>().playerState = state.host;
                    targetPlayer.GetComponent<HighFive>().targetPlayer = gameObject;
                    t = 0;
                    playerState = state.guest;
                }
            }
        }

        if (playerState == state.guest)
        {
            t += Time.fixedDeltaTime;
            //if player is currently guest and has died and target player is still alive, revive at the position of the target player
            if(GetComponent<Dead>().enabled == true && targetPlayer.GetComponent<Dead>().enabled != true)
            {
                GetComponent<Dead>().Revive(targetPlayer.transform.position);
                playerState = state.none;
                targetPlayer.GetComponent<HighFive>().playerState = state.none;
            }
        }

        if (playerState == state.host)
        {
            t += Time.fixedDeltaTime;
        }

        //if time runs out, return to null state
        if(t > 10)
        {
            playerState = state.none;
        }
    }
}
