using UnityEngine;
using System.Collections;

[ExecuteInEditMode]

public class ButtonBar : MonoBehaviour
{
	#region Varables
	#region Number size codes
		//shops
		//ice cream		1
		//gift shop		2
		//hotel			3
		//lifeguard		4
		//clubs			5
		//fisheries		6

		//building size
		//small			0
		//Medium		1
		//Large			2
	#endregion
	#region Textures
	#region Ice Cream
		//ice cream
		public Texture icecreamSmallTexture;
		public Texture icecreamMediumTexture;
		public Texture icecreamLargeTexture;
		public Texture icecreamIconTexture;
	#endregion
	#region Gift Shop
		//gift shop
		public Texture giftSmallTexture;
		public Texture giftMediumTexture;
		public Texture giftLargeTexture;
		public Texture giftIconTexture;
	#endregion
	#region Hotel
		//hotel
		public Texture hotelSmallTexture;
		public Texture hotelMediumTexture;
		public Texture hotelLargeTexture;
		public Texture hotelIconTexture;
	#endregion
	#region Lifeguard
		//lifeguard
		public Texture lifeguardSmallTexture;
		public Texture lifeguardMediumTexture;
		public Texture lifeguardLargeTexture;
		public Texture lifeguardIconTexture;
	#endregion
	#region Clubs
		//clubs
		public Texture clubsSmallTexture;
		public Texture clubsMediumTexture;
		public Texture clubsLargeTexture;
		public Texture clubsIconTexture;
	#endregion
	#region Fisheries
		//fisheries
		public Texture fisheriesSmallTexture;
		public Texture fisheriesMediumTexture;
		public Texture fisheriesLargeTexture;
		public Texture fisheriesIconTexture;
	#endregion
	#region Random textures
		public Texture LineTexture;
		public Texture CloseButtonTexture;
	#endregion
	#endregion
	#region Skin
		//gui Skin
		public GUISkin mySkin;
	#endregion
	#region Bool variables
		//bool vars to decide when to show the bars
		bool ShowButtonBarWindow = false;
		bool ShowInfomationWindow = false;
		bool ShowHelpWindow = false;
		bool ShowOptionWindow = false;
	bool LockUI = false;
	#endregion
	#region Button selection
		//selection of the bar
		int CurSelection;
		int OldSelection;
	#endregion
	#region Window sizes
		//Size of the window
	#region Buttons
		//buttons
		public Rect ButtonBarWindowPostion = new Rect (0, 0, 0, 0);
		public Rect helpButtonWindowPostion = new Rect (0, 0, 0, 0);
		public Rect OptionButtonWindowPostion = new Rect (0, 0, 0, 0);
	#endregion
	#region Windows
		//windows
		public Rect ButtonWindowPostion = new Rect (0, 0, 0, 0);
		public Rect helpWindowPostion = new Rect (0, 0, 0, 0);
		public Rect InfomationWindowPostion = new Rect (0, 0, 0, 0);
		public Rect OptionWindowPostion = new Rect (0, 0, 0, 0);
	#endregion
	#endregion
	#region Text Field in info window
		//text box for decripction
		public Rect textArea = new Rect (0, 0, 200, 200);// size of the text field
		public string Infomation; // infomation is what is written in the decripction text field
		Vector2 scrollPosition = new Vector2 (0, 0); //set where the scroll bar starts
	#endregion
	#region button and bar current postion
		public float CurX;
		public float CurY;
	#endregion
		//logic stuffs
		static string buildingType;
		
	#endregion
		public int buildingSize = 0;
		public string[] selStrings = new string[] {"Small", "Medium", "Large"};
	//store the building type
	public int buildingNum = 0;
	//the building control object
	public GameObject buildingcont;
	//has a building been bought?
	bool buildingBought = false;
		// Use this for initialization
		void Start ()
		{
	
				#region sets the size of the differant windows
				#region Buttons
				ButtonBarWindowPostion = new Rect (10, 465, 40, 70);
				ButtonWindowPostion = new Rect (100, 465, 370, 70);
			helpButtonWindowPostion = new Rect (Screen.width-60, Screen.height * 0.005f, 50, 50);
			OptionButtonWindowPostion = new Rect (Screen.width-120, Screen.height * 0.005f, 50, 50);
				#endregion
				#region Windows
				helpWindowPostion = new Rect (Screen.width * 0.5f - 300, Screen.height * 0.2f, 600, 250);
				InfomationWindowPostion = new Rect (Screen.width * 0.5f - 300, Screen.height * 0.2f, 600, 250);
				OptionWindowPostion = new Rect (Screen.width * 0.5f - 300, Screen.height * 0.2f, 600, 250);
				#endregion
				#endregion	
		}

