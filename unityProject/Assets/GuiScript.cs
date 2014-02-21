using UnityEngine;
using System.Collections;

public class GuiScript : MonoBehaviour {
	public GUITexture BackDrop;
	public GUITexture Button;
	// Use this for initialization
	void Start () {
		BackDrop.transform.position = new Vector2(0,1);
		BackDrop.pixelInset = new Rect(0, - 116,256,116);

		Button.transform.position = new Vector2(0,1);
		Button.pixelInset = new Rect(32, - 58,128,58);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
