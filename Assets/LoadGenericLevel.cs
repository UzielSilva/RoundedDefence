using UnityEngine;
using System.Collections;
using RoundedDefence;

public class LoadGenericLevel : MonoBehaviour {

    GameObject background;
    GameObject island;

	// Use this for initialization
    void Start()
    {
        Lib.mute();
        background = GameObject.Find("background");
        island = GameObject.Find("island");
        GameObject camera = GameObject.Find("Camera");
        AudioSource audioSource = camera.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load("Music/music/" + Lib.currentLevel.Attribute("background-music").Value) as AudioClip;
        audioSource.Play();
        Lib.setSprite(background, "Sprites/Background/" + Lib.currentLevel.Attribute("background-image").Value);
        Lib.setSprite(island, "Sprites/Islands/" + Lib.currentLevel.Attribute("unlocked-sprite").Value);
        Lib.newFade();
        Lib.unfades();
	}
	
	// Update is called once per frame
	void Update () {

        if (!Lib.isFading())
        {
            Lib.faderr();
        }
	}
}
