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
        if (Lib.data == null)
        {
            _FileLocation = Application.dataPath;
            Read();
            Lib.setCurrentLevel("normal", 1, 1);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void Read () {
        TextAsset[] textAssets;
        textAssets = Resources.LoadAll<TextAsset>("Data");
        foreach (TextAsset text in textAssets)
        {
            _data += text.text;
        }
		_data += "</levels>";
		Lib.data = XDocument.Parse(_data);
    }
}
