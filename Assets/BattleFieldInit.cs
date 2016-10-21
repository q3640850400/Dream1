using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleFieldInit : MonoBehaviour {
	public int x=100;
	public int y=100;
	public List<GameObject> land=new List<GameObject>();
	private Model _Model;
	// Use this for initialization
	void Start () {
		_Model = GameObject.Find ("Model").GetComponent<Model> ();
		this.x = _Model.Mapx;
		this.y = _Model.Mapy;
		Init ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void Init(){
		Transform p = GameObject.Find ("BattleField").transform;
		for (int xt = 0; xt < x; xt++) {
			for (int yt = 0; yt < y; yt++) {
				//int k = Random.Range (0, 7);
				int k=0;
				GameObject l = GameObject.Instantiate (land[k], new Vector3 (xt * 0.64f, yt * 0.64f, 0f), Quaternion.identity) as GameObject;
				l.transform.SetParent (p);
				//l.AddComponent<MeshCollider> ();
				//MeshCollider c = new MeshCollider ();
			}
		}
	}
}
