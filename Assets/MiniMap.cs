using UnityEngine;
using System.Collections;

public class MiniMap : MonoBehaviour {
	private Model _Model;
	private float maxX;
	private float maxY;
	private float curX;
	private float curY;
	// Use this for initialization
	void Start () {
		_Model = GameObject.Find ("Model").GetComponent<Model> ();
		this.maxX = (float)_Model.Mapx;
		this.maxY = (float)_Model.Mapy;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
