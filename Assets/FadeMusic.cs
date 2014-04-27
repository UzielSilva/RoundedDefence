using UnityEngine;
using System.Collections;

public class FadeMusic : MonoBehaviour {
	float fade=1f;
	float speed=-.04f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		fade += speed;
		if (fade < 0f) {
				changemusic ();
				speed = -speed;
				fade = 0;
		}
		if ( fade > 1f) {
			Camera.main.audio.volume=1f;
			Destroy (this.gameObject);
		}
		Camera.main.audio.volume=fade;
	
	}
	void changemusic(){
		AudioSource audioSource = Camera.main.gameObject.GetComponent<AudioSource>();
		audioSource.clip = Resources.Load("Music/music/" + gameObject.transform.name) as AudioClip;
		audioSource.loop = true;
		audioSource.Play();
	}
}
