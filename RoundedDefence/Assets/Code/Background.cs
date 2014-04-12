using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

    float transparency=0f;
	bool transDirection=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position += Vector3.down * Time.deltaTime * 0.1f;
		transform.Rotate(Vector3.forward, Time.deltaTime); 
		if (transDirection) {
			transparency-=.005f;
			if(transparency<0.3f){
				transparency=0f;
				transDirection=!transDirection;
			}

		} else {
			transparency+=.005f;
			if(transparency>.7f){
				transparency=1f;
				transDirection=!transDirection;
			}
		}
		Color c = renderer.material.color;
		c.a = transparency;
		renderer.material.color = c;
	}
}
