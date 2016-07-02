using UnityEngine;
using System.Collections;

public class GameMgr2 : Token {




	void Start(){
		int i;
		Vector2 pos;
		Vector2 min = GetWorldMin();
		Vector2 max = GetWorldMax();

		Tama.parent = new TokenMgr<Tama>("Tama", 12);
		for (i=0; i<5; i++) {

			pos.x = Random.Range (min.x,max.x);
			pos.y = Random.Range (min.y,max.y);
			Tama.Add(pos.x , pos.y);

		}
	
	}

	void OnGUI()
	{
		if (Tama.Count == 0) {
			// 敵全滅
			Util.SetFontSize (32);
			Util.SetFontAlignment (TextAnchor.MiddleCenter);

			float w = 128;	
			float h = 32;
			float px = Screen.width / 2 - w / 2;
			float py = Screen.height / 2 - h / 2;

			Util.GUILabel (px, py, w, h, "Game Clear !!");


			// ボタンは少し下にずらす
			py += 60;
			if (GUI.Button (new Rect (px, py, w, h), "Back to Title")) {
				// タイトル画面にもどる
				Application.LoadLevel ("Title");
			}
		}

		if (material.status == 1) {
			float w = 128;	
			float h = 32;
			float px = Screen.width / 2 - w / 2;
			float py = Screen.height / 2 - h / 2;
			if(GUI.Button (new Rect (px, py, w, h), "Syntax Materials")){
			}
		}
	
	}

	public static void DebugPut(){

		Util.SetFontSize (32);
		Util.SetFontAlignment (TextAnchor.MiddleCenter);

		float w = 128;	
		float h = 32;
		float px = Screen.width / 2 - w / 2;
		float py = Screen.height / 2 - h / 2;

		Util.GUILabel (px,py,w,h, "This is debug check");
	}
 	// Use this for initialization
}
