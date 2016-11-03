using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class BattleFieldInit : MonoBehaviour {
	public int tilecount;//地图的贴图一共分成多少幅
	public int columns;//每行有多少幅
	public int x=100;
	public int y=100;
	public List<GameObject> land=new List<GameObject>();
	private Model _Model;
	public int [][]MapArray;
	public int [][]BlockArray;
	public string MapName="test1";
	public static string localUrl;
	// Use this for initialization
	void Start () {
		_Model = GameObject.Find ("Model").GetComponent<Model> ();
		this.x = _Model.Mapx;
		this.y = _Model.Mapy;
		//Init ();
		Init2();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void ReadTMX(){
		XmlDocument doc = new XmlDocument();
		doc.Load (localUrl);
		XmlNode map = doc.SelectSingleNode("map"); 
		//Debug.Log (map);
		XmlElement tileset = (XmlElement)map.SelectSingleNode("tileset"); 
		tilecount=int.Parse(tileset.GetAttribute ("tilecount"));
		columns = int.Parse (tileset.GetAttribute ("columns"));
		//XmlNode layers = map.SelectSingleNode("layer"); 

		XmlNodeList layers = map.SelectNodes("layer");
		foreach (XmlNode l in layers) {
			XmlElement layer = (XmlElement)l;
			if (layer.GetAttribute ("name") == "地形") {
				XmlElement data = (XmlElement)layer.SelectSingleNode("data"); 
				MapArray=ReadStringtoInt (data.InnerText);
			}
			if (layer.GetAttribute ("name") == "障碍物") {
				XmlElement data = (XmlElement)layer.SelectSingleNode("data"); 
				BlockArray=ReadStringtoInt (data.InnerText);
			}
		}

	}
	void CreateMapElmt(){
//		Texture2D t2d = Resources.Load ("地形/地图/"+MapName) as Texture2D;
//		GameObject g = new GameObject ();
//		//Texture2D t2d = Resources.Load ("test1") as Texture2D;
//		//Debug.Log (t2d);
//		Sprite s = Sprite.Create (t2d, new Rect (0f, 0f, 64f, 64f),new Vector2(0.5f,0.5f));
//		SpriteRenderer sr=g.AddComponent<SpriteRenderer> ();
//		sr.sprite = s;
//		g.transform.position = new Vector3 (0f, 0f, 0f);
		Texture2D t2d = Resources.Load ("地形/地图/"+MapName) as Texture2D;
		Transform BFtran = GameObject.Find ("BattleField").transform;
		for (int i = 0; i < this.x; i++) {
			for (int j = 0; j < this.y; j++) {
				int rx = (MapArray [i] [j] % 8 - 1) ;
				int ry = (4 - (MapArray [i] [j] - 1) / 8 - 1) ;
				int px = j-1;
				int py = 20-i-1;
				Rect r = new Rect (rx*64f,ry*64f,64f,64f);//纹理范围
				Vector3 p = new Vector3 (px*0.64f+0.32f,py*0.64f+0.32f,-1f);//位置
				Debug.Log (r);
				Debug.Log (p);
				Sprite S = Sprite.Create (t2d, r,new Vector2(0.5f,0.5f));
				GameObject G = new GameObject ();
				G.transform.SetParent (BFtran);
				SpriteRenderer SR=G.AddComponent<SpriteRenderer> ();
				SR.sprite = S;
				G.transform.position = p;
			}
		}
	}
	//读取TMX里面的data(用ReadStringtoInt代替)
	string [][] ReadString(string binAsset){
		string [] lineArray = binAsset.Split (new char[]{ '\r','\n' },System.StringSplitOptions.RemoveEmptyEntries);
		string [][] Array = new string [lineArray.Length][];
		for (int i = 0; i < lineArray.Length; i++) {
			Array[i] = lineArray[i].Split (',');
		}
		this.x = Array [0].Length;
		this.y = Array.Length;
		return Array;
	}
	//读取TMX里面的data,并转换成int
	int [][] ReadStringtoInt(string binAsset){
		string [] lineArray = binAsset.Split (new char[]{ '\r','\n' },System.StringSplitOptions.RemoveEmptyEntries);
		string [][] sArray = new string [lineArray.Length][];
		for (int i = 0; i < lineArray.Length; i++) {
			sArray[i] = lineArray[i].Split (',');
		}
		int tt=int.Parse (sArray [1][0]);
		int[][] Array = new int [lineArray.Length][];
		for (int i = 0; i < sArray.Length; i++) {
			Array[i]=new int[sArray [0].Length-1];
			for (int j = 0; j < sArray [0].Length-1; j++) {
				Array [i] [j] = int.Parse(sArray [i] [j]);
			}
		}
		this.x = Array [0].Length;
		this.y = Array.Length;
		return Array;
	}
//	//直接读取TXT（无用）
//	void ReadTXT(){
//		//读取csv二进制文件
//		TextAsset binAsset1 = Resources.Load (MapName+"_地表", typeof(TextAsset)) as TextAsset;
//		TextAsset binAsset2 = Resources.Load (MapName+"_障碍物", typeof(TextAsset)) as TextAsset;
//		//读取每一行的内容
//		string [] lineArray1 = binAsset1.text.Split (new char[]{ '\r','\n' },System.StringSplitOptions.RemoveEmptyEntries);
//		string [] lineArray2 = binAsset2.text.Split (new char[]{ '\r','\n' },System.StringSplitOptions.RemoveEmptyEntries);
//		MapArray = new string [lineArray1.Length][];
//		BlockArray=new string [lineArray2.Length][];
//		for (int i = 0; i < lineArray1.Length; i++) {
//			MapArray[i] = lineArray1[i].Split (',');
//		}
//		for (int i = 0; i < lineArray1.Length; i++) {
//			BlockArray[i] = lineArray2[i].Split (',');
//		}
//		this.x = MapArray [0].Length;
//		this.y = MapArray.Length;
//		Debug.Log (MapArray [0][19]);
//		Debug.Log (MapArray [19][19]);
//		Debug.Log (BlockArray [0][19]);
//		Debug.Log (BlockArray [19][19]);
//	}
	void Init(){
		BoxCollider b = GameObject.Find ("地图碰撞器").GetComponent<BoxCollider> ();
		b.center = new Vector3 (this.x / 2 * 0.64f-0.32f, this.y / 2 * 0.64f-0.32f, 0f);
		b.size = new Vector3 (this.x * 0.64f, this.y* 0.64f, 0.2f);
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
	void Init2(){
		localUrl = Application.dataPath + "/Resources/地形/地图/"+MapName+".tmx";
		ReadTMX();
		CreateMapElmt ();
	}
}
