using UnityEngine;
using System.Collections;

// ゲームの設定を記述

public class Settings{

	public const bool map_create = true; // true で作る
	static float bgm_val = 0.2f;
	static bool is_SE = true;
	
	static public bool Is_SE{
		get{return is_SE;}
	}

	static public float BGM_val{
		get{return bgm_val;}
	}

	static public void SetBGM(float val){
		bgm_val = val;
		SoundManager.instance.SetBGMVolume(val);
	}
	static public void SetSE(bool SE){
		is_SE = SE;
		
	}


	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {
	
	}
}
