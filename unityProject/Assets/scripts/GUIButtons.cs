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
		Button2.enabled = false;
		//3
		Button3.transform.position = new Vector2 (0, 1);
		Button3.pixelInset = new Rect (96, -400, 32, 58);
		Button3.enabled = false;
		//4
		Button4.transform.position = new Vector2 (0, 1);
		Button4.pixelInset = new Rect (128, -400, 32, 58);
		Button4.enabled = false;
		//5
		Button5.transform.position = new Vector2 (0, 1);
		Button5.pixelInset = new Rect (160, -400, 32, 58);
		Button5.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (ButtonToggle == true) 
		{
			Button1.enabled = true;
			Button2.enabled = true;
			Button3.enabled = true;
			Button4.enabled = true;
			Button5.enabled = true;

		} else if (ButtonToggle == false)
		{
			Button1.enabled = false;
			Button2.enabled = false;
			Button3.enabled = false;
			Button4.enabled = false;
			Button5.enabled = false;

		}
	}
}
