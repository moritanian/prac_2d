using UnityEngine;
using System.Collections;

	//タワーディフェンス用のマップを作製する 
public class CreateTdMap : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Create ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Create(){
		Layer2D Td_map_layer =  CreateMap.Create();
		
		Td_map_layer.Dump ();
		//FileIO.Write("testio.txt");
	}
}
