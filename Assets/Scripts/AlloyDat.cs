using UnityEngine;
using System.Collections;

	/// 合金データクラス (素材データ継承クラス)
public class AlloyDat : MatDat {
	//static MatDat[] _matdat = new MatDat[SprNum];
	public const int DATNUM = 2;
	MatDat[] OriginMats = new MatDat[3];
	int OriginNum = 0;	//jj
	//public static int[][] OriginIds = new int [2][];
	//OriginIds[0] = new int[]{1,2};
	//OriginIds[1] = new int[]{3,4};
	static public int[][] OriginIds = new int[][] 
	{
		new int[] {1,2},
		new int[] {3,4},
	};

	/// データ一覧
	public static bool GetAlloyDatById(int id,ref AlloyDat _alloydat){	// 合金データをひとつ取得
		//int[] origin = {-1,-1,-1};
		if (id == 0) {
			_alloydat.InsertDat ("Steel", 1.0, 2.5, 3.8, AlloyDat.OriginIds[id]);
		} else if (id == 1) {
			_alloydat.InsertDat ("Bronz", 2.0, 1.1, 2.4, AlloyDat.OriginIds[id]);
		} else {
			return false;
		}
		return true;
	
	}

	public int _originnum {
		get {
			return this.OriginNum;
		}
	}

	public MatDat _OriginMats(int num){
			return this.OriginMats[num];
	}

	/// 所持、非所持関係なく、合金データすべての一覧取得
	public static AlloyDat[] GetAlloyList(){	

		AlloyDat[] alloylist = new AlloyDat[DATNUM];
		for (int i=0; i<DATNUM; i++) {
			alloylist [i] = new AlloyDat ();
			GetAlloyDatById (i, ref alloylist [i]);
		}
		return alloylist;
	}

	/// 合金生成できるか　できる場合、合金のidを返す　ない場合、-1
	/// 余計なものが含まれる場合は合成できない
	public static int IsSyntaxAlloy(int[] MatIds){

		int len = MatIds.Length;
		int datidnum = AlloyDat.OriginIds.Length;

		for(int i=0;i<datidnum;i++){
			int[] Origin = AlloyDat.OriginIds[i];
			if(Origin.Length != len)continue;
			for(int j = 0;j<len;j++){
				if(MatIds[j] != Origin[j])continue;
			}
			return i;
		}
		return -1;
	}
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void InsertDat(string name,double TS, double YM , double CR, int[] MatIds){
		this.Name = name;
		this.TS = TS;
		this.YM = YM;
		this.CR = CR;
		this.OriginNum = MatIds.Length;
		for (int i=0; i<MatIds.Length; i++) {
			this.OriginMats[i] = new MatDat();
			MatDat.GetMatById (MatIds [i], this.OriginMats[i]);

		}
	}

}
