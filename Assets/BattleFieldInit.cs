using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class BattleFieldInit : MonoBehaviour {
	public int x=100;
	public int y=100;
	public List<GameObject> land=new List<GameObject>();
	private Model _Model;
	public string [][]MapArray;
	public string [][]BlockArray;
	public string MapName="test1";
	public static string localUrl;
	// Use this for initialization
	void Start () {
		_Model = GameObject.Find ("Model").GetComponent<Model> ();
		this.x = _Model.Mapx;
		this.y = _Model.Mapy;
		//Init ();
		localUrl = Application.dataPath + "/Resources/test2.tmx";
		ReadTMX2();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void ReadTMX2(){
		XmlDocument doc = new XmlDocument();
		doc.Load (localUrl);
		XmlNode provinces = doc.SelectSingleNode("map"); 
		Debug.Log (provinces);

	}
	public static string GetXmlDetail(string provinceId)
	{
		string _provinceName = "";

		XmlDocument xmlDoc = ReadAndLoadXml();

		//所有province节点
		XmlNode provinces = xmlDoc.SelectSingleNode("province");

		foreach (XmlNode province in provinces)
		{
			XmlElement _province = (XmlElement)province;


			if (provinceId == _province.GetAttribute("id"))
			{
				//获取实际省名
				_provinceName= _province.GetAttribute("name");

			}
		}


		return _provinceName;
	}
	void ReadTMX(){
		//读取csv二进制文件
		TextAsset binAsset1 = Resources.Load (MapName+"_地表", typeof(TextAsset)) as TextAsset;
		TextAsset binAsset2 = Resources.Load (MapName+"_障碍物", typeof(TextAsset)) as TextAsset;
		//读取每一行的内容
		string [] lineArray1 = binAsset1.text.Split (new char[]{ '\r','\n' },System.StringSplitOptions.RemoveEmptyEntries);
		string [] lineArray2 = binAsset2.text.Split (new char[]{ '\r','\n' },System.StringSplitOptions.RemoveEmptyEntries);
		MapArray = new string [lineArray1.Length][];
		BlockArray=new string [lineArray2.Length][];
		for (int i = 0; i < lineArray1.Length; i++) {
			MapArray[i] = lineArray1[i].Split (',');
		}
		for (int i = 0; i < lineArray1.Length; i++) {
			BlockArray[i] = lineArray2[i].Split (',');
		}
		this.x = MapArray [0].Length;
		this.y = MapArray.Length;
		Debug.Log (MapArray [0][19]);
		Debug.Log (MapArray [19][19]);
		Debug.Log (BlockArray [0][19]);
		Debug.Log (BlockArray [19][19]);
	}
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
}
