using UnityEngine;
using System.Collections;

public class MatDat  {	//マテリアルデータクラス

	const int DATNUM = 5;
	protected string Name;
	protected double TS;	//tensile strength
	protected double YM; 	//young's modulus 
	protected double CR;	//corrosion resistance
	protected int ownned = 0;	//所持しているか

	//データ一覧

	public static bool GetMatById(int id,MatDat _matdat)
	{

		if (id == 0)
			_matdat.InsertDat ("Stainless", 10.0, 10.0, 10.0);
		else if (id == 1)
			_matdat.InsertDat ("Cupper", 5.0, 6.0, 50.0);
		else if (id == 2)
			_matdat.InsertDat ("Steel", 2.0, 2.0, 30.0);
		else if (id == 3)
			_matdat.InsertDat ("Brass", 13.0, 11.0, 20.0);
		else if (id == 4)
			_matdat.InsertDat ("Duralmin", 5.0, 1.0, 60.0);
		else
			return false;

		return true;
	}

	public string _name {
		set{ this.Name = value;}
		get{ return this.Name;}
	}
	public double _TS {
		set{ this.TS = value;}
		get{ return this.TS;}
	}
	public double _YM {
		set{ this.YM = value;}
		get{ return this.YM;}
	}
	public double _CR {
		set{ this.CR = value;}
		get{ return this.CR;}
	}
	public int _ownned {
		get{ return this.ownned;}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Ownned(){	//ゲットしたのでフラグたてる
		this.ownned = 1;
	
	}
	public void InsertDat(string name,double TS, double YM , double CR){
		this.Name = name;
		this.TS = TS;
		this.YM = YM;
		this.CR = CR;
	}
	
}
