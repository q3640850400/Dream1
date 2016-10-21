using UnityEngine;
using System.Collections;

public class TargetRect : MonoBehaviour {
	public static TargetRect Instance;
	public Transform rect;
	void Awake(){
		Instance = this;
	}
	// Use this for initialization
	void Start () {
		gameObject.SetActive(false);
		rect = transform;
	}

	// Update is called once per frame
	void Update () {
		
	
	}
}
