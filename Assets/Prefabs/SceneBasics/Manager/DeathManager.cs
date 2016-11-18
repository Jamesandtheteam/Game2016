using UnityEngine;
using System.Collections;

public class DeathManager : MonoBehaviour {
    private GameObject[] players;
    public GameObject[] alivePlayers;
    public GameObject[] deadPlayers;

    private int deathCount;

    void Awake()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

	void Update ()
    {
        alivePlayers = new GameObject[4];
        int i = 0;
        foreach (GameObject p in players)
        {
            if (p.GetComponent<Dead>().enabled == false)
            {
                alivePlayers[i] = p;
            }
            i++;
        }

        deathCount = 0;
        deadPlayers = new GameObject[4];
        foreach (GameObject p in players)
        {
            if(p.GetComponent<Dead>().enabled == true)
            {
                deadPlayers[deathCount] = p;
                deathCount++;
            }
        }
        if (deathCount == 4)
            GameOver();
	}

    void GameOver()
    {
        print("GAME OVER");
    }
}
