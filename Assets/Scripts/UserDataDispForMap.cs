using UnityEngine;
using System.Collections;

public class UserDataDispForMap : UserData {	//map画面ユーザ情報表示用

	static UserDataDispForMap _userdata;	//自分のインスタンスをstatic に持つ

	TextObj _ctryname;
	TextObj _numofconq;	//征服国数


	// Use this for initialization
	void Start ()  {
		base.Init ();
		_userdata = MyCanvas.Find<UserDataDispForMap>("UserData");
		_ctryname = MyCanvas.Find<TextObj>("MyCtryName");
		_numofconq = MyCanvas.Find<TextObj>("NumofConq");
		//CountryDat myctry = CountryDat.SearchById(MyCtryId);
		CountryDat myctry = CountryDat.SearchById(MyCtryId);
		SetData (myctry.name, OwnnedCtryIds.Length);
		Debug.Log (myctry.name);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	static void SetData(string name ,int NumofConq){

		_userdata._ctryname.Label = name;
		_userdata._numofconq.Label = NumofConq.ToString();
	
	}





}
