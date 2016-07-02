using UnityEngine;
using System.Collections;

// 兵士基底クラス
public class Soldier : Token3D {


	// 管理オブジェクト
	public static SoldierController parent = null;

	// プレハブから作成
	public static Soldier Add(BranchData.BranchType Bt, Vector2 pos)
	{
		// Todo 場所指定
		Soldier s = parent.Add(new Vector3(pos.x , 10, pos.y));
		if(s == null)
		{
			return null;
		}
		s.Init(Bt, pos);
		return s;
	}


	BranchData.BranchType _branch_type;

	public enum Army{ //所属する軍
		West,	// 左側　	
		East	// 右側
	}
	Army _army = Army.West;

	public enum ControllState{
		Auto, //バラバラに活動
		Controlled // 整列
	}
	ControllState _controllstate = ControllState.Auto;

	BranchData param = null;
	Vector2 _pos = default(Vector2);
 	// Use this for initialization
	
	void Init(BranchData.BranchType Bt, Vector2 pos){
		_branch_type = Bt;
		_controllstate = ControllState.Auto;
		BranchData BtData = BranchData.GetBranch(Bt);
		this.param = BtData;
		_pos = pos;
	}

/*
	/// 消滅
	public override void Vanish()
	{
		// TODO 敵味方でパーティクル色変える
    // パーティクル生成
    // リングエフェクト生成
		{
		// 生存時間は30フレーム。移動はしない
			Particle p = Particle.Add(Particle.eType.Ring, 30, X, Y, 0, 0);
			if(p)
			{
      		// 明るい緑
				p.SetColor(0.7f, 1, 0.7f);
			}else{
				Debug.Log("particle err");
			}
		}
		// ボールエフェクト生成
		float dir = Random.Range(35, 55);
		for(int i = 0; i < 8; i++)
		{
			// 消滅フレーム数
			int timer = Random.Range(20, 40);
			// 移動速度
			float spd = Random.Range(0.5f, 2.5f);
			Particle p = Particle.Add(Particle.eType.Ball, timer, X, Y, dir, spd);
			// 移動方向
			dir += Random.Range(35, 55);
			if(p)
			{
				// 緑色を設定
				p.SetColor(0.0f, 1, 0.0f);
				// 大きさを設定
				p.Scale = 0.8f;
			}
		}
		// 親の消滅処理を呼び出す
		base.Vanish();
	}
	*/
}