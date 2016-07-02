using UnityEngine;
using System.Collections;
using System.IO;
using System;



public class FileIO : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void Write(string filename){
		StreamWriter sw;
		FileInfo fi;
		string path = Application.dataPath + "/IOfiles/" + filename;
		fi = new FileInfo(path);
		sw = fi.CreateText();
		sw.WriteLine ("this is test.\n this is the end line");
		sw.Flush();
		sw.Close ();
		Debug.Log (path);

	}

}
