using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// 敵クラス
public class Mat2 : Token {

	const int SprNum = 5;

	//プレハブ
	static GameObject _prefab = null;


	public Sprite[] Spr = new Sprite[SprNum];

	int MySpr;	//スプライト画像番号
	int MyNum;	//左から何番目か
	int Cur;	//現在のカーソル
	int Stat = 0;
	int DispType;	//表示位置

	string Name;
	double TS;	//Tensile strength
	double YM;	//Young's modulus
	double CR;	//Corrosion resistance

	float mX = 0,mY = 0; //移動すべき量
	const float Xvelocity = 0.5f;

	// プレハブからキャラを至誠
	public static Mat2 Add(int SprNum, int MyNum ,float x,float y, int disptype = 0,MatDat _matdat = null) //(Sprite spr)
	{
		_prefab = GetPrefab (_prefab, "Mat 2");
		
		Mat2 mat = CreateInstance2<Mat2> (_prefab, x,y);
		if (mat) {
			//mat.X = x;
			//mat.Y = y;
			mat.SprSet (SprNum);
			mat.MyNum = MyNum;
			mat.DispType = disptype;
			if(disptype == 0){
				mat.Name = _matdat._name;
				mat.TS = _matdat._TS;
				mat.YM = _matdat._YM;
				mat.CR = _matdat._CR;
			}
		}
		return mat;
	}
	// Use this for initialization
	void Start () {
		SetSprite (Spr[MySpr]);
	
	}

	void CheckCur(){
		if (MatDisp.Cur != Cur) {
			Debug.Log ("dif");
			//Debug.Log (Cur);
			//Debug.Log (MatDisp.Cur);
			int a = Cur - MatDisp.Cur;
			Cur = MatDisp.Cur;
			mX+= MatDisp.MatDisty * a;
			Debug.Log (mX);
		}

	}
	void Move(){
		if (mX > 0.0f) {
			X += Xvelocity;
			mX -= Xvelocity;
		} else if (mX < 0.0f) {
			X -= Xvelocity;
			mX += Xvelocity;
		}
		//スケール
		if(Cur +1 == MyNum)SetScale (1.7f, 1.7f);
		else SetScale (1.0f, 1.0f);
	}


	// Update is called once per frame
	void Update () {
		if (DispType == 0) {
			CheckCur ();
			Move ();
		}
	}
	
	void SprSet(int MySpr){
		if(MySpr >=0)
			this.MySpr = MySpr;
		SetSprite (Spr [this.MySpr]);
	}
	void OnMouseDown()
	{
		if (Stat == 0) {
			Stat = 1;
			SetScale (1.7f, 1.7f);
		} else if (Stat == 1) {
			Stat = 0;
			SetScale (1.0f, 1.0f);
		}
	}
}
