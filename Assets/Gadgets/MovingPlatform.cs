using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
    public Vector3[] travelPositions;
    public float speed;
    private int x;
    private Vector3 _velocity;

    void Awake()
    {
        x = 0;
        gameObject.transform.position = travelPositions[x];
    }

    //This script generally works best with only 2 points
    //UNLESS you were to account for the 0.5 units of rounding per position when you make the travelPositions

    void FixedUpdate()
    {
        //check if close (within 0.5)
        if (Vector3.Distance(transform.position, travelPositions[x]) < 0.5f)
            x++;
        if (x >= travelPositions.Length)
            x = 0;
        Vector3 moveDir = (travelPositions[x] - transform.position).normalized;
        transform.Translate(moveDir * speed * Time.fixedDeltaTime);
    }
}
