using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SubTextSettings : MonoBehaviour {
	public Component x;

	void Awake () {
		Resize ();
	}

	void Resize(){
		GetComponent<RectTransform> ().anchoredPosition = new Vector3(0, -Screen.height / 3, 0);
		GetComponent<Text> ().fontSize = Screen.height / 17;
	}

	void TextUpdate(string _text){
		GetComponent<Text> ().text = _text;
	}
}
