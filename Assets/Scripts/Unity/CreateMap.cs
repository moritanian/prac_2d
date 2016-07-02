using UnityEngine;
using System.Collections;

// 一方通行のマップ作製
public class CreateMap {
	public const int CHIP_HEIGHT = 15;	//マップの高さ方向チップ数
	public const int CHIP_WIDTH = 20;	//マップの幅方向チップ数
	public const int CHIP_PATH_START = 26;
	const int CHIP_WALL = 0;	//通行不可
	const int CHIP_SW = 3;	//真っすぐ横
	const int CHIP_SH = 4; //真っすぐ縦
	const int CHIP_T1 = 5;	//右下
	const int CHIP_T2 = 6; //左下
	const int CHIP_T3 = 7;	//右上
	const int CHIP_T4 = 8;	//左上
	static Vector2 RIGHT = new Vector2(1,0);
	static Vector2 LEFT = new Vector2(-1,0);
	static Vector2 UP = new Vector2(0,-1);
	static Vector2 DOWN = new Vector2(0,1);
	// Use this for initialization
	void Start () {

	}


	public  static Layer2D Create(){
		var layer = new Layer2D ();
		layer.Create(CHIP_WIDTH,CHIP_HEIGHT);
		layer.Fill(CHIP_WALL);

		//　開始位置
		int xstart = 0;
		int ystart = Random.Range(1,CHIP_HEIGHT-1);
		// 終了位置	
		int xgoal = 0;
		int ygoal = Random.Range(1,CHIP_HEIGHT-1);

		layer.Set (xstart,ystart, CHIP_PATH_START);	//開始位置set

		if(!_Dig(layer, xstart,ystart,xgoal,ygoal))return Create();	//出来なかったら再帰呼び出し
		return layer;
	}

	static bool _Dig(Layer2D layer,int x,int y,int goalx,int goaly){

		Vector2 crt_dir = RIGHT;	//現在の進行方向
		Vector2 old_dir = RIGHT;	//以前の進行方向,現在左向きの際、
		const int min_turn = 4; // 最低曲がる回数
		int turn_num = 0;
		int dist,max_dist;

		while(true){
			max_dist = _Dig_Max_Dist(layer,crt_dir,x,y);

			//ゴールするか
			if(	(turn_num) >= min_turn  &&
				crt_dir == RIGHT && 
				max_dist + x == CHIP_WIDTH -2 &&
				(int)Random.Range(0,4/turn_num) == 0
			   )
			{
				max_dist = CHIP_WIDTH - x -1;
				_Dig_Str(layer,RIGHT,max_dist,x,y);
				Debug.Log ("sucessfully finished");
				break;
			}else{
				if(max_dist == 0){
					Debug.Log ("max_dist = 0 err");
					return false;
				
				}
				//実際に何マス進むか
				dist = (max_dist>1)?(int)Random.Range(2,max_dist + 1):max_dist;
			}

			//掘る
			_Dig_Str(layer,crt_dir,dist -1,x,y); //dist,ターン部分は除くため-1
			x += dist * (int)crt_dir.x;
			y += dist * (int)crt_dir.y;

			//ターン方向を決める
			if(crt_dir == LEFT){ // 左に進んでいる場合、以前の向きに進む
				Vector2 s_dir;
				s_dir = old_dir;
				//Swap(crt_dir.x,old_dir.x);
				old_dir = crt_dir;
				crt_dir = s_dir;

			} else {

				old_dir = crt_dir;
				// 広い領域の方向に進んでいく
				if(turn_num > min_turn){ // ターン数達成してたら、左右選ぶ場合はゴールへ
					crt_dir.x = old_dir.y*old_dir.y;
				}else{
					crt_dir.x = old_dir.y *old_dir.y* (1 - (int)(x/ (CHIP_WIDTH/2) )*2 );
				}
				crt_dir.y = old_dir.x *old_dir.x* (1 - (int)(y/ (CHIP_HEIGHT/2) )*2 );
				/*
				crt_dir.x = old_dir.y * (((int)Random.Range(0,2))*2 -1);
				crt_dir.y = old_dir.x * (((int)Random.Range(0,2))*2 -1);
				*/
				 
			}
			LogTurn(crt_dir, "dig: " + dist + "max_dist: " + max_dist + " logturn: " + turn_num + ":  ");
			layer.Set (x,y,_GetTurnChip(old_dir,crt_dir)); // ターン部分セット

			turn_num++;
			if(turn_num > 10)return false;	//うまく掘れなかった
		}
		return true;
	}

	static void LogTurn(Vector2 dir,string comment = "logturn: "){
		Debug.Log (comment + dir.x + ":" + dir.y);
	}
	//真っすぐ掘る x,y から　+dir ぶん　(x,y)は含まれない
	static bool _Dig_Str(Layer2D layer, Vector2 dir,int dist, int x,int y){
	
		if(dir == RIGHT || dir == LEFT){
			for(int i=0;i<dist;i++){
				x += (int)dir.x;
				y += (int)dir.y;
				layer.Set (x,y,CHIP_SW);
			}
		}else if(dir == UP || dir == DOWN){
			for(int i=0;i<dist;i++){
				x += (int)dir.x;
				y += (int)dir.y;
				layer.Set (x,y,CHIP_SH);
			}
		}else{
			return false;
		}
		return true;
	}



	// 最大どれだけ真っすぐ掘れるか
	static int _Dig_Max_Dist(Layer2D layer,Vector2 dir, int x,int y){
		int fin = 0,cnt= -1;
		do{
			cnt ++;
			x += (int)dir.x;
			y += (int)dir.y;
			// 行先が壁でない、行先の隣り合うマスがかべでないかどうか確認
			if(layer.Get(x,y) != CHIP_WALL)fin = 1;
			else if(layer.Get(x + (int)dir.y,y + (int)dir.x) != CHIP_WALL)fin = 2;
			else if(layer.Get(x - (int)dir.y,y - (int)dir.x) != CHIP_WALL)fin = 3;
		}while(fin == 0);
		return (cnt-1>0)?cnt-1:0;
	}

	//曲がる向きを決定用に端からの距離を取得 
	static int _GetDistFromEdge(Layer2D layer,Vector2 dir, int x, int y){
		return 1;
	}
	// 曲がる際のチップ番号取得
	// const int CHIP_T1 = 3;	//右下
	// const int CHIP_T2 = 4; //左下
	// const int CHIP_T3 = 5;	//右上
	// const int CHIP_T4 = 6;	//左上
	// T1 0 -1 / 1  0 , -1  0 /  0  1         *1 *2 *-1 *-2   -3 -3
	// T2 1  0 / 0  1 ,  0 -1 / -1  0   		-1 -1
	// T3 0  1 / 1  0 , -1  0 /  0 -1  			1 1
	// T4 1  0 / 0 -1 ,  0  1 / -1  0     		3 3
	// 
	static int _GetTurnChip(Vector2 old_dir,Vector2 crt_dir){
		int num = (int)old_dir.x + ((int)old_dir.y)*2 - (int)crt_dir.x - ((int)crt_dir.y)*2;

		switch (num){
			case -3:
				return CHIP_T1;
			case -1:
				return CHIP_T2;
			case 1:
				return CHIP_T3;
			case 3:
				return CHIP_T4;
			default:
				return CHIP_WALL;
		}
			
		return CHIP_WALL;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
