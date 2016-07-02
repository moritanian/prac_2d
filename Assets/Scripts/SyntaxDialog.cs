using UnityEngine;
using System.Collections;

public class SyntaxDialog : Dialog {

	TextObj _dialogtxt;
	ButtonObj _yesbtn;
	ButtonObj _nobtn;
	int stat;


	// Use this for initialization
	void Start () {
		_dialogtxt = MyCanvas.Find<TextObj>("Dialogtxt");
		_yesbtn = MyCanvas.Find<ButtonObj>("YesButton");
		_nobtn = MyCanvas.Find<ButtonObj>("NoButton");
		_dialogtxt.Label = "a";
		Set (0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Set(int stat, string txt = ""){	//stat:0 消滅　1:生成　2:生成、エラー
		this.stat = stat;
		if (stat > 0) {
			Revive ();
			WriteTxt (txt);
			if (stat == 2) {	//noButton 消滅
				_nobtn.Vanish ();
			}
		} else {
			Vanish ();
		}

	}

	new public void OnClickYes(){
		if (stat == 1) {
			UserData.money -= MatDisp.GetSyntaxMoney ();
			UserDataDispForMats.DispUserDat ();
		}
		base.OnClickYes();
	}

	public void WriteTxt(string txt){
		_dialogtxt.Label = txt;
	}

	new public void OnClickNo(){
		base.OnClickNo ();
	}
}
