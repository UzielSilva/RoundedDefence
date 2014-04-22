using UnityEngine;
using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using RoundedDefence.Components.Fishes;

public class LoadTowerGUI : MonoBehaviour {
//	public string LevelName;
	// Use this for initialization
	void Start () {
		string passives = "RoundedDefence.Components.Fishes.Passives";
		string actives = "RoundedDefence.Components.Fishes.Actives";

		var q = from t in Assembly.GetExecutingAssembly().GetTypes()
			where t.IsClass && !t.IsAbstract && (t.Namespace == passives || t.Namespace == actives)
				select t;
		foreach (Type t in q){
			string s = t.Name;
			IFish fish = (IFish)Activator.CreateInstance(t);
			Debug.Log ("The value of property 'RequiredFood' of the class " + s + " is " + fish.RequiredFood);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
