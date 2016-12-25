using UnityEngine;
using System.Collections;

public class Potato : MonoBehaviour {
    private float t = 10;
    private GameObject throwGuide;
    public Vector3 offset;

    void Awake()
    {
        throwGuide = transform.FindChild("ThrowGuide").gameObject;
    }

	void OnCollisionEnter(Collision col)
    {
        //pick up potato
        if (col.gameObject.tag == "Player" && t > 0.25f)
        {
            transform.parent = col.gameObject.transform;
            transform.localPosition = offset;
            transform.localEulerAngles = Vector3.zero;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        //handle if potato bumps into something other than shield door
        else
        {
            print("Ouch!");
            //transform.parent = null;
        }
    }

    void Update()
    {
        //fix position of potato
        if(transform.localPosition != offset && transform.parent != null)
            transform.localPosition = offset;

        //fix rotation of potato
        if(transform.localEulerAngles != Vector3.zero && transform.parent != null)
            transform.localEulerAngles = Vector3.zero;

        //throw potato
        if (Input.GetKeyUp(KeyCode.JoystickButton1) && transform.parent != null)
        {
            GetComponent<Rigidbody>().velocity = (transform.parent.forward + transform.parent.up) * 14;
            transform.parent = null;
        }
        //drop potato
        if (Input.GetKeyUp(KeyCode.JoystickButton3) && transform.parent != null)
        {
            GetComponent<Rigidbody>().velocity = (transform.parent.forward * 4) + (transform.parent.up * 10);
            transform.parent = null;
        }
        //fix gravity
        if (transform.parent == null && GetComponent<Rigidbody>().useGravity != true)
        {
            GetComponent<Rigidbody>().useGravity = true;
            t = 0;
        }

        //make it so you can't insta-pick-up the potato again
        if (transform.parent == null && t < 0.25f)
            t += Time.deltaTime;

        //when button is held down guide arrow appears
        if (Input.GetKey(KeyCode.JoystickButton1) && transform.parent != null)
            throwGuide.SetActive(true);
        else
            throwGuide.SetActive(false);
    }
}
