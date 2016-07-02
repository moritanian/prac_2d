using UnityEngine;
using System.Collections;

public class material : Token {

	public static int status;
	public int MatNo = 1;


	HpGage hpgage;

	// Use this for initialization
	void Start () {
		status = 0;

		hpgage = GetComponent<HpGage> ();
		//HpGage.Add (X,Y - 3);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void OnMouseDown()
	{
		/*float sensibility = 10.0f;
		X += Input.GetAxis ("Mouse X")*sensibility;
		Y += Input.GetAxis ("Mouse Y")*sensibility;
		*/
	

			
 		
		//ClampScreen();
	}
	 
	public bool IsSetFrame()
	{
		GameObject frame = GameObject.Find ("frame1");
		//float fx = frame.X;
		//float fy = frame.Y;
		float fX = frame.transform.position.x;
		float fY = frame.transform.position.y;
		//printf (fX);
		float ran = 0.05f;
		if(X - ran < fX && fX < X + ran && Y - ran < fY && fY < Y + ran)return true;
		else return false;
	}

	public void OnMouseDrag()
	{
		if (status == 0) {
			MoveByDrag ();

			if (IsSetFrame ()){
			
				status = 1;

			}
		}
	}

	private void MoveByDrag(){

		Vector3 objectPointInScreen
			= Camera.main.WorldToScreenPoint(this.transform.position);
		
		Vector3 mousePointInScreen
			= new Vector3(Input.mousePosition.x,
			              Input.mousePosition.y,
			              objectPointInScreen.z);
		
		Vector3 mousePointInWorld = Camera.main.ScreenToWorldPoint(mousePointInScreen);
		mousePointInWorld.z = this.transform.position.z;
		this.transform.position = mousePointInWorld;
	}

}
