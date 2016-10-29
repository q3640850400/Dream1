using UnityEngine;
using System.Collections;

public class Model : MonoBehaviour {
	public static Model Instance = null;
	public int Mapx=100;
	public int Mapy=100;
	// Use this for initialization
	void Awake(){
		Instance = this;
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
