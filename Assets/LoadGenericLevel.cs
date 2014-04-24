using System;
using System.Xml.Linq;
using UnityEngine;
using System.Collections;
using RoundedDefence;

public class LoadGenericLevel : MonoBehaviour {

    GameObject background;
    GameObject island;
    bool doAnimation = true;
    float timer = 0;
    int count = 3;
    public string countSprite;
    GameObject counter;

	// Use this for initialization
    void Start()
    {
        Lib.mute();
        counter = new GameObject("counter");
        counter.transform.position = new Vector3(0, 0, 0);
        counter.AddComponent<SpriteRenderer>();
        background = GameObject.Find("background");
        island = GameObject.Find("island");
        GameObject camera = GameObject.Find("Camera");
        AudioSource audioSource = camera.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load("Music/music/" + Lib.currentLevel.Attribute("background-music").Value) as AudioClip;
        audioSource.loop = true;
        audioSource.Play();
        Lib.setSprite(background, "Sprites/Background/" + Lib.currentLevel.Attribute("background-image").Value);
        Lib.setSprite(island, "Sprites/Islands/" + Lib.currentLevel.Attribute("unlocked-sprite").Value);
        Lib.newFade();
        Lib.unfades();
	}
	
	// Update is called once per frame
	void Update () {
        if (!doAnimation)
        {

        }

        if (!Lib.isFading())
        {
            Lib.faderr();
        }
        else if (doAnimation)
            Animation();
	}
    void Animation()
    {
        if (timer == 0)
        {
            timer = Time.time;
            Lib.setSprite(counter, "Sprites/Misc/" + countSprite + count);
            SpriteRenderer sprRenderer = counter.GetComponent<SpriteRenderer>();
            sprRenderer.sortingLayerName = "Others";
        }
        var stateTime = Time.time - timer;
        int restSeconds = (int)(stateTime);
        if (restSeconds == 1)
        {
            timer = Time.time;
            count--;
            Lib.setSprite(counter, "Sprites/Misc/" + countSprite + count);
            if (count < 0)
            {
                doAnimation = false;
                Lib.setSprite(counter, "");
            }
        }
    }
}
