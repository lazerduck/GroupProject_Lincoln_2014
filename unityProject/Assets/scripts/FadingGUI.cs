using UnityEngine;
using System.Collections;

public class FadingGUI : MonoBehaviour{
	private GUITexture gt;
	private float timer = 1F;
	private float pos = -300F;
	private bool fadeIn = false;
	private bool active = false;
	private string text = "hello world";
	// Use this for initialization
	void Start () {
		gt = (GUITexture) gameObject.GetComponent(typeof(GUITexture));
	}
	
	// Update is called once per frame
	void Update () {
				//print(_alpha);

				if (active == true) {
						if ((pos <= 10) && (fadeIn == false)) {
								pos++;
								if (pos > 9) {
										fadeIn = true;
								}
						} else {
								timer++;
								if (pos >= (-300) && (timer > 100)) {
										pos--;
									if (pos == (-300)){
										active = false;
									}
								}
						}
		                  
				}
		}
	void GetText(string newtext){
		text = newtext;
		active = true;
	}
	void OnGUI()
	{
		
		GUI.color = new Color(.5F,.5F,.5F,1F);
		GUI.TextField(new Rect(pos,160,300,30), text);
	}
}
