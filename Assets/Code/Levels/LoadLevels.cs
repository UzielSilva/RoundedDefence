using UnityEngine;
using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Xml.Linq;
using System.IO;
using System.Text;
using RoundedDefence;

public class LoadLevels : MonoBehaviour {
	private string _data = "<levels>\n";
    private string _FileLocation;
    // Use this for initialization
	void Start () {
        _FileLocation = Application.dataPath;
        Read();
		Lib.setCurrentLevel("N.1.1");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void Read () {
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
		Lib.data = XDocument.Parse(_data);
    }
}
