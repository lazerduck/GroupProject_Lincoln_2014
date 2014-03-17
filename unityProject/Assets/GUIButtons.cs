//buttons will go here

using UnityEngine;
using System.Collections;

public class GUIButtons : MonoBehaviour {

	static public bool ButtonToggle = false;


	public GUITexture Button1;
	public GUITexture Button2;
	public GUITexture Button3;
	public GUITexture Button4;
	public GUITexture Button5;

	// Use this for initialization
	void Start () {

		//1
		Button1.transform.position = new Vector2(0,1);
		Button1.pixelInset = new Rect(32, - 400, 32,58);

		//2
		Button2.transform.position = new Vector2 (0, 1);
		Button2.pixelInset = new Rect (64, -400, 32, 58);
		Button2.active = false;
		//3
		Button3.transform.position = new Vector2 (0, 1);
		Button3.pixelInset = new Rect (96, -400, 32, 58);
		Button3.active = false;
		//4
		Button4.transform.position = new Vector2 (0, 1);
		Button4.pixelInset = new Rect (128, -400, 32, 58);
		Button4.active = false;
		//5
		Button5.transform.position = new Vector2 (0, 1);
		Button5.pixelInset = new Rect (160, -400, 32, 58);
		Button5.active = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (ButtonToggle == true) 
		{
			Button1.active = true;
			Button2.active = true;
			Button3.active = true;
			Button4.active = true;
			Button5.active = true;

		} else if (ButtonToggle == false)
		{
			Button1.active = false;
			Button2.active = false;
			Button3.active = false;
			Button4.active = false;
			Button5.active = false;

		}
	}
}
