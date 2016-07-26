using UnityEngine;
using System.Collections;

public class Talk : MonoBehaviour {
	private int x;
	public AudioClip[] lineClips;
	[TextArea(3,10)]
	public string[] lineText;
	public Animation[] lineAnimation;
	private MonoBehaviour subText;
	private MonoBehaviour charCont;
	public bool speaking;
	private GameObject _player;
	private AudioSource aud;

	void Awake(){
		subText = GameObject.Find ("SubText").GetComponent<SubTextSettings> ();
		aud = GetComponent<AudioSource> ();
	}

	void FreezePlayer(GameObject player){
		//freeze player to correct y position

		_player = player;
		//_player.GetComponent<CharacterMove> ().frozen = true;
		_player.GetComponent<Rigidbody> ().velocity = new Vector3 (0, _player.GetComponent<Rigidbody> ().velocity.y, 0);

		speaking = true;

	}

	void _update () {
		//play animation
		subText.SendMessage ("TextUpdate", lineText [x]);
		aud.clip = lineClips [x];
		aud.Play ();
	}

	void Update(){
		if (speaking) {
			// face character
		}
		if (Input.GetButtonDown("Escape") && speaking) {
			done ();
		}
		if (Input.GetButtonDown ("Enter") && speaking) {
			Revise ();
		}
	}

	void done(){
		//done
		aud.Pause();
		aud.clip = null;
		x = 0;
		subText.SendMessage ("TextUpdate", "");
		speaking = false;
		//_player.GetComponent<CharacterMove> ().frozen = false;
		_player = null;
	}

	void Revise(){
		x++;
		if (x < lineText.Length) {
			_update ();
		}
		if (x >= lineText.Length) {
			done();
		}
	}
}