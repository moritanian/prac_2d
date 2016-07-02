using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dialog : Token {

	//プレハブ
	static GameObject _prefab = null;

	//TextObj _dialogtxt;
	Dialog _dialog = null;
	string txt;
	// プレハブからキャラを至誠 使用していない
	public static Dialog Add(string txt = "",float x = -30.0f ,float y = -30.0f , float width = 100.0f, float length = 70.0f) //(Sprite spr)
	{
		_prefab = GetPrefab (_prefab, "Dialog");
		
		Dialog dialog = CreateInstance2<Dialog> (_prefab, x,y);
		if (dialog) {
			//dialog.txt = txt;
		}
		return dialog;
	}

	

	// Use this for initialization
	void Start () {
		_dialog = GetComponent<Dialog>();
		//_dialogtxt = MyCanvas.Find<TextObj>("Dialogtxt");
		//_dialogtxt.Label = txt;
		//lefthp = transform.FindChild("HpController").gameObject.GetComponent<LeftHp>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void OnClickYes(){
		Vanish ();
	}

	public void OnClickNo(){
		Vanish ();
	}
}