		// Update is called once per frame
		void Update ()
		{
	
		}

		private void OnGUI ()
		{
				GUI.skin = mySkin;

		//remove these soon ( change to 2 bar 2 images )
				//ButtonBarWindowPostion = new Rect (ButtonWindowPostion.x - 50, Screen.height - 80, 40, 70);
				//ButtonWindowPostion = new Rect (ButtonBarWindowPostion.x + 50, ButtonBarWindowPostion.y, 370, 70);
				//GUI.color = new Color( 1, 1, 1, 1 );
		ButtonBarWindowPostion = CheckBounds (GUI.Window (0, ButtonBarWindowPostion, ToggleButtonWindow, ""));
		helpButtonWindowPostion = CheckBounds (GUI.Window (1, helpButtonWindowPostion, HelpButtonWindow, ""));
		OptionButtonWindowPostion = CheckBounds (GUI.Window (2, OptionButtonWindowPostion, OptionButtonWindow, ""));

				//buttonbar Window
				//if (ShowButtonBarWindow == true) {
			//ButtonWindowPostion = CheckBounds (GUI.Window (3, ButtonWindowPostion, ButtonBarWindow, ""));
			//	}
				//infomation window
				if (ShowInfomationWindow == true) {
			InfomationWindowPostion = CheckBounds (GUI.Window (4, InfomationWindowPostion, InfomationWindow, buildingType));
				}

				//help window
				if (ShowHelpWindow == true) {
			helpWindowPostion = CheckBounds (GUI.Window (5, helpWindowPostion, HelpWindow, "Help"));
				}
				//opcions window
				if (ShowOptionWindow == true) {
			OptionWindowPostion = CheckBounds (GUI.Window (6, OptionWindowPostion, OptionWindow, "Options"));
				}	
		}
	

		
	#region Button bar
		private void ToggleButtonWindow (int id)
		{
				if (GUI.Button (new Rect (10, 10, 20, 50), ">")) {
			ButtonBarWindowPostion = new Rect (	ButtonBarWindowPostion.x, 	ButtonBarWindowPostion.y, 40, 70);
						ShowButtonBarWindow = !ShowButtonBarWindow;
						Debug.Log ("Main Button Clicked");
				}

		if (ShowButtonBarWindow == true) {

			ButtonBarWindowPostion = new Rect (	ButtonBarWindowPostion.x, 	ButtonBarWindowPostion.y, 410, 70);

			if (GUI.Button (new Rect (50, 10, 50, 50), new GUIContent (icecreamIconTexture, "Ice Cream Shop"))) {
				Logic (1);					
			}		
			GUI.Label (new Rect (70, 40, 100, 40), GUI.tooltip);


			if (GUI.Button (new Rect (110, 10, 50, 50), new GUIContent (giftIconTexture, "Gift Shop"))) {
				Logic (2);
			}		
			GUI.Label (new Rect (70, 40, 100, 40), GUI.tooltip);


			if (GUI.Button (new Rect (170, 10, 50, 50), new GUIContent (hotelIconTexture, "Hotel"))) {
				Logic (3);
			}		
			GUI.Label (new Rect (70, 40, 100, 40), GUI.tooltip);


			if (GUI.Button (new Rect (230, 10, 50, 50), new GUIContent (lifeguardIconTexture, "Lifeguard"))) {
				Logic (4);
			}
			GUI.Label (new Rect (70, 40, 100, 40), GUI.tooltip);


			if (GUI.Button (new Rect (290, 10, 50, 50), new GUIContent (clubsIconTexture, "Club"))) {
				Logic (5);
			}
			GUI.Label (new Rect (70, 40, 100, 40), GUI.tooltip);


			if (GUI.Button (new Rect (350, 10, 50, 50), new GUIContent (fisheriesIconTexture, "Fisheries"))) {		
				Logic (6);	
			}
			else{

			}
		}

			
		if (LockUI == false) {
			GUI.DragWindow ();
		}
		}

