using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BranchData  {

	// コンストラクタ
 	public BranchData (BranchType Bt, string Jpname, int maxHitPoint, int intelligence, int defense, int agility, int resource ){
 		_branch_type = Bt;
 		_jpName = Jpname;
 		_max_hitpoint = maxHitPoint;
 		_intelligence = intelligence;
 		_defense = defense;
 		_agility = agility;
 		_resource = Resource;
 	}

	public enum BranchType {
		Infantory,	// 歩兵
		Shield,	// 盾
		Medical, //衛星兵
		Hoplite,	// 重装歩兵

	}

	BranchType _branch_type;
	public BranchType Branch{
		get {return _branch_type;}
	}

	string _jpName = "兵科";
	public string JpName{
		get {return _jpName;}
	}

	int _hitpoint; //体力
	public int HitPoint  {
		get{ return _hitpoint;}
	}

	int _max_hitpoint;
	public int MaxHitPoint {
		get {return _max_hitpoint;}
	}
	
	int _intelligence; //攻撃力
	public int Intelligence {
		get {return _intelligence;}
	}

	int _defense; // 防御力
	public int Defense {
		get {return _defense;}
	}
	
	int _agility; //素早さ
	public int Agility {
		get {return _agility; }
	}
	
	int _resource; //必要資源
 	public int Resource {
 		get {return _resource;}
 	}

 	
 	public static BranchData GetBranch(BranchType Bt){

 		BranchData branch = null;
 		switch (Bt){
 			case BranchType.Infantory:
 				branch = new BranchData(BranchType.Infantory, "歩兵", 1000, 100,  30, 100, 100);
 				break;
 			case BranchType.Shield:
 				branch = new BranchData(BranchType.Shield, "盾兵", 1000, 0, 80, 100, 100);
 				break;
 			case BranchType.Hoplite:
 				branch = new BranchData(BranchType.Hoplite, "重装歩兵", 2000, 200, 50, 150, 250);
 				break;
 			case BranchType.Medical:
 				branch = new BranchData(BranchType.Medical, "衛星兵", 800, 0, 0, 100, 150);
 				break;
 			default:
 				break;
 		}
 		return branch;
 	}

}
