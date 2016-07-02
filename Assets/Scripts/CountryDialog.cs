using UnityEngine;
using System.Collections;

public class CountryDialog : Dialog {

	static TextObj _ctryname;
	static TextObj _ctryExtxt;//説明文
	static TextObj _ctrypwtxt;
	static TextObj _productiontxt;
	static CountryDialog _ctrydialog; //自分自身をstaticに持つ
	static ImageObj _flagimage ;	//旗の画像

	const int num = 9;
	public Sprite[] flgspr = new Sprite[num];



	// Use this for initialization
	void Start () {
		//for(int i=0; i<num;i++ ){
		//	flgspr[i] = new Sprite();
		//}
	}

	void Init(){
		_ctryname = MyCanvas.Find<TextObj>("CtryName");
		_ctryExtxt = MyCanvas.Find<TextObj>("CtryEx");
		_ctrypwtxt = MyCanvas.Find<TextObj>("Ctrypw");
		_productiontxt = MyCanvas.Find<TextObj>("Production");
		_ctrydialog = MyCanvas.Find<CountryDialog>("Dialog");
		_flagimage = MyCanvas.Find<ImageObj>("flag");
	}
	// Update is called once per frame
	void Update () {
	
	}

	public static void Set(int stat, CountryDat ctrydat = null){
		if(_ctrydialog==null){
			_ctrydialog = MyCanvas.FindChild<CountryDialog>("Dialog");
		}
		if (stat == 0) {
			Debug.Log("vanish");
			_ctrydialog.Vanish ();
		} else {
			_ctrydialog.Revive();
			_ctrydialog.Init();
			_ctryname.Label = ctrydat.name;
			_ctryExtxt.Label = ctrydat.extxt;
			_ctrypwtxt.Label = _ctrydialog.GetPowerTxt (ctrydat.power);
			_flagimage.image = (_ctrydialog.flgspr[ctrydat.id - 1]);
		}
	}
	public string GetPowerTxt(int power){
		string txt = "";
		if (power == 0)
			txt = "Piccolo";
		else if (power == 1)
			txt = "Normale";
		else if (power == 2)
			txt = "Grande";

		return txt;
	}

	new public void  OnClickYes(){
		Debug.Log("Yes");
		MapScene.SelectedCtryId = 0;	//国選択解除
		//base.OnClickYes ();
		Vanish ();
	}
}
