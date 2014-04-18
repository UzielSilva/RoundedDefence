using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

    float transparency=0f;
	bool transDirection=false;
	public float direction=0f;
	public bool animations=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position += Vector3.down * Time.deltaTime * 0.1f;
		transform.Rotate (Vector3.forward, Time.deltaTime*direction);
		if (animations) {
						if (transDirection) {
								transparency -= 0.005f;
								if (transparency < 0.3f) {
										transparency = 0.3f;
										transDirection = !transDirection;
								}

						} else {
								transparency += 0.005f;
								if (transparency > 0.7f) {
										transparency = 0.7f;
										transDirection = !transDirection;
								}
						}
						Color c = renderer.material.color;
						c.a = transparency;
						renderer.material.color = c;
				}
	}
}
