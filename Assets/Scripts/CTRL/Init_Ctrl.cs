using UnityEngine;
using System.Collections;

public class Init_Ctrl : MonoBehaviour {
	public static Init_Ctrl Instance = null;
	public float pixel=0.64f;
	void Awake(){
		Instance = this;
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
