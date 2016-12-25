using UnityEngine;
using System.Collections;

public class Knight : MonoBehaviour {
    public float triggerDistance;
    public float moveSpeed;
    public int health = 3;

    private Rigidbody rig;
    private GameObject[] players;
    private GameObject minPlayer;
    private float minDist;
    private GameObject targetPlayer;
    private float attackTime;
    private float blockCoolDown;

    enum state {idle, patrolling, attacking, block, hit, dead};
    state AIstate;

    void Awake ()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        rig = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate ()
    {
        //find closest player
        minDist = Mathf.Infinity;
        foreach (GameObject p in players)
        {
            //make sure cloest player is alive
            if (p.GetComponent<Dead>().enabled == false && p != targetPlayer)
            {
                float dist = Vector3.Distance(p.transform.position, transform.position);
                if (dist < minDist)
                {
                    minDist = dist;
                    minPlayer = p;
                }
            }
        }
        if (AIstate != state.attacking && AIstate != state.block)
        {
            if (minDist < triggerDistance)
                AIstate = state.patrolling;
            else
                AIstate = state.idle;
        }

        //check if player can strike enemy
        if(minDist < 5 && Input.GetKeyDown("joystick " + minPlayer.name.Substring(minPlayer.name.Length - 1, 1) + " button 1"))
        {
            minPlayer.GetComponent<Rigidbody>().AddForce((transform.position - minPlayer.transform.position) * 5000 + (Vector3.up * 2000));
            if (AIstate == state.attacking)
                AIstate = state.hit;
            else
                AIstate = state.block;
        }

        //STATES CONTAINED BELOW

        if (AIstate == state.patrolling)
        {
            //face closest player
            transform.LookAt(minPlayer.transform.position);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

            rig.velocity = transform.forward * moveSpeed;
        }


        if(AIstate == state.attacking)
        {
            targetPlayer.GetComponent<Movement>().enabled = false;
            targetPlayer.transform.position = Vector3.Lerp(targetPlayer.transform.position, transform.position + (transform.forward * 2), Time.fixedDeltaTime * 3);
            attackTime += Time.fixedDeltaTime;
            if (attackTime > 4)
            {
                targetPlayer.GetComponent<Movement>().death();
                AIstate = state.idle;
                targetPlayer = null;
                attackTime = 0;
            }
        }

        if(AIstate == state.block)
        {
            transform.LookAt(minPlayer.transform.position);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

            rig.velocity = Vector3.zero;
            blockCoolDown += Time.fixedDeltaTime;

            if (blockCoolDown > 1)
            {
                AIstate = state.idle;
                blockCoolDown = 0;
            }
        }

        if(AIstate == state.hit)
        {
            health--;
            rig.AddForce(transform.position - minPlayer.transform.position * -20);
            targetPlayer = null;
            attackTime = 0;
            AIstate = state.idle;
        }

        if (health <= 0)
            Destroy(gameObject);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject == minPlayer)
        {
            if(AIstate != state.attacking && AIstate != state.block)
            {
                targetPlayer = col.gameObject;
                attackTime = 0;
                AIstate = state.attacking;
            }
            //PROBLEM IS I NEED TO CHECK FOR THE DIFFERENCE BETWEEN A PLAYER TOUCHING THE KNIGHT BECAUSE HE'S CAUGHT AND BECAUSE HE'S ATTACKING THE KNIGHT
        }
    }
}
