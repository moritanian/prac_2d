using UnityEngine;
using System.Collections;

public class StartSelectCountry : CountryDialog {	//ゲーム開始時の国決め画面用の国ダイアログ用

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnClickSelect(){	//自国確定
		UserData.SetMyCtry(MapScene.SelectedCtryId);
		MapScene.SelectedCtryId = 0;	//国選択解除
		Set (0);
		Application.LoadLevel("Map");
	}
	public void OnClickCancel(){
		MapScene.SelectedCtryId = 0;	//国選択解除
		Set (0);
	}
}
