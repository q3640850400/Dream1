using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour {
	public static MiniMap Instance = null;
	private Camera UICamera;//UI
	private Camera GameCamera;
	private Vector3 screenPos;//小地图中点的屏幕位置
	private Rect mapRect;//小地图矩形
	private Vector2 mapZero;//小地图零点
	private Vector2 gameZero;//游戏零点
	private float mapWidth;//小地图宽度
	private float mapHeight;//小地图高度
	public float gameWidth;//游戏宽度
	public float gameHeight;//游戏高度
	private Vector2 curMousePos=new Vector2();//当前鼠标位置
	private Vector3 curGamePos=new Vector3(0f,0f,-5f);//当前游戏位置

	void Awake(){
		Instance = this;
	}
	// Use this for initialization
	void Start () {
		
		this.gameWidth = (float)Model.Instance.Mapx*0.64f;
		this.gameHeight = (float)Model.Instance.Mapy*0.64f;


		mapWidth = 200f;//小地图宽度
		mapHeight = 200f;//小地图高度

		UICamera = GameObject.Find ("UICamera").GetComponent<Camera> ();
		GameCamera = GameObject.Find ("GameCamera").GetComponent<Camera> ();

		screenPos = UICamera.WorldToScreenPoint (transform.position);//把小地图中点的世界坐标转成屏幕坐标
		mapRect=new Rect(screenPos.x-mapWidth/2,screenPos.y-mapHeight/2,mapWidth,mapHeight);//用小地图左上角的坐标画一个矩形，判断点是否在矩形内
		mapZero = new Vector2 (screenPos.x - mapWidth/2, screenPos.y - mapHeight/2);//小地图左下角的点作为零点
		gameZero=new Vector2(0f,0f);//游戏零点
	}
	
	// Update is called once per frame
	void Update () {
		test ();
	}
	void test(){
		//Debug.Log (screenPos);
		if (Input.GetMouseButton (0)) {			
			curMousePos.x=Input.mousePosition.x;
			curMousePos.y = Input.mousePosition.y;
			if (mapRect.Contains (curMousePos)) {
				curGamePos.x = (curMousePos.x - mapZero.x) / mapWidth * gameWidth+gameZero.x;
				curGamePos.y = (curMousePos.y - mapZero.y) / mapHeight * gameHeight + gameZero.y;
				GameCamera.transform.position = curGamePos;
			}
		}
	}
}
