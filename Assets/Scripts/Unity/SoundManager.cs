using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public AudioSource efxSource; //効果音用AudioSource
	public AudioSource musicSource; //BGM用AudioSource
	public static SoundManager instance = null;
	//音の高さにバリエーションを付ける用の変数
	public float lowPitchRange = 1.00f;
	public float highPitchRange = 1.00f;
	
	UnityEngine.Audio.AudioMixer mixer;


	//シングルトンの処理
	void Awake ()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		
		DontDestroyOnLoad (gameObject);
	}
	
	//BGMの再生
	
	public void PlaySingle(AudioClip clip)
//	public IEnumerator PlaySingle (AudioClip clip)
	{
		/*
		while(!(musicSource == null)){
			yield return new WaitForSeconds(.1f);
		}
*/
		if(musicSource == null){
			
			Debug.Log("playSingle ref none");
		}
		musicSource.clip = clip;
		musicSource.volume = Settings.BGM_val;
		musicSource.Play();
		//}

	}

	public void SetBGMVolume(float volume){
		musicSource.volume = Settings.BGM_val;
	}

	public float GetBGMVolume(){
		return musicSource.volume;
	}
	
	public void StopBGM(){
		musicSource.Stop();
	}
	
	//数種類の効果音を受け取り、ランダムで再生
	public bool RandomizeSfx (params AudioClip[] clips)
	{
		// SEの設定確認
		if(!Settings.Is_SE)return false;
		//受け取った効果音番号をランダムで指定
		int randomIndex = Random.Range(0, clips.Length);
		//音の高さをランダムで指定
		float randomPitch = Random.Range(lowPitchRange, highPitchRange);
		efxSource.pitch = randomPitch;
		//受け取った効果音を選択
		efxSource.clip = clips[randomIndex];
		//効果音を再生
		efxSource.Play();
		return true;
	}


}