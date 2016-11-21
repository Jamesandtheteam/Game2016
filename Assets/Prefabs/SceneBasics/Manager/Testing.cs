using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Testing : MonoBehaviour {
    private float t;

	void Update () {
        if (Input.GetKeyUp("joystick button 6") && t < 3)
        {
            int scene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }

        if (Input.GetKey("joystick button 6"))
        {
            t += Time.deltaTime;
        }
        if(t >= 3)
        {
            GameObject.Find("Camera1").GetComponent<Camera>().rect = new Rect(0, 0, 1, 1);
            GameObject.Find("Camera2").GetComponent<Camera>().enabled = false;
            GameObject.Find("Camera3").GetComponent<Camera>().enabled = false;
            GameObject.Find("Camera4").GetComponent<Camera>().enabled = false;
        }
        //ADD FUNCTION WHERE I CAN CHANGE WHO IM CONTROLLING WITH ONLY ONE CONTROLLER
	}
}
