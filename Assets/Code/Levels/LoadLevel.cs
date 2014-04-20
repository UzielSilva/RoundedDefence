using UnityEngine;
using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Xml.Linq;
using System.IO;
using System.Text;
using RoundedDefence;

public class LoadLevel : MonoBehaviour {
	public string LevelId{get;set;}
	private string _data = "<levels>\n";
	private XDocument data;
    private string _FileLocation;
    // Use this for initialization
	void Start () {
        _FileLocation = Application.dataPath;
        LoadLevels();
		
		//		string @namespace = "RoundedDefence.Components.Levels.Normal";

		var q = from t in data.Element(XName.Get("levels")).Elements(XName.Get("level"))
				where t.Attribute(XName.Get("id")).Value == LevelId
				select t;
		Lib.currentLevel = q.ToArray()[0];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void LoadLevels () {
        string[] dir = Directory.GetFiles(_FileLocation + "\\Code\\Levels\\Data\\");
        foreach(string s in dir){
			if(s.Substring(s.Length - 4) == ".xml"){
				StreamReader r = File.OpenText(s);
	            string _info = r.ReadToEnd();
	            r.Close();
	            _data += _info;
			}
        }
		_data += "</levels>";
		data = XDocument.Parse(_data);
    }
}
