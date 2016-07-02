using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// 敵クラス
public class Mat : Token {
	
	const int SprNum = 5;
	
	//プレハブ
	static GameObject _prefab = null;
	
	
	public Sprite[] Spr = new Sprite[SprNum];
	
	int MySpr;	//スプライト画像番号

	int Stat = 0;

	
	// プレハブからキャラを至誠
	public static Mat Add(int SprNum, int MyNum ,float x,float y) //(Sprite spr)
	{
		_prefab = GetPrefab (_prefab, "Mat");
		
		Mat mat = CreateInstance2<Mat> (_prefab, x,y);
		if (mat) {
			//mat.X = x;
			//mat.Y = y;

		}
		return mat;
	}
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
