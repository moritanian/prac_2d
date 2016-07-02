using UnityEngine;
using System.Collections;

public class HpGage : Token {

	private LeftHp lefthp;
	private int MaxHp, Hp;

	// Use this for initialization
	//プレハブ
	static GameObject _prefab = null;

	void Start (){
		lefthp = transform.FindChild("HpController").gameObject.GetComponent<LeftHp>();
	}
	public static HpGage Add(float x, float y)
	{
			
		_prefab = GetPrefab (_prefab, "HpGage");
		//Change (X, y, 20.0);
		return CreateInstance2<HpGage> (_prefab, x, y);
			
	}

	void Update(){

		lefthp.Draw ((float)(Hp)/(float)(MaxHp));

	}

	public void SetHp(int MaxHp ,int myHp){
		this.Hp = myHp;
		this.MaxHp = MaxHp;
	}

	public void Move(float x,float y){

		X = x;
		Y = y;
		ClampScreen();
	}





}
