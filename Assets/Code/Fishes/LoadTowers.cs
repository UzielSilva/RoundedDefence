using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RoundedDefence.Components.Fishes;
using System;
using System.Reflection;
using System.Linq;
using RoundedDefence;

public class LoadTowers : MonoBehaviour {

    Dictionary<int, IFish> Fishes;
    // Use this for initialization
    void Start()
    {
        if (Lib.Fishes == null) { 
            Fishes = new Dictionary<int, IFish>();
            string[] @namespace = {
                                    "RoundedDefence.Components.Fishes.Linears",
                                    "RoundedDefence.Components.Fishes.Radials",
                                    "RoundedDefence.Components.Fishes.Roundeds",
                                    "RoundedDefence.Components.Fishes.Statics",
                                    "RoundedDefence.Components.Fishes.Targets",
		                            "RoundedDefence.Components.Fishes.Actives"

                                };

            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && (@namespace.Contains(t.Namespace))
                    select t;

            foreach (Type t in q)
            {
                IFish fish = (IFish)Activator.CreateInstance(t);
                int id = fish.Id;

                Fishes.Add(id, fish);
            }
            Lib.Fishes = Fishes;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
