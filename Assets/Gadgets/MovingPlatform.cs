using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
    public Vector3[] travelPositions;
    public float speed;
    private int x;
    private Vector3 _velocity;

    void FixedUpdate()
    {
        //check if close (within 0.1)
        if (Vector3.Distance(transform.position, travelPositions[x]) < 0.1f)
            x++;
        if (x >= travelPositions.Length)
            x = 0;
        Vector3 moveDir = (travelPositions[x] - transform.position).normalized;
        transform.Translate(moveDir * speed * Time.fixedDeltaTime);
    }
}
