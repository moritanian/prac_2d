using UnityEngine;
using System.Collections;

public class UserDataDispForMats : UserData {	//素材ページユーザ情報表示部分用

	static TextObj _money;
	static TextObj _rowmat;
	static TextObj _alloy;
	// Use this for initialization
	void Start () {
		base.Init();
		_money = MyCanvas.Find<TextObj>("money");
		_rowmat = MyCanvas.Find<TextObj>("usermaterial");
		_alloy = MyCanvas.Find<TextObj>("alloytxt");
		DispUserDat ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public static void DispUserDat(){
		_money.Label = "Money  $" + money.ToString ();
		/*_rowmat.Label = "";
		_alloy.Label = "";
	*/
	}
}
