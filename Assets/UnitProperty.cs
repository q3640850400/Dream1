using UnityEngine;
using System.Collections;

public class UnitProperty : MonoBehaviour {
	public int userid;
	public int color;
	public int UnitId;
	public int Class;//种类：1兵种，2建筑
	public float LifeMax;//最大生命
	public float LifeCur;//当前生命
	public float ATK=10f;//攻击力
	public float DEF=1f;//防御力
	public float MoveSPD=2f;//移动速度
	public float ATKDT = 1f;//攻击间隔
	public Vector3 SingleTarget;
	//public float Armor;
	public bool canMove;
	public bool canATK;
	public bool Alive;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool move(Vector3 des){
		SingleTarget = des;
		return true;
	}
}
