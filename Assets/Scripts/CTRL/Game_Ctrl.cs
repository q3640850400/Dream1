using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game_Ctrl : MonoBehaviour {
	public static Game_Ctrl Instance = null;
	public List<GameObject> MyUnitList;
	public List<GameObject> EnmyUnitList;
	public List<GameObject> FrdUnitList;
	public List<GameObject> SelectUnitList;
	void Awake(){
		Instance = this;
	}

	// Use this for initialization
	void Start () {
		MyUnitList=new List<GameObject>();
		EnmyUnitList=new List<GameObject>();
		FrdUnitList=new List<GameObject>();
		SelectUnitList=new List<GameObject>();
		GameObject[] t=GameObject.FindGameObjectsWithTag ("Player");
		foreach (GameObject g in t) {
			MyUnitList.Add (g);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGameMessageIn(string msg,int delay,ArcaletGame game)
	{
		string[] s=msg.Split(':');
		if (s[0]=="Strike") { // 进攻命令
			// 讯息格式: "Strike:poid/userid/unitid/posx/posy/posz"
			string[] p=s[1].Split('/');
			int newPoid=int.Parse(p[0]);	    // 新玩家的私人场景
			string newUserid=p[1];			// 新玩家的userid
			int unitid=int.Parse(p[2]);
			float posx = float.Parse(p[3]);
			float posy = float.Parse(p[4]);
			float posz = float.Parse(p[5]);


//			if (newPoid!=ag.poid) {			// 新进的玩家不是本地玩家
//				Debug.Log(p[1]+" is coming!!!");
//
//				// 产生一个远程玩家的太空战机
//				Vector3 position = new Vector3(0.0f,-3.219612f,0.0f);
//				GameObject newPlayer=(GameObject)Instantiate(remotePlayerPrefab, position,Quaternion.identity);
//
//				// 把这个玩家数据数据记起来 
//				AddPlayer(newPoid,newUserid,false,newPlayer);
//
//				// 把本地玩家的数据告诉新进玩家(用新进玩家的私人场景传讯)
//				if (isMaster) {
//					// 如果本地玩家是master，格式是 "player:M/poid/userid"
//					ag.PrivacySend(  
//						"player:M/"+ag.poid.ToString()+"/"+this.userid,newPoid);
//				}
//				else {
//					// 如果本地玩家不master，格式是 "player:G/poid/userid"
//					ag.PrivacySend(
//						"player:G/"+ag.poid.ToString()+"/"+this.userid,newPoid);
//				}
//			}
//			else {
//				Debug.Log("I'm coming!");
//			}
		}
	}
	public void OffGameMessageIn(string msg,int delay)
	{
		Debug.Log (msg);
		string[] s=msg.Split(':');
		if (s[0]=="Strike") { // 进攻命令
			// 讯息格式: "Strike:poid/userid/unitid/posx/posy/posz"
			string[] p=s[1].Split('/');
			int newPoid=int.Parse(p[0]);	    // 新玩家的私人场景
			string newUserid=p[1];			// 新玩家的userid
			int unitid=int.Parse(p[2]);
			float posx = float.Parse(p[3]);
			float posy = float.Parse(p[4]);
			float posz = float.Parse(p[5]);

			foreach(GameObject g in MyUnitList){
				g.GetComponent<UnitProperty> ().move (new Vector3 (posx, posy, posz));
			}

//			if (newPoid!=ag.poid) {			// 新进的玩家不是本地玩家
//				Debug.Log(p[1]+" is coming!!!");
//
//				// 产生一个远程玩家的太空战机
//				Vector3 position = new Vector3(0.0f,-3.219612f,0.0f);
//				GameObject newPlayer=(GameObject)Instantiate(remotePlayerPrefab, position,Quaternion.identity);
//
//				// 把这个玩家数据数据记起来 
//				AddPlayer(newPoid,newUserid,false,newPlayer);
//
//				// 把本地玩家的数据告诉新进玩家(用新进玩家的私人场景传讯)
//				if (isMaster) {
//					// 如果本地玩家是master，格式是 "player:M/poid/userid"
//					ag.PrivacySend(  
//						"player:M/"+ag.poid.ToString()+"/"+this.userid,newPoid);
//				}
//				else {
//					// 如果本地玩家不master，格式是 "player:G/poid/userid"
//					ag.PrivacySend(
//						"player:G/"+ag.poid.ToString()+"/"+this.userid,newPoid);
//				}
//			}
//			else {
//				Debug.Log("I'm coming!");
//			}
		}
	}
}
