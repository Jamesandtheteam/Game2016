using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
    private GameObject[] players;

    void Awake()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    void Update()
    {

    }
	
}
