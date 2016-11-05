﻿// ---------------------------------------------------------------------
// This agent file is auto-generated by behaviac designer, but you should
// implement the methods of the agent class if necessary!
// ---------------------------------------------------------------------
#if UNITY_ANDROID && !UNITY_EDITOR
#define ANDROID
#endif


#if UNITY_IPHONE && !UNITY_EDITOR
#define IPHONE
#endif

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

[behaviac.TypeMetaInfo("FSM_Ctrl", "FSM_Ctrl")]
public class FSM_Ctrl : behaviac.Agent
{
	public static FSM_Ctrl Instance=null;
	public string behaviorTree 		= "FSM_Ctrl";
	protected bool btloadResult 	= false;

	public bool righthand = true;//惯用手为右手

	string ConstructionPrefabPath="单位/Prefab/";
	GameObject ReadyBuild = null;//准备建造的建筑
	public float pixel=0.64f;//每格的像素点
	public int x;//位置格点X
	public int y;//位置格点Y
	public string Name;//建筑的名字,由UI_Ctrl的函数写入,用来找到相应的prefab
	public int Volume;//建筑的大小
	LayerMask LandMask=1<<8;

	private Vector3 preMousePos;//鼠标起始位置
	private Vector3 curMousePos;//鼠标结束位置
	private Rect SelectRect;//选择框范围，用来判断单位是否在框内
	private Vector3 lastMosPos=new Vector3(0f,0f,0f);
	public float iniMosPosDis=0.5f;//鼠标敏感距离
	private float preMouseDownDT=0f;//鼠标按下时间(无用)
	public float initMouseDownDT=0.5f;//预设鼠标按下时间(无用)
	private bool isMove=false;//是否施加了一个移动指令(无用)

	void Awake(){
		Instance = this;

	}

	// properties
	[behaviac.MemberMetaInfo("Status", "Status")]
	public int Status = 0;

	[behaviac.MemberMetaInfo("MouseStatus", "MouseStatus")]
	public int MouseStatus = 0;

	[behaviac.MemberMetaInfo("isConAva", "isConAva")]
	public bool isConAva = false;

	// methods

