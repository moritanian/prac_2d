using UnityEngine;
using System.Collections;

public class StartScene : Token {
	
	public int cnt;
	int cnt_max = 20;
	int str_cnt = 0;
	static int str_cnt_max = 4;	
	//str_cnt_max: スタート画面に表示される文字列数
	public string[] start_strs = new string[str_cnt_max];
	public  TextObj _outtxt; 
	public ButtonObj _txtback;
	// Use this for initialization
	void Start () {
		cnt = 0;
		str_cnt = 0;
		_outtxt = MyCanvas.Find<TextObj>("OutText");
		SetStr();
		_outtxt.Label = start_strs[0];
		_txtback = MyCanvas.Find<ButtonObj>("txtback");
		_txtback.Visible = true;
		_txtback.Enabled = true;
	}

	void SetStr(){
		start_strs[0] = "中世ヨーロッパ、 \n イタリアは西ローマ帝国滅亡後、" +
			"フランク王国に支配されたが、フランク王国分裂後、フィレンツェ、ヴェネツィア、" +
			"ナポリ、ミラノなど、実質的に独立した政治的権限を持つ都市国家が繁栄した...";
		start_strs[1] = "中世キリスト教価値観に対し、フィレンツェ共和国のメディチ家や、" +
			"ローマ教皇、各国の君主は芸術を保護し、イタリアからルネサンスが広まるり、イタリアは黄金期を迎える" ;
		start_strs[2] = "しかし、黄金期はフランスやスペインなどの大国にイタリア諸都市が次々と合併されることで終わりを告げる。" +
			"ナポレオン戦争後のウィーン体制のもと、イタリア諸都市は様々な小国に分割される";
		start_strs[3] = "保守反動的なウィーン体制に対し、イタリア統一の機運が高まってゆく...";
	}
	// Update is called once per frame
	void Update () {

	}

	public void Touch(){	//次の文字へ
		str_cnt++;
		if(str_cnt == str_cnt_max){	//自国選択画面へ
			Application.LoadLevel("SelectCountry");
		}else{
			_outtxt.Label = start_strs[str_cnt];
		}
	}
	void FixedUpdate(){
		cnt ++;
		if(cnt == cnt_max){
			_outtxt.Label += "∇";

		}else if(cnt>cnt_max*2){
			_outtxt.Label = start_strs[str_cnt];
			cnt = 0;
		}
	}
}
