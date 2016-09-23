using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour {

    private RespawnManager respawnManager;

    void Awake()
    {
        respawnManager = GameObject.Find("Manager").GetComponent<RespawnManager>();
    }

    void OnTriggerEnter (Collider c) {
	    if(c.GetComponent<Movement>() == true)
            respawnManager.SendMessage("Respawn", c.gameObject);
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
