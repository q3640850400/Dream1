using UnityEngine;
using System.Collections;

public class MiniMap : MonoBehaviour {
	private Model _Model;
	private float maxX;
	private float maxY;
	private float curX;
	private float curY;
	private Camera UICamera;
	private Vector3 screenPos;
	private Rect mapRect;
	// Use this for initialization
	void Start () {
		_Model = GameObject.Find ("Model").GetComponent<Model> ();
		this.maxX = (float)_Model.Mapx;
		this.maxY = (float)_Model.Mapy;
		UICamera = GameObject.Find ("UICamera").GetComponent<Camera> ();
		screenPos = UICamera.WorldToScreenPoint (transform.position);
		//screenPos.z = 0f;
		mapRect=new Rect(screenPos.x-100f,screenPos.y-100f,200f,200f);

	}
	
	// Update is called once per frame
	void Update () {
		test ();
	}
	void test(){
		
		//Debug.Log (screenPos);
		if (Input.GetMouseButtonDown (0)) {			
			//Vector3 mousePos= new Vector2(Input.mousePosition);
			if (mapRect.Contains (Input.mousePosition)) {
				Debug.Log ("yyy");
			}
		}
	}
}
