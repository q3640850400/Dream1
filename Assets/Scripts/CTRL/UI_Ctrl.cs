using UnityEngine;
using System.Collections;

public class UI_Ctrl : MonoBehaviour {
	//Mouse_Ctrl m=null;
	GameObject page_constructions;
	//string ConstructionPrefabPath="单位/Prefab/";
	//GameObject ReadyBuild = null;//准备建造的建筑
	//public string ConstructionPrefabPath="/Resources/单位/Prefab/";

	// Use this for initialization
	void Start () {
		Singleton<FSM_Ctrl>.Instance.Status = 0;
		page_constructions=GameObject.Find("建筑页面");
		//m = GameObject.Find ("Mouse_Ctrl").GetComponent<Mouse_Ctrl> ();
		page_constructions.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//行为树测试
	public void test(){
		Singleton<FSM_Ctrl>.Instance.Status = 1;
	}
	//打开建筑页面
	public void open_page_constructions(){
		switch (page_constructions.activeSelf) {
		case true:
			{
				page_constructions.SetActive (false);
				break;
			}
		case false:
			{
				page_constructions.SetActive (true);
				break;
			}
		}
	}
	public void getBuilding(string Name){
		Singleton<FSM_Ctrl>.Instance.Status = 2;
		Singleton<FSM_Ctrl>.Instance.Name = Name;
//		Singleton<UI_Ctrl>.Instance.ReadyBuild = GameObject.Instantiate (Resources.Load(ConstructionPrefabPath + name,typeof(GameObject)), new Vector3 (0f, 0f, 0f), Quaternion.identity) as GameObject;
//		if (Singleton<UI_Ctrl>.Instance.ReadyBuild != null) {
//			Debug.Log ("Load Building Success");
//		} else {
//			Debug.Log ("Load Building Fail");
//		}
	}
}
