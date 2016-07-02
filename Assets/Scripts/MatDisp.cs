using UnityEngine;
using System.Collections;

public class MatDisp : Token {

	const int SprNum = 5;
	const int SprDispNum = 3;
	public static int Cur;
	public static float MatDisty = 3.5f;
	static Mat2 SelectedMat1 = null;
	static Mat2 SelectedMat2 = null;

	//キャラデータ
	static MatDat[] _matdat = new MatDat[SprNum];


	public AudioClip PageSound;	//ページ移動音
	public AudioClip BGM;

	//Gui object
	static TextObj _nameout;
	static TextObj _TSout;
	static TextObj _YMout;
	static TextObj _CRout;
	static TextObj _SyntaxTxt;
	static ButtonObj _SyntaxButton;
	static SyntaxDialog _dialog;

	public Sprite[] Spr = new Sprite[SprNum];

	public int GuiBflg=0 ;
	public int GuiBonflg = 0;

	// Use this for initialization
	void Start () {
		for (int i=0; i<SprNum; i++) {
			_matdat[i] = new MatDat();
			MatDat.GetMatById(i,_matdat[i]);
			SoundManager.instance.PlaySingle(BGM);
		}
		/*
		_matdat[0].InsertDat("Stainless" , 10.0, 10.0 , 10.0 );
		_matdat[1].InsertDat("Cupper" , 5.0, 6.0 , 50.0 );
		_matdat[2].InsertDat("Steel" , 2.0, 2.0 , 30.0 );
		_matdat[3].InsertDat("Brass" , 13.0, 11.0, 20.0 );
		_matdat[4].InsertDat("Duralmin", 5.0, 1.0 , 60.0 );
		*/
		_nameout = MyCanvas.Find<TextObj>("Nameout");
		_TSout = MyCanvas.Find<TextObj>("TSout");
		_YMout = MyCanvas.Find<TextObj>("YMout");
		_CRout = MyCanvas.Find<TextObj>("CRout");
		_SyntaxTxt = MyCanvas.Find<TextObj>("SyntaxTxt");
		_SyntaxButton = MyCanvas.Find<ButtonObj>("SyntaxButton");

		for (int i=0; i<SprNum; i++) {
			Mat2.Add(i,i,(float)(i*MatDisty) - MatDisty,-2.7f,0,_matdat[Cur+1]);

		}
		Cur = 0;
	
		DispSyntaxMoney ();
		MatParDisp(1);

		_dialog = MyCanvas.Find<SyntaxDialog>("Dialog");
		//_dialog.Vanish ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){

	}

	public static int GetSyntaxMoney(){ //合成に必要な金
		return 500;
	}
	void DispSyntaxMoney(){
		string txt = "Syntax $" + (GetSyntaxMoney()).ToString();
		_SyntaxTxt.Label = txt;
	}

		//キャラをセレクトした
	public void OnClickMatSelect(){
		MatSelect();
	}
		//キャラ指定解除
	public void OnclickMatReselect(){
		MatReselect ();
	}
	public void OnclickBack(){
		SoundManager.instance.RandomizeSfx(PageSound);
		Back ();
	}
	public void OnclickGoAlloyList(){
		SoundManager.instance.RandomizeSfx(PageSound);
		GoAlloyList ();
	}


	public static bool ChangeCur(int p){
		if (-1 <= Cur + p && Cur + p < SprNum-1) {
			Cur += p;
			//_nameout.SetLabelFormat("Money: ${0}", Global.Money);
			MatParDisp (Cur + 1);
			return true;
		} else return false;

	}

	public static void MatParDisp(int id){	//表示するマテリアルデータ変更
		_nameout.Label = _matdat[id]._name;
		_TSout.Label = _matdat[id]._TS.ToString("f1");
		_YMout.Label = _matdat[id]._YM.ToString("f1");
		_CRout.Label = _matdat[id]._CR.ToString("f1");
	}

	public static void MatSelect(){
		SelectedMat1 = Mat2.Add(Cur + 1,Cur + 1,-1.5f,1.0f,1,_matdat[Cur+1]);
	}
	public static void MatReselect(){
		SelectedMat1.Vanish ();


	}
	public void OnclickSyntax(){
		Syntax ();

	}
	public void Syntax(){	//合成するボタンを押した(確認ダイアログの表示)


		int neededmoney = GetSyntaxMoney ();
		//_dialog.Revive ();	//ダイアログ表示
	
		if (UserData.money >= neededmoney) {
			string txt = "$"+ neededmoney.ToString() + "消費して合成します。\nよろしいですか？";
			_dialog.Set(1,txt);
			//GuiBflg = 1;
		} else {
			_dialog.Set (2,"合成に必要な金額が足りません。");
			//GuiBflg = 2;
		}

		

		
	}
	public void Syntaxbutton(){	//ボタンの色　所持金不足の時薄く
		if (UserData.money < GetSyntaxMoney ()) {
			//_SyntaxButton.SetAlpha  (0.5f);
			//_SyntaxButton.Enabled = false;
		} else {
			_SyntaxButton.Enabled = true;
		}
	}




	public void Back(){
		SoundManager.instance.RandomizeSfx(PageSound);
		SoundManager.instance.musicSource.Stop();
		Application.LoadLevel("Map");
	}
	public void GoAlloyList(){
		SoundManager.instance.RandomizeSfx(PageSound);
		SoundManager.instance.musicSource.Stop();
		Application.LoadLevel("Syntax");
	}
}
