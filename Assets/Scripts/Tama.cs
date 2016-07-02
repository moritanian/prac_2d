using UnityEngine;
using System.Collections;

public class Tama : Token {

	/// 管理オブジェクト
	public static TokenMgr<Tama> parent = null;

	//玉の数
	public static int Count = 0;
	private int Hp;
	private int MaxHp;
	private HpGage hpgage;
	static GameObject _prefab = null;
	
	public static Tama Add(float x, float y)
	{
	
		Tama tama = parent.Add(x,y);
		if(tama == null)
		{
				return null;
		}

		//tama.Init(path);
		return tama;
	}



	// Use this for initialization
	void Start () {
		Count++;	//オブジェクトごとに呼ばれるのでこれで生成される数だけカウントできる
		SetSize (SpriteWidth / 2, SpriteHeight / 2);
		float dir = Random.Range (0, 359);
		float spd = 1;
		SetVelocity (dir, spd);

		Hp = 1000;
		MaxHp = 1000;
		hpgage = HpGage.Add (X ,Y - 1);
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 min = GetWorldMin();
		Vector2 max = GetWorldMax();
		if(X < min.x || max.x < X)   // XはTokenで定義されている。継承されているのでそのまま使える？
		{
			VX *= -1;
			ClampScreen();
		}
		if(Y < min.y || max.y < Y)   // XはTokenで定義されている。継承されているのでそのまま使える？
		{
			VY *= -1;
			ClampScreen();
		}
		hpgage.Move (X + 0.4f, Y - 0.8f );
		hpgage.SetHp (MaxHp, Hp);
	}
	public void OnMouseDown()
	{
		Hp -= 500;
		if(Hp<=0)Vanish ();
	
	}



	new private void Vanish(){

		Count--;

		if (Random.Range (0, 2) == 1) {

			Explosion.Add (X, Y);
		} else {
			for (int i=0; i<32; i++) {
				Particle2.Add (X, Y);
			
			}
		}
		DestroyObj();
		hpgage.DestroyObj ();
		if (Count == 0) {
			
		}
	}

}