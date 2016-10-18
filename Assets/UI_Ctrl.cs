using UnityEngine;
using System.Collections;

public class UI_Ctrl : MonoBehaviour {
	MouseCtrl m=null;
	// Use this for initialization
	void Start () {
		m = GameObject.Find ("MouseCtrl").GetComponent<MouseCtrl> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void test(){
		m.Status = 1;
	}
}
