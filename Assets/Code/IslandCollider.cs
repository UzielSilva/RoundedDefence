using UnityEngine;
using System.Collections;

public class IslandCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D collision){
		print ("collided");
	}
	void OnCollision2D(Collision2D collision){
		print ("collided2");
	}
}
