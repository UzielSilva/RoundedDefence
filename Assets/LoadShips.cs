using UnityEngine;
using System;
using System.Reflection;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using RoundedDefence.Components.Ships;
using RoundedDefence;

public class LoadShips : MonoBehaviour {

    Dictionary<String, IShip> Ships;
	// Use this for initialization
	void Start () {

        Ships = new Dictionary<string, IShip>();
        string @namespace = "RoundedDefence.Components.Ships.Types";

        var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                where t.IsClass && t.Namespace == @namespace
                select t;

        foreach (Type t in q)
        {
            IShip ship = (IShip)Activator.CreateInstance(t);
            String id = ship.Id;

            Ships.Add(id, ship);
        }
        Lib.Ships = Ships;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
