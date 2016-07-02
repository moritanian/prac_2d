using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
	Armyデータ形式
	myArmy List<int>
	Enemy List<int>
*/
public class BattleField : MonoBehaviour {

	public static float Xsize = 100.0f, Ysize = 100.0f;

	// Use this for initialization
	void Start () {
		debug_init();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Init(List<int> myArmy, List<int> Enemy){

	}

	void debug_init(){
		List<int> myArmy = new List<int>();
		List<int> Enemy = new List<int>();
		myArmy.Add(10);
		Enemy.Add(10);
		Init(myArmy, Enemy);
	}
}
