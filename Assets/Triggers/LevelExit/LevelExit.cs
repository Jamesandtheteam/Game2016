using UnityEngine;
using System.Collections;

public class LevelExit : MonoBehaviour {
    private GUImenu g;

    void Awake()
    {
        g = GameObject.Find("Manager").GetComponent<GUImenu>();
    }

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            g.ExitLevelVote();
            g.exitActive = true;
        }
    }
    
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {   
            g.exitActive = false;

            //i dont know why im leaving this here but i am

            //THIS IS HOW YOU GET PLAYER NUMBER FROM THEIR NAME
            //int.Parse(col.name.Substring(col.name.Length - 1, 1));

            //THIS IS HOW YOU CALL SOMETHING 4 TIMES
            //for (int i = 0; i < 4; i++)

            for (int i = 0; i < 4; i++)
                g.Inactive(i);
        }
    }
}