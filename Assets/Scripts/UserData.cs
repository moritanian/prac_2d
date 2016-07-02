using UnityEngine;
using System.Collections;

public class UserData : Token {
 	static int Money;

	static protected int MyCtryId = 2;
	static protected int[] OwnnedCtryIds = new int[]{};
	static int IsInit = 0;	//かつてここに画面遷移したか
	static int SaveVer ;	//セーブデータの番号

	// Use this for initialization
	void Start () {
		Init ();
	}

	protected void Init(){
		if(IsInit == 0){
			Money = 1000;
			//OwnnedCtryIds = new int[]{};
			IsInit = 1;
		}
	}
	// Update is called once per frame
	void Update () {
	
	}

	public static void SetMyCtry(int id){	//validationしたほうがいい
		MyCtryId = id;
	}

	public static int IsOwnnedCtry(int id){		
		for(int i=0; i<OwnnedCtryIds.Length;i++){
			if(id == OwnnedCtryIds[i])return 1;
		}
		return 0;
	}
	public static int IsEnableBattle(int ctryid){	//侵攻できるか
		if(0< ctryid && ctryid  <= CountryDat.num){
			if(UserData.MyCtryId == ctryid){
				return -2;
			}else if(UserData.IsOwnnedCtry(ctryid) == 1){
				return -3;
			}else {
				return 1;	//侵攻可能
			}
		}
		return -1;
	}
	


	public static int money{
		get{return UserData.Money;}
		set{UserData.Money = value;}
	}

	public static bool Save(int _savever){ //ユーザデータを保存する

		Hashtable intgmdata = new Hashtable();
		Hashtable strgmdata = new Hashtable();
		Hashtable fgmdata = new Hashtable();
		intgmdata.Add ("SaveVer",_savever);
		intgmdata.Add ("Money",money);
		intgmdata.Add ("MyCtryId",MyCtryId);
		return Util.SaveData(intgmdata,strgmdata,fgmdata);
	}
	//ゲームデータをロードする
	public static bool Load(int _savever){
		int _saved_savever = PlayerPrefs.GetInt("SaveVer");
		if(_saved_savever == _savever){
			money = PlayerPrefs.GetInt("Money");
			MyCtryId = PlayerPrefs.GetInt("MyCtryId");

		}else{
			return false;
		}
		return true;
	}
}
