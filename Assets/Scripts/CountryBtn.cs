using UnityEngine;
using System.Collections;

public class CountryBtn : ImageObj {

	public AudioClip ClickSound;	//クリック音

	//const Num = 9;
	/*static string CtryNames[] = new string[]{
		"NapoliBtn",
		"PontificoBtn",
	};
	*/


	// Use this for initialization
	void Start () {
		ImageColor = new Color(0,0,0,0.0f);	//ボタンimageのスプライトを透過して表示しないようにする
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnclickForSelectCry(){
		CountryDat ctrydat = CountryDat.SearchByBtnName (this.name);
		//Debug.Log (ctrydat.btnname);
		//クリック音
		SoundManager.instance.RandomizeSfx(ClickSound);
		MapScene.SelectedCtryId = ctrydat.id;
		CountryDialog.Set (1, ctrydat);
	}

	public void OnClick(){
	
		CountryDat ctrydat = CountryDat.SearchByBtnName (this.name);
		//Debug.Log (ctrydat.btnname);
		//クリック音
		SoundManager.instance.RandomizeSfx(ClickSound);
		//if (ctrydat != null) {
			MapScene.Putouttxt("");
			MapScene.SelectedCtryId = ctrydat.id;
			CountryDialog.Set (1, ctrydat);
			
		//} else {
		//	Debug.Log ("fialed");
		//}

	
	
	}
}
