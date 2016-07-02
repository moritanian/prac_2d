using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AlloySpr : Token {
	//プレハブ
	static GameObject _prefab = null;
	
	const int SprNum = 2;
	public Sprite[] Spr = new Sprite[SprNum];
	
	int MySpr;	//スプライト画像番号
	int MyNum;	//左から何番目か
	int Cur = 0;	//現在のカーソル
	int Stat = 0;
	int DispType;	//表示位置

	public static float SprDisty = 3.5f;
	 
 	int id;
	
	float mX = 0,mY = 0; //移動すべき量
	const float Yvelocity = 0.5f;
	
	// プレハブからキャラを至誠
	public static AlloySpr Add(int id,int type,float x,float y) //(Sprite spr)
	{
		_prefab = GetPrefab (_prefab, "AlloySpr");
		
		AlloySpr spr= CreateInstance2<AlloySpr> (_prefab, x,y);
		if (spr) {
			spr.SprSet(id);
			spr.id = id;
		}
		return spr;
	}
	// Use this for initialization
	void Start () {
	
	}
	

	void Move(){
		if (mY > 0.0f) {
			Y += Yvelocity;
			mY -= Yvelocity;
		} else if (mY < 0.0f) {
			Y -= Yvelocity;
			mY += Yvelocity;
		}
		//スケール
		if(Cur  == id)SetScale (1.7f, 1.7f);
		else SetScale (1.0f, 1.0f);
	}
	
	
	// Update is called once per frame
	void Update () {
		CheckCur ();
		Move ();
	}

	void SprSet(int MySpr){
		SetSprite (Spr [MySpr]);
	}

	void CheckCur(){
		if (Alloy._Cur != Cur) {
			int a = -Cur + Alloy._Cur;
			Cur = Alloy._Cur;
			mY+= AlloySpr.SprDisty * a;


		}
		
	}

}
