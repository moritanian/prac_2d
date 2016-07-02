using UnityEngine;
using System.Collections;

public class MapScene : Token {


	public static int SelectedCtryId = 0;	//選択されている国
	static TextObj _outtxt; 
	public AudioClip PageSound;	//ページ移動音
	public AudioClip BGM;
	public AudioClip ClickSound;
	public AudioClip SaveSound;
	public AudioClip LoadSound;
	// Use this for initialization
	SettingDialog _setting_dialog  = null;
	int _dialog_flg = 0; //ダイアログがでているかのフラグ
	public int DialogFlg{
		get{return _dialog_flg;}
	}

 	void Start () {
		_outtxt = MyCanvas.Find<TextObj>("OutText");
		SoundManager.instance.PlaySingle(BGM);
		//MyCanvas.SetActive("Dialog", true);
	
		//CountryDialog.Set (0);	//国詳細ダイアログ非表示

	}
	// Update is called once per frame
	void Update () {

	}

	

	public void OnClickSetup(){
		SoundManager.instance.RandomizeSfx(ClickSound);
		// Start 段階では取得できないみたいなのでここで取得
		_setting_dialog = _setting_dialog ?? MyCanvas.FindChild<SettingDialog>("SettingDialog");
		_setting_dialog.Revive();
		_dialog_flg = 2;
	}

	public void OnClickGoBase(){
		SoundManager.instance.RandomizeSfx(PageSound);
		SoundManager.instance.musicSource.Stop();
		//SoundManager.instance.SetBGMVolume(0);
		GoBase ();
	}

	public void OnClickGoBattle(){
		if(MapScene.SelectedCtryId > 0){	//国選択されている
			if(UserData.IsEnableBattle(MapScene.SelectedCtryId)==1){	//侵攻可能
				//Application.LoadLevel("TowerDefense");
				Application.LoadLevel("BattleField");
			}else{
				_outtxt.Label = "自国です。";
			}
		}	else {	//選択してくださいダイアログの表示
			_outtxt.Label = "侵攻する国を選択してください。";
		}
	}

	public void OnclickSearch(){
		if(MapScene.SelectedCtryId > 0){	//国選択されている
			if(UserData.IsEnableBattle(MapScene.SelectedCtryId)==1){	//侵攻可能
				//Application.LoadLevel("TowerDefense");
			}else{
				_outtxt.Label = "自国です。";
			}
		}	else {	//選択してくださいダイアログの表示
			_outtxt.Label = "偵察する国を選択してください。";
		}	
	}

	public void GoBase(){
		Application.LoadLevel("Material");
	}

	public static void Putouttxt(string txt){
		_outtxt.Label = txt;
	}
	public void OnClickSave(){
		if(UserData.Save(0)){
			SoundManager.instance.RandomizeSfx(SaveSound);
			Putouttxt ("セーブ出来ました！");
		}else{
			Putouttxt("セーブに失敗しました。");
		}
	}
	public void OnClickLoad(){
		if(UserData.Load(0)){
				SoundManager.instance.RandomizeSfx(LoadSound);
			Putouttxt("ロードできました!");
		}else{
			Putouttxt("ロードに失敗しました。");
		}
	}
	

}
