using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MyCanvas : MonoBehaviour {
	
	static Canvas _canvas;
	void Start () {
		// Canvasコンポーネントを保持
		_canvas = GetComponent<Canvas>();
	}
	
	/// 表示・非表示を設定する
	/* 
	public static void SetActive(string name, bool b) {
		foreach(Transform child in _canvas.transform) {
			// 子の要素をたどる
			Debug.Log(child.name);
			if(child.name == name) {
				// 指定した名前と一致
				// 表示フラグを設定
				child.gameObject.SetActive(b);
				// おしまい
				return;
			}
		}
		
		// 指定したオブジェクト名が見つからなかった
		Debug.LogWarning("Not found objname:"+name);
	}
	*/


	public static void SetActive(string name, bool b){
		GameObject obj = SearchObj(name, _canvas.transform);
		if(obj){
			obj.SetActive(b);
		}else{
			Debug.LogWarning("Not Found objname:" + name);
		}
	}

	// 再帰的にオブジェクトを探索
	static GameObject  SearchObj(string name, Transform children){
		foreach (Transform child in children.transform){
			if(child.name == name){
				return child.gameObject;
			}else if(child.transform != null){
				GameObject obj = SearchObj(name, child);
				if(obj) return obj.gameObject;
			} 
		}
		return null;
	}

	// 再帰的に探す
	public static Type FindFromAll<Type>(string name){
		GameObject obj = SearchObj(name, _canvas.transform);
		return obj.GetComponent<Type>();
	} 
	/// オブジェクトを検索する
	public static Type Find<Type>(string name) {
		return GameObject.Find(name).GetComponent<Type>();
	}

	public static Type FindChild<Type>(string name) {	//非表示のゲームオブジェクトを取得
	
		foreach(Transform child in _canvas.transform) {
			// 子の要素をたどる

			if(child.name == name) {
				// 指定した名前と一致
				// 表示フラグを設定
				//return  child.GetComponent<Type>();
				return child.gameObject.GetComponent<Type> ();
			}

		}

		Debug.Log("get");
		return _canvas.transform.FindChild(name).gameObject.GetComponent<Type>();
	}

	
}
