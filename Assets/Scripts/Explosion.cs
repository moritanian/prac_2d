using UnityEngine;
using System.Collections;

public class Explosion : Token {


	//プレハブ
	static GameObject _prefab = null;
	
	public static Explosion Add(float X, float y)
	{
		
		_prefab = GetPrefab (_prefab, "Explosion");
		
		return CreateInstance2<Explosion> (_prefab, X, y);
		
	}

	public void AnimationEnd(){
		this.Vanish ();
	}
	void Start(){


	}
	// Update is called once per frame
	void Update () {
	
	}
}
