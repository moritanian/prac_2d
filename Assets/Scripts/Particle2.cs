using UnityEngine;
using System.Collections;

public class Particle2 : Token {

	//プレハブ
	static GameObject _prefab = null;

	public static Particle2 Add(float X, float y)
	{

		_prefab = GetPrefab (_prefab, "Particle2");

		return CreateInstance2<Particle2> (_prefab, X, y);

	}

	// Use this for initialization
	IEnumerator Start () {
		float dir = Random.Range (0, 359);
		float spd = Random.Range (10.0f, 20.0f);
		SetVelocity (dir, spd);

		//ClampScreen ();
		while (ScaleX > 0.01f)  // 見えなくなるよう縮小
		{
			yield return new WaitForSeconds(0.01f);
			MulScale (0.9f);
			MulVelocity(0.9f);

		}
		DestroyObj ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Move(float x,float y){
		
		//X = x;
		//Y = y;
		ClampScreen();
	}

}