	[behaviac.MethodMetaInfo("WaitForOrder", "WaitForOrder")]
	private void WaitForOrder()
	{
		// Write your logic codes here.
		//如果鼠标被按下
		if (Input.GetMouseButtonDown (0) && !isMouseOnUI ()) {
			//TargetRect.Instance.transform.position = Input.mousePosition;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitinfo;
			if(Physics.Raycast(ray,out hitinfo,1000,LandMask)){
				preMousePos = hitinfo.point + new Vector3 (0f, 0f, 0f);
				TargetRect.Instance.gameObject.SetActive (true);
				TargetRect.Instance.transform.position = preMousePos;
				Status = 1;//跳到Selecting();
			}
		}

	}
	//大部分的控制指令在这里实现
	[behaviac.MethodMetaInfo("Selecting", "Selecting")]
	private void Selecting()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitinfo;
		if(Physics.Raycast(ray,out hitinfo,1000,LandMask)){
			curMousePos = hitinfo.point + new Vector3 (0f, 0f, 0f);
			TargetRect.Instance.transform.localScale=new Vector3(preMousePos.x-curMousePos.x,preMousePos.y-curMousePos.y,1.0f);
			//Debug.Log ("pre:" + preMousePos + "  cur:" + curMousePos);
		}
		if (Input.GetMouseButtonUp (0)) {
			//如果为点击，就判断与前一次点击的距离，如果为双击，就进攻，单击，就移动
			float MosDis=Vector3.Distance (preMousePos, curMousePos);
			if (MosDis<=iniMosPosDis) {
				float LasMosDis=Vector3.Distance (lastMosPos, curMousePos);
				if (LasMosDis <= iniMosPosDis) {
					Debug.Log ("进攻！");
					foreach(GameObject g in Game_Ctrl.Instance.SelectUnitList){
						int id=g.GetComponent<Unit> ().UnitId;
						string msg = "Strike:1/1/"+id+"/"+curMousePos.x+"/"+curMousePos.y+"/"+curMousePos.z;
						Game_Ctrl.Instance.OffGameMessageIn (msg,0);
					}

				} else {
					Debug.Log ("移动！");
				}
				lastMosPos = curMousePos;
				
			}else {
				Debug.Log ("选择！");
				lastMosPos =new Vector3 (0f, 0f, 0f);
				//Vector2 LDRectP = new Vector2 (preMousePos.x <= curMousePos.x ? preMousePos.x : curMousePos.x, preMousePos.y <= curMousePos.y ? preMousePos.y : curMousePos.y);
				SelectRect=//根据选择框画一个矩形，判断单位是否在矩形内
					new Rect(preMousePos.x <= curMousePos.x ? preMousePos.x : curMousePos.x,preMousePos.y <= curMousePos.y ? preMousePos.y : curMousePos.y,
						Mathf.Abs(curMousePos.x-preMousePos.x),Mathf.Abs(curMousePos.y-preMousePos.y));
				//Debug.Log(SelectRect);
				Game_Ctrl.Instance.SelectUnitList.Clear ();//先清空选择列表
				foreach(GameObject g in Game_Ctrl.Instance.MyUnitList){
					Vector2 gp = new Vector2 (g.transform.position.x, g.transform.position.y);
					if (SelectRect.Contains (gp)) {
						Game_Ctrl.Instance.SelectUnitList.Add (g);
					}
				}
			}
			Status = 0;
			TargetRect.Instance.gameObject.SetActive (false);
		}
	}

	[behaviac.MethodMetaInfo("Enter_ReadyConstruct", "Enter_ReadyConstruct")]
	private void Enter_ReadyConstruct()
	{
		// Write your logic codes here.
		Debug.Log("请选择建筑位置");
	}

	[behaviac.MethodMetaInfo("ReadyConstruct", "ReadyConstruct")]
	private void ReadyConstruct()
	{
		// Write your logic codes here.
		#if IPHONE || ANDROID
		if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
		#else
		if (Input.GetMouseButtonDown (0))
		#endif
		{
			if (!isMouseOnUI ()) {
			MouseStatus = 1;
			ReadyBuild = GameObject.Instantiate (Resources.Load (ConstructionPrefabPath + Name, typeof(GameObject)), new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
			Volume = ReadyBuild.GetComponent<Unit> ().collisionVolume;
			}
		}
	}



	[behaviac.MethodMetaInfo("Constructing", "Constructing")]
	private void Constructing()
	{
	// Write your logic codes here.
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 1000, LandMask)) {
			if (righthand) {
				this.x = (int)(hit.point.x / pixel);
				this.y = (int)(hit.point.y / pixel);
				if (this.x+1 - Volume >= 0 && this.x+1<=BattleFieldInit.Instance.x && this.y+1>=0 && this.y+Volume<=BattleFieldInit.Instance.y) {
					Vector3 p = new Vector3 ((this.x + 1) * pixel - Volume * pixel/2, this.y * pixel + Volume * pixel/2, 0f);
					ReadyBuild.transform.position = p;
				}
			}
		}

		if (Input.GetMouseButtonUp (0)) {
			for (int i = 0; i < Volume; i++) {
				for (int j = 0; j < Volume; j++) {
					int d = BattleFieldInit.Instance.BlockArray [BattleFieldInit.Instance.y - (this.y + (Volume)) + i] [this.x - (Volume - 1) + j];
					//Debug.Log ((this.x - (Volume - 1) + i)+","+(BattleFieldInit.Instance.y - (this.y + (Volume - 1)) + j)+"="+d);
					if (d != 0) {
						return;
					}	
				}
			}
			ReadyBuild.GetComponent<Unit> ().x = this.x;
			ReadyBuild.GetComponent<Unit> ().y = this.y;
			isConAva = true;
		}
	}

	void Start () {
		init ();
	}
	// Update is called once per frame
	void Update () {
		btexec ();

	}
	private bool isMouseOnUI(){
		#if IPHONE || ANDROID
		if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
		#else
		if (EventSystem.current.IsPointerOverGameObject())
		#endif
			//Debug.Log("当前触摸在UI上");
			return true;
		else 
			//Debug.Log("当前没有触摸在UI上");
			return false;
	}
	public bool init(){
		this.pixel = Init_Ctrl.Instance.pixel;
		//behaviac.Agent.BindInstance (this, "FSM_Ctrl0");
		if(behaviorTree.Length > 0)
		{
			btloadResult = btload(behaviorTree, true);
			if(btloadResult)
				btsetcurrent(behaviorTree);
			else
				Debug.LogError("Behavior tree data load failed! " + behaviorTree);
		}
		return true;
	}
}
