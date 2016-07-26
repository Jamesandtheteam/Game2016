using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    public void activate()
    {
        //send trigger to animator controller that either opens or closes door
        if (GetComponent<Animator>().GetBool("up") == false)
        {
        GetComponent<Animator>().SetBool("up", true);
        return;
        }
        if (GetComponent<Animator>().GetBool("up") == true)
        {
            GetComponent<Animator>().SetBool("up", false);
        }
    }
}
