using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public float deadZone = 0.1f;
	public float speed = 7;
	public float jumpHeight = 1.75f;

    //can be used by other scripts
    [HideInInspector]
    public float upVel;

	private Rigidbody rig;
	private Camera cam;
	private GameObject xFixed;
	private bool grounded;
	private float c;
	private bool jumpStopReady;
    private Vector3 fwd;
    public Animator anim;
    private RaycastHit rch;
    private float colHeight;
    private float slopeAngle;
    private float targetSprint;
    private float hInput;
    private float vInput;

    private float jumpModifier = 1;
    private float slopeModifier = 1;
    private float sprintModifier = 0.5f;
    

    //input preferences
    [HideInInspector]
    public string jumpButton;
    [HideInInspector]
    public string horizontalAxis;
    [HideInInspector]
    public string verticalAxis;
    [HideInInspector]
    public string interact;
    [HideInInspector]
    public string sprint;

    [Range(1, 4)]
    public int playerNumber;

    void Awake(){
		rig = GetComponent<Rigidbody> ();
        cam = GameObject.Find("Camera" + playerNumber.ToString()).GetComponent<Camera>();
		xFixed = GameObject.Find ("X Fixed" + playerNumber.ToString());
        if(anim != null)
            anim = transform.GetChild(0).GetComponent<Animator>();
        colHeight = GetComponent<Collider>().bounds.extents.y;
    }
		
	void Update(){
        //get joystick input
        hInput = Input.GetAxis(horizontalAxis);
        vInput = Input.GetAxis(verticalAxis);

        //check for jump input
        if (Input.GetButtonDown (jumpButton) && grounded && upVel == 0) {
			upVel = jumpHeight * 10;
			jumpStopReady = true;
		}

        //make sure you can't press jump, then move out from under object and have delayed jump
        if (Input.GetButtonUp(jumpButton))
            upVel = 0;

        //variable jump stop by releasing jump button
        if (Input.GetButtonUp (jumpButton) && rig.velocity.y > 0 && jumpStopReady) {
			rig.velocity = new Vector3 (rig.velocity.x, 0, rig.velocity.z);
			jumpStopReady = false;
		}
    }

    void LateUpdate()
    {
        if (anim != null)
        {
            //send velocity to animator
            anim.SetFloat("MoveVelocity", c);
            anim.SetFloat("y", rig.velocity.y);
        }
    }

	void FixedUpdate () {
        //check if grounded
        if (Physics.Raycast(transform.position, -Vector3.up, out rch))
        {
            //get slope of object underneath player
            slopeAngle = Vector3.Angle(rch.normal, Vector3.up);
            
            //if raycast down detects object below player's feet
            if (rch.distance <= colHeight + 0.3f)
            {
                grounded = true;
                jumpModifier = 1;
            }
            //if raycast down hits nothing within distance
            else
            {
                grounded = false;
                jumpModifier = 0.125f;
                slopeAngle = 0;
            }
        }
        //if raycast down hits nothing at any distance
        else
        {
            grounded = false;
            jumpModifier = 0.125f;
            slopeAngle = 0;
        }

        //creates slope modifier if going uphill
        if (rig.velocity.y > 0)
            slopeModifier = -(slopeAngle / 90) + 1;
        else
            slopeModifier = 1;

        //make sure horizontal speed doesn't grow exponentially
        if (grounded)
            rig.velocity = new Vector3(0, rig.velocity.y, 0);
            

		//sideways movement and applies modifiers
		if (Mathf.Abs (hInput) > deadZone)
			rig.velocity += hInput * cam.transform.right * speed * sprintModifier * jumpModifier * slopeModifier;

		//forward and backwards movement and applies modifiers
		if (Mathf.Abs (vInput) > deadZone)
			rig.velocity += vInput * xFixed.transform.forward * speed * sprintModifier * jumpModifier * slopeModifier;

        //jump, or other upward movements
        if (grounded && upVel != 0)
        {
            rig.velocity = new Vector3(rig.velocity.x, upVel, rig.velocity.z);
            upVel = 0;
        }

		//adjust for diagnal movement
		c = Mathf.Sqrt(Mathf.Pow(rig.velocity.x, 2) + Mathf.Pow(rig.velocity.z, 2));
		if (c > speed * sprintModifier) {
			float y = rig.velocity.y;
			rig.velocity /= (c / speed) / sprintModifier;
			rig.velocity = new Vector3 (rig.velocity.x, y, rig.velocity.z);
		}

		//look towards movement		
        fwd = new Vector3 (rig.velocity.x, 0, rig.velocity.z);
		if (fwd.sqrMagnitude != 0)
			gameObject.transform.forward = Vector3.Lerp(gameObject.transform.forward, fwd, Time.deltaTime * 10);

        //handle gradual sprint (factored into different if statements)
        //check if input is being given and also if player is moving
        if ((Mathf.Abs(hInput) >= deadZone || Mathf.Abs(vInput) >= deadZone) && (rig.velocity.x != 0 && rig.velocity.z != 0) && targetSprint != 1)
            {
                targetSprint = 1;
            }
            else
            {
                targetSprint = 0.5f;
            }
        if (Input.GetAxis(sprint) != 0)
        {
            targetSprint = 2;
        }
        sprintModifier = Mathf.Lerp(sprintModifier, targetSprint, Time.deltaTime * 5);
    }

    public void death()
    {
        rig.constraints = RigidbodyConstraints.None;
        rig.velocity = Vector3.zero;
        GetComponent<Renderer>().material.color = Color.red;
        this.enabled = false;
    }
}
