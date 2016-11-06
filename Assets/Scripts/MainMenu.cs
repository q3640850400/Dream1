using UnityEngine;
using System;
using System.Collections;

public class MainMenu: MonoBehaviour {
	public Texture  backgroundTexture;
	private string instructionText="Instructions:\nPress Left and Right Arrows to move.\nPress Spacebar to fire.";

	private GUIStyle NormalText;
	private string UserId="Pls enter your ID";
	private string Passwd="123456";
	
	//public static AGCC agcc=null;
	
	Vector2  scrollView=new Vector2(0,0);
	string innerText="  Running SpaceShooter2D_Online Demos\n\n  Before you use the SpaceShooter2D_Online demos,\n  enter your own gguid、sguid & gcert into them.\n  In the demo AGCC.cs,find<insert your gguid here>、\n  <insert your sguid here>、<insert your gcert here> and replace it.\n\n  You can get an gguid、sguid、gcert for our arcalet service for free by registering:\n  http://developer.arcalet.com";


	void Awake() {
		NormalText = new GUIStyle();
		NormalText.fontSize = 17;
		NormalText.normal.textColor=new Color(1.0f,1.0f,1.0f,1.0f);		    
		//agcc=(AGCC)FindObjectOfType(typeof(AGCC));
	}

	
	void OnGUI() {
		
		//GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height),backgroundTexture);
		GUI.Label(new Rect(5, 5, 250, 200), instructionText);
		
		scrollView =
			GUI.BeginScrollView(new Rect(-3,225,590,150),scrollView,new Rect(0,0,10,10));
	
	    	innerText=GUI.TextArea(new Rect(0,0,1600,1600),innerText);
	
		GUI.EndScrollView();


		
		// 输入玩家账号
		
		Rect R1=new Rect(82.0f / 300.0f * Screen.width,
								  70.0f / 320.0f * Screen.height,
								  260.0f / 480.0f * Screen.width,
								  18.0f / 320.0f * Screen.height);
		// 输入玩家密码
		
		Rect R2=new Rect(82.0f / 300.0f * Screen.width,
								  95.0f / 320.0f * Screen.height,
								  260.0f / 480.0f * Screen.width,
								  18.0f / 320.0f * Screen.height);
		// 登入按钮
		
		Rect R3=new Rect(82.0f / 280.0f * Screen.width,
								  140.0f / 320.0f * Screen.height,
								  60.0f / 480.0f * Screen.width,
								  20.0f / 320.0f * Screen.height);
		
		// 申请玩家账号按钮
		Rect R4=new Rect(10.0f / 280.0f * Screen.width,
								  140.0f / 320.0f * Screen.height,
								  100.0f / 480.0f * Screen.width,
								  20.0f / 320.0f * Screen.height);
		
		
		
		UserId = GUI.TextArea(R1, UserId, 24, NormalText);
		Passwd = GUI.PasswordField(R2,Passwd,"*"[0], 24,NormalText);
		
		if (GUI.Button(R3,"Start"))
		{
			Debug.Log ("Go");
			Game_Ctrl gc = new Game_Ctrl ();
			gc.ArcaletStartup(UserId,Passwd);
		}
		
		if (GUI.Button(R4,"Get New ID"))
		{
			Application.OpenURL("http://www.arcalet.com/register.asp");	
		}
		
		
	}
	public void startbutton(){
		Debug.Log ("Go="+UserId+","+Passwd);
		Game_Ctrl.Instance.ArcaletStartup(UserId,Passwd);
	}
}