		private void ButtonBarWindow (int id)
		{

				if (GUI.Button (new Rect (10, 10, 50, 50), new GUIContent (icecreamIconTexture, "Ice Cream Shop"))) {
						Logic (1);					
				}		
				GUI.Label (new Rect (70, 40, 100, 40), GUI.tooltip);
				if (GUI.Button (new Rect (70, 10, 50, 50), new GUIContent (giftIconTexture, "Gift Shop"))) {
						Logic (2);
				}		
				GUI.Label (new Rect (70, 40, 100, 40), GUI.tooltip);
				if (GUI.Button (new Rect (130, 10, 50, 50), new GUIContent (hotelIconTexture, "Hotel"))) {
						Logic (3);
				}		
				GUI.Label (new Rect (70, 40, 100, 40), GUI.tooltip);
				if (GUI.Button (new Rect (190, 10, 50, 50), new GUIContent (lifeguardIconTexture, "Lifeguard"))) {
						Logic (4);
				}
				GUI.Label (new Rect (70, 40, 100, 40), GUI.tooltip);
				if (GUI.Button (new Rect (250, 10, 50, 50), new GUIContent (clubsIconTexture, "Club"))) {
						Logic (5);
				}
				GUI.Label (new Rect (70, 40, 100, 40), GUI.tooltip);
				if (GUI.Button (new Rect (310, 10, 50, 50), new GUIContent (fisheriesIconTexture, "Fisheries"))) {		
						Logic (6);	
				}
		if (LockUI == false) {
						GUI.DragWindow ();
				}
		}
	#endregion 


	#region Infomation
		private void InfomationWindow (int id)
		{
		
				//main image

		
				//GUI.DrawTexture (new Rect (0, 0, 200, 200), clubsMediumTexture, ScaleMode.ScaleToFit, true, 0);

				buildingSize = GUI.SelectionGrid (new Rect (15, 200, 300, 20), buildingSize, selStrings, 5);

		switch (buildingSize) {
				case 0:
			//Small
						break;
				case 1:
			//Medium
			GUI.DrawTexture (new Rect (0, 0, 200, 200), clubsMediumTexture, ScaleMode.ScaleToFit, true, 0);
						break;
				case 2:
			//Large
						break;
				}
				GUI.Box (new Rect (200, 50, 365, 125), "");
				GUILayout.BeginArea (new Rect (200, 50, 400, 125));
				scrollPosition = GUILayout.BeginScrollView (scrollPosition, GUILayout.Width (390), GUILayout.Height (125));
				GUILayout.Label (Infomation);
				GUILayout.EndScrollView ();	
				GUILayout.EndArea ();
		
		
				//previous
				if (GUI.Button (new Rect (60, 170, 20, 20), "<")) {
					
				}
				//next
				if (GUI.Button (new Rect (120, 170, 20, 20), ">")) {
					
				}

				//small
		
				if (GUI.Button (new Rect (300, 190, 200, 40), "Build")) {
			//buildingSize & buildingNum
			int []SendNum = new int[2];
			SendNum[0] = buildingNum;
			SendNum[1] = buildingSize;
			buildingcont.SendMessage("Build",SendNum);
				}

			
				GUI.backgroundColor = new Color (0, 0, 0, 0);
				if (GUI.Button (new Rect (InfomationWindowPostion.width - 25, 5, 20, 20), CloseButtonTexture)) {
						ShowInfomationWindow = !ShowInfomationWindow;
				}
		if (LockUI == false) {
			GUI.DragWindow ();
		}
		}
	#endregion
	
	
	#region  Help controls
		private void HelpButtonWindow (int id)
		{
				if (GUI.Button (new Rect (10, 10, 30, 30), "H")) {
						ShowHelpWindow = !	ShowHelpWindow;				
						Debug.Log ("Help Button Clicked");
				}
		if (LockUI == false) {
			GUI.DragWindow ();
		}
		}

