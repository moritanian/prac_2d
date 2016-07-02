using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingDialog : Dialog {

	Slider _bgm_slider = null;
	Slider _se_slider = null;
	public AudioClip SE_ON_Sound;

	void Start () {
		//_settingdialog = MyCanvas.FindChild<CountryDialog>("SettingDialog");
		SetBGMSlider(Settings.BGM_val);
		SetSESlider((Settings.Is_SE ? 1 : 0));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void SetBGMSlider(float val){
		_bgm_slider = _bgm_slider ?? GameObject.Find("BGMSlider").GetComponent<Slider>();
		_bgm_slider.value = val;
	}
	public void SetSESlider(float val){
		_se_slider = _se_slider ?? GameObject.Find("SESlider").GetComponent<Slider>();
		_se_slider.value = val;
	}
	public void BGMvalue(float val){
		Settings.SetBGM(val);
	}
	public void SEvalue(float val){
		Settings.SetSE(val == 1);
		if(val == 1){
			SoundManager.instance.RandomizeSfx(SE_ON_Sound);
		}
	}

	public void OnClickBack(){	//設定終了
		Vanish();
	}
	//SoundManager.instance.SetVolume(0.12f);
}
