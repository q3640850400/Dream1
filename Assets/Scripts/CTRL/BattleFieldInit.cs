﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class BattleFieldInit : MonoBehaviour {
	public static BattleFieldInit Instance = null;
	public float pixel=0.64f;
	public int tilecount;//地图的贴图一共分成多少幅
	public int columns;//地图的贴图每行有多少幅
	public int lines;//地图的贴图一共多少行，由tilecount/columns得到
	public int x;//地图的宽度
	public int y;//地图的高度
	public List<GameObject> land=new List<GameObject>();
	private Model _Model;
	public int [][]MapArray=null;
	public int [][]BlockArray=null;
	public string MapName="test3";//地图名字
	public static string localUrl;
	void Awake(){
		Instance = this;
	}
	// Use this for initialization
	void Start () {
		//Init ();
		Init2();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator CreateMapElmt(){//使用协程加载地图精灵
		Texture2D t2d = Resources.Load ("地形/地图/"+MapName) as Texture2D;//1.读取纹理
		Transform BFtran = GameObject.Find ("BattleField").transform;
		for (int i = 0; i < this.x; i++) {
			yield return null;//无返回表示每帧执行协程
			for (int j = 0; j < this.y; j++) {
				int rx = (MapArray [i] [j] % columns - 1) ;//根据ij计算纹理x
				if (rx == -1)
					rx = columns-1;
				int ry = (lines - (MapArray [i] [j] - 1) / columns - 1) ;//根据ij计算纹理y
				int px = j;//根据ij计算位置x
				int py = this.y-i-1;//根据ij计算位置y
				Rect r = new Rect (rx*64f,ry*64f,64f,64f);//2.设置纹理范围
				Vector3 p = new Vector3 (px*pixel+pixel/2,py*pixel+pixel/2,0f);//3.GameObject位置
				//Debug.Log (MapArray [i] [j]+" i="+i+" j="+j+" r="+r);
				Sprite S = Sprite.Create (t2d, r,new Vector2(0.5f,0.5f));//4.创建Sprite
				GameObject G = new GameObject ();//5.创建GameObject
				G.transform.SetParent (BFtran);
				SpriteRenderer SR=G.AddComponent<SpriteRenderer> ();//6.Add<SpriteRenderer>
				SR.sprite = S;//7.捆绑Sprite和GameObject
				SR.sortingLayerName="Land";//8.设置渲染组别
				SR.sortingOrder = 0;//9.设置渲染层
				G.transform.position = p;//10.设置GameObject位置
			}
		}
	}
	void ReadTMX(){//读取TMX地图文件
		XmlDocument doc = new XmlDocument();
		doc.Load (localUrl);
		XmlNode map = doc.SelectSingleNode("map"); 
		//Debug.Log (map);
		this.x=int.Parse(((XmlElement)map).GetAttribute("width"));//从TMX读取地图大小x
		this.y=int.Parse(((XmlElement)map).GetAttribute("height"));//从TMX读取地图大小y
		XmlElement tileset = (XmlElement)map.SelectSingleNode("tileset"); 
		tilecount=int.Parse(tileset.GetAttribute ("tilecount"));//从TMX读取tilecount
		columns = int.Parse (tileset.GetAttribute ("columns"));//从TMX读取columns
		lines=tilecount/columns;//计算行数
		//XmlNode layers = map.SelectSingleNode("layer"); 

		XmlNodeList layers = map.SelectNodes("layer");
		foreach (XmlNode l in layers) {
			XmlElement layer = (XmlElement)l;
			if (layer.GetAttribute ("name") == "块层 1") {
				XmlElement data = (XmlElement)layer.SelectSingleNode("data"); 
				MapArray=ReadStringtoInt (data.InnerText);
			}
			if (layer.GetAttribute ("name") == "块层 2") {
				XmlElement data = (XmlElement)layer.SelectSingleNode("data"); 
				BlockArray=ReadStringtoInt (data.InnerText);
			}
		}
		if (MapArray == null)
			Debug.Log ("地图MapArray加载失败");
		if (BlockArray == null)
			Debug.Log ("地图BlockArray加载失败");

	}

	//读取TMX里面的data(无用，用ReadStringtoInt代替)
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
		//this.x = Array [0].Length;
		//this.y = Array.Length;
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
	void Init(){//无用，用Init2代替
		BoxCollider b = GameObject.Find ("地图碰撞器").GetComponent<BoxCollider> ();
		b.center = new Vector3 (this.x / 2 * pixel-pixel/2, this.y / 2 * pixel-pixel/2, 0f);
		b.size = new Vector3 (this.x * pixel, this.y* pixel, 0.2f);
		Transform p = GameObject.Find ("BattleField").transform;
		for (int xt = 0; xt < x; xt++) {
			for (int yt = 0; yt < y; yt++) {
				//int k = Random.Range (0, 7);
				int k=0;
				GameObject l = GameObject.Instantiate (land[k], new Vector3 (xt * pixel, yt * pixel, 0f), Quaternion.identity) as GameObject;
				l.transform.SetParent (p);
				//l.AddComponent<MeshCollider> ();
				//MeshCollider c = new MeshCollider ();
			}
		}
	}
	void Init2(){
		this.pixel = Init_Ctrl.Instance.pixel;//对齐像素点
		localUrl = Application.dataPath + "/Resources/地形/地图/"+MapName+".tmx";
		ReadTMX();
		StartCoroutine(CreateMapElmt ());
		BoxCollider b = GameObject.Find ("地图碰撞器").GetComponent<BoxCollider> ();//设置地图碰撞器
		b.center = new Vector3 (this.x / 2 * pixel-pixel/2, this.y / 2 * pixel-pixel/2, 0f);
		b.size = new Vector3 (this.x * pixel, this.y* pixel, 0.2f);
		MiniMap.Instance.gameWidth = this.x * pixel;//设置小地图的游戏大小属性X
		MiniMap.Instance.gameHeight = this.y * pixel;//设置小地图的游戏大小属性Y
	}
}