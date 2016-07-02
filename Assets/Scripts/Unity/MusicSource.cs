using UnityEngine;
using System.Collections;

public class MusicSource : MonoBehaviour {

	public AudioSource efxSource; //効果音用AudioSource
	public AudioSource musicSource; //BGM用AudioSource
	public static MusicSource instance = null;
	

	//シングルトンの処理
	void Awake ()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		
		DontDestroyOnLoad (gameObject);
	}
	
}
