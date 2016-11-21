using UnityEngine;
using System.Collections;

public class WalkBridge : MonoBehaviour {
    private GameObject[] players;
    private Vector3[] playerPrevPos;
    private Vector3 offset = new Vector3(0, 1.5f, 0);
    public GameObject bridgePart;
    public bool[] _active;

    private bool obstaclePresent;

    void Awake()
    {
        _active = new bool[4];
        for (int i = 0; i < 4; i++)
            _active[i] = true;
        players = GameObject.FindGameObjectsWithTag("Player");
        playerPrevPos = new Vector3[4];
        for (int i = 0; i < 4; i++)
        {
            playerPrevPos[i] = players[i].transform.position;
            players[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        }
        StartCoroutine(MoveCheck());
    }

    void Update()
    {
        for (int i = 1; i < 5; i++)
        {
            if(Input.GetKeyDown("joystick " + i + " button 1"))
            {
                if (_active[i - 1] == true)
                {
                    _active[i - 1] = false;
                    return;
                }
                if (_active[i - 1] == false)
                {
                    _active[i - 1] = true;
                    return;
                }
            }
        }
    }

    IEnumerator MoveCheck()
    {
        for (int i = 0; i < 4; i++)
        {
            if (playerPrevPos[i] != players[i].transform.position)
            {
                playerPrevPos[i] = players[i].transform.position;
                obstaclePresent = Physics.CheckBox(players[i].transform.position - offset + players[i].transform.forward, new Vector3(0.5f, 0.5f, 0.5f), Quaternion.identity, 1, QueryTriggerInteraction.Ignore);
                if (!obstaclePresent && _active[int.Parse(players[i].name.Substring(players[i].name.Length - 1, 1)) - 1] == true)
                    Build(players[i]);
                //if (obstaclePresent)
                    //players[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            }
            else
                players[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        }
        yield return new WaitForSeconds(0.05f);
        StartCoroutine(MoveCheck());
    }

    void Build(GameObject p)
    {
        Instantiate(bridgePart, p.transform.position - offset, Quaternion.identity);
    }
}
