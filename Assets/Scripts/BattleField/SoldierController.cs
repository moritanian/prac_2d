using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class SoldierController {
	int _size = 0;
	List<GameObject> _prefabs = null;
	List<Soldier> _pool = null;
	public delegate void FuncT(Soldier t);

	// 兵士管理クラス 生成、保持
	// Use this for initialization
	public SoldierController () {
		_pool = new List<Soldier>();
		_prefabs = new List<GameObject>();

		foreach(BranchData.BranchType Bt in Enum.GetValues(typeof(BranchData.BranchType))){
			string prefabName = Bt.ToString("G");
			GameObject _prefab = Resources.Load("Prefabs/"+prefabName) as GameObject;
    		if(_prefab == null) {
      			Debug.LogError("Not found Prefabs/"+prefabName);
    		}
			_prefabs.Add(_prefab);
		}
	}
	
	

	public Soldier Add(BranchData.BranchType Bt, Vector3 pos){
		_size ++;
		GameObject prefab = GetPrefab(Bt);
		if(prefab == null)Debug.LogError("Not found Prefabs/"+ Bt.ToString("G"));
		GameObject g = GameObject.Instantiate(prefab, pos, Quaternion.identity) as GameObject;
		Soldier soldier= g.GetComponent<Soldier>();
		_pool.Add(soldier);
		return soldier;
	}

	GameObject GetPrefab(BranchData.BranchType Bt){
		return _prefabs[(int)Bt];
	}

	/// 生存するインスタンスに対してラムダ式を実行する
	public void ForEachExists(FuncT func) {
		foreach(var obj in _pool) {
			if(obj.Exists) {
				func(obj);
      	}
      }
  }
	 /// 指定のTokenに一番近いインスタンスを返す
  /// ※見つからなかった場合は null
  public Soldier Nearest(Token3D t1) {
    Soldier ret = null;
    float distance = float.MaxValue;
    ForEachExists(t2 => {
      var d = Util.Distance3DBetween(t1, t2);
      if(d < distance) {
        distance = d;
        ret = t2;
      }
    });
    return ret;
  }
}
