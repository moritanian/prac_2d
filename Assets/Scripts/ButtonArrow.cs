using UnityEngine;
using System.Collections;

public class ButtonArrow : Token {
	
	public const int MoveNum = 1;
	enum Type{
		Left,
		Right,
		Up,
		Down
	}
	private Type type;
	// Use this for initialization
	void Start () {
		Debug.Log("this is an arrow");
		Debug.Log ( this.name);
		if (this.name == "ButtonArrowLeft")
			type = Type.Left;
		else if (this.name == "ButtonArrowRight")
			type = Type.Right;
		else if (this.name == "Allowup")
			type = Type.Up;
		else if (this.name == "Allowdown")
			type = Type.Down;
		else
			type = Type.Down;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnMouseDown()
	{
		if (type == Type.Right) {
			MatDisp.ChangeCur (MoveNum);
			Debug.Log ("this is an right arrow");

		} else if (type == Type.Left) {
			MatDisp.ChangeCur (-MoveNum);
			Debug.Log ("this is an left arrow");
		} else if (type == Type.Up) {
			Alloy.ChangeCur (+MoveNum);
		} else if (type == Type.Down) {
			Alloy.ChangeCur (-MoveNum);
		}
	}


}