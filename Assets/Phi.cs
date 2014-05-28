using UnityEngine;
using System.Collections;
using RoundedDefence;
using System.Collections.Generic;

public class Phi : MonoBehaviour {
	public Sprite sprite;
	float phi=1.6180339887f;
	float radius=.5f;
	float angle=0;
	int n=231;
	public Path camino;

	public Font font;
	public Material material;
	// Use this for initialization
	void Start () {
		int[] map=new int[231];
		for (int e = 0; e < 231; e++) {
			map[e] = 10;
		}
		map[200-21] = 1000;
		map[200-34] = 1000;
		ShortPath p = new ShortPath (200, 50,map);
		camino = p.getPath ();
		for (int i=21; i<n; i++) {
			radius=Mathf.Pow(i, phi-1)/5;
			angle=2 * Mathf.PI * phi * i;
			GameObject g=new GameObject("pto"+i);
			TextMesh t=g.AddComponent<TextMesh>();
			t.font=font;
			t.fontSize = 17;
			MeshRenderer m=g.GetComponent<MeshRenderer>();
			m.material = material;
			if(p.valueMap[i]!=999999)
				Lib.setString (g, (p.valueMap[i])+"_"+(i%8));
			
			g.transform.position=new Vector3(Mathf.Cos(angle)*radius,Mathf.Sin(angle)*radius,0f);
			g.transform.localScale=new Vector3(.1f,.1f,.1f);
		}
		int uu = 0;
		foreach (Camino ca in camino.camino) {
			radius=Mathf.Pow(ca.lvl, phi-1)/5;
			angle=2 * Mathf.PI * phi * ca.lvl;
			GameObject g=new GameObject("aaa"+uu);
			TextMesh t=g.AddComponent<TextMesh>();
			t.font=font;
			t.fontSize = 15;
			MeshRenderer m=g.GetComponent<MeshRenderer>();
			m.material = material;
				Lib.setString (g, "*"+uu++);
			
			g.transform.position=new Vector3(Mathf.Cos(angle)*radius,Mathf.Sin(angle)*radius+.12f,0f);
			g.transform.localScale=new Vector3(.1f,.1f,.1f);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
