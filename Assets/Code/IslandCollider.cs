using UnityEngine;
using System.Collections;

public class IslandCollider : MonoBehaviour {
	public static int lives=3;
	// Use this for initialization
	void Start () {
		lives = 3;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D collision){
		lives--;
		if(lives==1)
		Application.LoadLevel ("levelLose");
	}
}
