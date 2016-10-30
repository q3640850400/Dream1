using UnityEngine;
using System.Collections;

public class Init_Ctrl : MonoBehaviour {
	void Awake(){
		//Debug.logger.logEnabled = false;
		BehaviacSystem BS = new BehaviacSystem ();
		BS.Init ();
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
