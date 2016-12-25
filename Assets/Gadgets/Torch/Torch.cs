using UnityEngine;
using System.Collections;

public class Torch : MonoBehaviour {
    private Light lit;
    private float _intensity;

    void Awake()
    {
        lit = GetComponent<Light>();
    }

	void FixedUpdate()
    {
        _intensity = Random.Range(0.75f, 1.5f);
        lit.intensity = Mathf.Lerp(lit.intensity, _intensity, Time.deltaTime * 5);
    }
}
