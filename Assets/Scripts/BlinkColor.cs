using UnityEngine;
using System.Collections;

public class BlinkColor : MonoBehaviour {
    public Color[] colors;
    public float timeInterval;
    private int x;


	void Awake ()
    {
        x = Random.Range(0, colors.Length - 1);
        StartCoroutine(Blink());
	}
	
	IEnumerator Blink()
    {
        GetComponent<MeshRenderer>().material.color = colors[x];
        yield return new WaitForSeconds(timeInterval);
        if (x + 1 < colors.Length)
            x++;
        else
            x = 0;
        StartCoroutine(Blink());
    }
}
