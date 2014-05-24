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

        Fishes = new Dictionary<int, IFish>();
        string @namespace = "RoundedDefence.Components.Fishes.Passives";

        var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                where t.IsClass && t.Namespace == @namespace
                select t;

        foreach (Type t in q)
        {
            IFish fish = (IFish)Activator.CreateInstance(t);
            int id = fish.Id;

            Fishes.Add(id, fish);
        }
        Lib.Fishes = Fishes;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