		private void HelpWindow (int id)
		{
				GUILayout.BeginArea (new Rect (10, 30, 600, 250));
				scrollPosition = GUILayout.BeginScrollView (scrollPosition, GUILayout.Width (580), GUILayout.Height (200));
				GUILayout.BeginVertical ();

				GUILayout.BeginHorizontal ();
				if (GUILayout.Button (icecreamIconTexture, GUILayout.Width (50), GUILayout.Height (50))) {
				}
				GUILayout.Label ("Ice cream shop");
				GUILayout.EndHorizontal ();

				GUILayout.Label (LineTexture);

				GUILayout.BeginHorizontal ();
				if (GUILayout.Button (giftIconTexture, GUILayout.Width (50), GUILayout.Height (50))) {
				}
				GUILayout.Label ("Gift shop");
				GUILayout.EndHorizontal ();

				GUILayout.Label (LineTexture);

				GUILayout.BeginHorizontal ();
				if (GUILayout.Button (hotelIconTexture, GUILayout.Width (50), GUILayout.Height (50))) {
				}
				GUILayout.Label ("Hotel");
				GUILayout.EndHorizontal ();

				GUILayout.Label (LineTexture);

				GUILayout.BeginHorizontal ();
				if (GUILayout.Button (lifeguardIconTexture, GUILayout.Width (50), GUILayout.Height (50))) {
				}
				GUILayout.Label ("Lifeguard");
				GUILayout.EndHorizontal ();

				GUILayout.Label (LineTexture);

				GUILayout.BeginHorizontal ();
				if (GUILayout.Button (clubsIconTexture, GUILayout.Width (50), GUILayout.Height (50))) {
				}
				GUILayout.Label ("Clubs");
				GUILayout.EndHorizontal ();

				GUILayout.Label (LineTexture);

				GUILayout.BeginHorizontal ();
				if (GUILayout.Button (fisheriesIconTexture, GUILayout.Width (50), GUILayout.Height (50))) {
				}
				GUILayout.Label ("Fisheries");
				GUILayout.EndHorizontal ();
				GUILayout.EndVertical ();


				GUILayout.EndScrollView ();
				GUILayout.EndArea ();
				GUI.backgroundColor = new Color (0, 0, 0, 0);
				if (GUI.Button (new Rect (helpWindowPostion.width - 25, 5, 20, 20), CloseButtonTexture)) {
						ShowHelpWindow = !	ShowHelpWindow;
				}

		if (LockUI == false) {
			GUI.DragWindow ();
		}
		}
	#endregion


	#region Opction controls
		private void OptionButtonWindow (int id)
		{
				if (GUI.Button (new Rect (10, 10, 30, 30), "O")) {
						ShowOptionWindow = !ShowOptionWindow;
						Debug.Log ("Options Button Clicked");
				}
		if (LockUI == false) {
			GUI.DragWindow ();
		}
		}

		private void OptionWindow (int id)
		{
		if (GUI.Button (new Rect (10, 10, 50, 50), new GUIContent ("Lock"))) {
			LockUI=!LockUI;					
		}	
				GUI.backgroundColor = new Color (0, 0, 0, 0);
				if (GUI.Button (new Rect (OptionWindowPostion.width - 25, 5, 20, 20), CloseButtonTexture)) {
						ShowOptionWindow = !ShowOptionWindow;
				}


		if (LockUI == false) {
			GUI.DragWindow ();
		}
		}
	#endregion
		private void Logic (int CurSelection)
		{


	
				if (CurSelection == OldSelection && ShowInfomationWindow == true) {
						ShowInfomationWindow = false;
				} else {
						OldSelection = CurSelection;
						ShowInfomationWindow = true;
			//sets the variable that will be passed to the building controller
			buildingNum = CurSelection;
						switch (CurSelection) {
						case 1:
				//ice cream
								buildingType = "Ice Cream Shop";
								Infomation = "This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test";

								break;
						case 2:
				//gift shop
								buildingType = "Gift Shop";
								break;
						case 3:
				//hotel
								buildingType = "Hotel";
								break;
						case 4:
				//lifeguard
								buildingType = "Life Guard";
								break;
						case 5:
				//clubs
								buildingType = "Club";
								break;
						case 6:
				//fisheries
								buildingType = "Fisheries";
								break;
						}
				}
		}
	Rect CheckBounds (Rect r){


		r.x = Mathf.Clamp(r.x,0,Screen.width-r.width);
		r.y = Mathf.Clamp(r.y,0,Screen.height-r.height);
		return r;

	
	}
}