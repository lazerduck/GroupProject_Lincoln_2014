using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class MainMenu : MonoBehaviour {
	public bool centerButton = false;
	public string levelToload = "GameScn";

	public Rect windowSize = new Rect (0, 0, 250, 90);

private void OnGUI(){

		windowSize = GUI.Window(0,windowSize, MyWindow, "");

		if (centerButton) {
			windowSize.x = (Screen.width * 0.5f)- (windowSize.width * 0.5f);
			windowSize.y = (Screen.height * 0.5f)- (windowSize.height * 0.5f);
				}
	
	}

	private void MyWindow(int id){

		GUILayout.BeginHorizontal ();
		GUILayout.BeginVertical ();
		if (GUILayout.Button ("Start Game"))
			Application.LoadLevel (levelToload);
		if (GUILayout.Button ("Exit Game"))
			Application.Quit();
		GUILayout.EndVertical ();
		GUILayout.EndHorizontal ();
		}
}
