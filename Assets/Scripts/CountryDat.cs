using UnityEngine;
using System.Collections;

public class CountryDat {

	string Name;
	int ParentCtry;	//親の国
	int ID;
	string Extxt;	//解説文
	int Power;	//国力
	string BtnName;
	

	public const int num = 9;
//	public Sprite[] flg

//	public Sprite[] spr = new Sprite[num];

	static bool is_create = false; // CeateAllData したか
	static CountryDat[] ctrydats= new CountryDat[num];

	public static CountryDat SearchByBtnName(string name){
		if(!is_create)CreateAllData();
		for (int i = 0; i<num; i++) {
			if (ctrydats [i].btnname == name){
				Debug.Log ("一致");
				Debug.Log (ctrydats [i].btnname);
				return ctrydats [i];
			}
		}
		return null;
	}
	// 破壊的なので注意
	public static CountryDat SearchById(int id){
		if(!is_create)CreateAllData();
		for (int i = 0; i<num; i++) {
			if (ctrydats [i].id == id){
				return ctrydats [i];
			}
		}
		return null;
	}

	public static void CreateAllData(){
		// データをすべて挿入
		ctrydats[0] = new CountryDat(1, "Napoli", 0, "ナポリ。紀元前6世紀に古代ギリシア人の植民活動により建設された。西ローマ帝国滅亡まで長くローマ帝国の支配にあり、その後も流動的な状況が続く。6世紀に東ローマ帝国属州となる。\n11世紀にはノルマン人のシチリア王国、さらに12世紀には神聖ローマ帝国の支配となる。\n近郊にポンペイ遺跡がある。", 1, "NapoliBtn");
		ctrydats[1] = new CountryDat(2, "Stato Pontifico", 0, "金融業で栄えた都市国家であり、13世紀、14世紀にかけて最盛期を迎える。\nトスカーナ地方の覇権をフィレンツェと競い、またその経済力を背景として、ルネサンス期には芸術の中心地であった。", 1, "PontificoBtn");
		ctrydats[2] = new CountryDat(3, "Firenze", 0, "フィレンツェ共和国。首都はフィレンツェ。13世紀頃共和制となる。\n当初は寡頭政治であったが、政争の末、メディチ家が台頭する。15世紀にコジモ・デ・メディチが支配して以降は、メディチ家が支配する。", 2, "FirenzeBtn");
		ctrydats[3] = new CountryDat(4, "Venezia", 0, "最も高貴な共和国ヴェネツィア。「最も高貴な国」や「アドリア海の女王」とも呼ばれる。\n東地中海貿易によって栄えた海洋国家である\n。また、信教の自由や法の支配が徹底されており、元首の息子であっても法を犯せば平等に処罰された", 2, "VeneziaBtn");
		ctrydats[4] = new CountryDat(5, "Milano", 0, "ミラノ公国。中世後期にヴィスコンティ家とスフォルツァ家がミラノ公国を建てる。1395年にミラノ公の称号を授かった初代ミラノ公ジャン・ガレアッツォ・ヴィスコンティ（1351～1402年）の時代には繁栄を極める。", 2, "MilanoBtn");
		ctrydats[5] = new CountryDat(6, "Genova", 0, "ジェノバ共和国。第一時十字軍の頃から勢力を伸ばし始める。東地中海での交易においてヴェネツィアと競争関係にあった。", 0, "GenovaBtn");
		ctrydats[6] = new CountryDat(7, "Sardegna", 0, "サルディーニャ王国。", 0, "SardegnaBtn");
		ctrydats[7] = new CountryDat(8, "Siena", 0, "シエーナ共和国。トスカーナ地方の覇権をフィレンツェと争う。13世紀に展開された教皇派と皇帝派の抗争では、フィレンツェが教皇派であったのに対抗し、シエーナは主に皇帝派の立場に立っていた。", 0, "SienaBtn");
		ctrydats[8] = new CountryDat(9, "Sicilia", 0, "シチリア王国。ホーエンシュタウン家により統治される。\n主な輸出品は穀物であり、他には豆類、材木、オリーブ油、ベーコン、チーズ、皮革、獣皮、麻、服飾がある。", 1, "SiciliaBtn");
		is_create = true;
	}

	//コンストラクタ
	public CountryDat(int id,string name,int pc = 0, string extxt = "", int power = 0, string btnname = ""){
		this.InsertData(id,name,pc,extxt,power,btnname);
	}

	public void InsertData(int id,string name,int pc, string extxt, int power, string btnname){
		this.ID = id;
		this.Name = name;
		this.ParentCtry = pc;
		this.Extxt = extxt;
		this.Power = power;
		this.btnname = btnname;
	
	}

	public string extxt{
		get{return Extxt;}
	}

	public int power {
		get{ return Power;}
		set{ 
			if (0 <= value && value < 3)
				Power = value;}
	}
	public string btnname{
		get {return BtnName;}
		set {BtnName = value;}
	}

	public string name{
		get {return Name;}
	}
	public int id{
		get {return ID;}
	}

}
