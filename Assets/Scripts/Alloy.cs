using UnityEngine;
using System.Collections;

/// <summary>
/// 合金一覧画面制御クラス
/// 初めての画面遷移で、ここで一覧を取得し、データを保持する。このデータに所有フラグをつける。
/// </summary>
public class Alloy : Token {

	//Gui object
	static TextObj _NameTxt;
	static TextObj _TSnum;
	static TextObj _YMnum;
	static TextObj _CRnum;
	static TextObj _IngredientList;

	const int SprNum = 2;
	//static AlloyDat[] _alloydat = new AlloyDat[SprNum];
	static AlloyDat[] AlloyList = new AlloyDat[SprNum];// 
//	static AlloyDat[] AlloyDat = AlloyDat.GetAlloyList ();
	static int ListGetflg = 0;	//初めて画面来た時、合金リスト取得（static として保存）
	static int Cur = 0;

	public static int _Cur {
		get { return Cur;}
	}
	static int IfGetList(){
		return Alloy.ListGetflg;
	}
	static void ListGotten(){
		Alloy.ListGetflg = 1;
	}
	static void GetAlloyList(){
		int num = AlloyDat.DATNUM;
		for (int i= 0; i<num; i++) {
			AlloyDat.GetAlloyDatById(i,ref AlloyList[i]);
		}
	}
	// Use this for initialization
	void Start () {
		if (Alloy.IfGetList () == 0) {
			AlloyList = AlloyDat.GetAlloyList ();
			//GetAlloyList ();
			ListGotten ();
		}

		_NameTxt = MyCanvas.Find<TextObj>("NameTxt");
		_TSnum = MyCanvas.Find<TextObj>("TSnum");
		_YMnum = MyCanvas.Find<TextObj>("YMnum");
		_CRnum = MyCanvas.Find<TextObj>("CRnum");
		_IngredientList = MyCanvas.Find<TextObj>("IngredientList");

		CreateAlloySpr ();


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void CreateAlloySpr(){	//画面遷移時にスプライト生成
		for (int i=0; i<SprNum; i++) {
			AlloySpr.Add(i,AlloyList[i]._ownned,-4.7f, -i*3.5f);
		}
		Cur = 0;
		
	}

	static void PutAlloyData(AlloyDat alloy){	//合金データ表示
		_NameTxt.Label = alloy._name;
		_TSnum.Label = alloy._TS.ToString ("f1");
		_YMnum.Label = alloy._YM.ToString("f1");
		_CRnum.Label = alloy._CR.ToString("f1");
		string txt = "";
		//for(int i=0;i<2;i++){
		for (int i=0; i<alloy._originnum; i++) {
			if (i != 0)
				txt += ",";
			txt += alloy._OriginMats(i)._name;
			//txt += alloy._OriginMats(i)._name;
		}
		_IngredientList.Label= txt;

	}

	public void dummy_set(){
		
		
	}

	public void OnClickBack(){
		Back();
	}

	public void Back(){
		Application.LoadLevel("Material");
	}

	public static void ChangeCur(int num){
		if (0 <= Cur + num && Cur + num <= SprNum - 1) {
			Cur += num;
			PutAlloyData(AlloyList[Cur]);
		}

	}

}
