using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class MainMenu : MonoBehaviour {
	public bool centerButton = true;
	public string levelToload = "GameScn";
	static public int GameSize;
	 Rect MainWindowSize = new Rect (0, 0, 250, 90);
	 Rect SecondWindowSize = new Rect (0, 0, 630, 230);
	bool show = false;
	//gui Skin
	public GUISkin mySkin;
private void OnGUI(){
		GUI.skin = mySkin;

		if (show == false)
		{
		MainWindowSize = GUI.Window(0,MainWindowSize, MyWindow, "");

		if (centerButton == true) {
			MainWindowSize.x = (Screen.width * 0.5f)- (MainWindowSize.width * 0.5f);
			MainWindowSize.y = (Screen.height * 0.5f)- (MainWindowSize.height * 0.5f);
				}
		}
		else
		{
			SecondWindowSize = GUI.Window(0,SecondWindowSize, PickGameSize, "Please pick a game size");
			
			if (centerButton == true) {
				SecondWindowSize.x = (Screen.width * 0.5f)- (SecondWindowSize.width * 0.5f);
				SecondWindowSize.y = (Screen.height * 0.5f)- (SecondWindowSize.height * 0.5f);
			}
		}
	}

	private void MyWindow(int id){

		GUILayout.BeginHorizontal ();
		GUILayout.BeginVertical ();
		if (GUILayout.Button ("Start Game"))
		{
			show = true;
		}

		if (GUILayout.Button ("Exit Game"))
		{
			Application.Quit();
		}
		GUILayout.EndVertical ();
		GUILayout.EndHorizontal ();
		}

	private void PickGameSize(int id){

		GUILayout.BeginHorizontal ();

		if (GUILayout.Button (  ("Small"), GUILayout.Width(200), GUILayout.Height(200)))
		{
			GameSize = 1;
			Create_map.temp_cols = 20;
			Application.LoadLevel (levelToload);

		}


		if (GUILayout.Button ("Medium", GUILayout.Width(200), GUILayout.Height(200)))
		{
			GameSize = 2;
			Create_map.temp_cols = 33;
			Application.LoadLevel (levelToload);
		}


		if (GUILayout.Button ("Large", GUILayout.Width(200), GUILayout.Height(200)))
		{
			GameSize = 3;
			Create_map.temp_cols = 50;
			Application.LoadLevel (levelToload);
		}
		GUILayout.EndHorizontal ();

	}
}
