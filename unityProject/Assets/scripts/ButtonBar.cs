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
	public Texture RadioOnTexture;
	public Texture RadioOffTexture;
	public Texture HelpTexture;
	public Texture OptionsTexture;
	public Texture BinIconTexture;
	public Texture DeleteIconTexture;
	#endregion
	#endregion
	#region Skin
	//gui Skin
	public GUISkin mySkin;
	#endregion
	#region Bool variables
	#region Windows
	bool ShowButtonBarWindow = false;
	bool ShowInfomationWindow = false;
	bool ShowHelpWindow = false;
	bool ShowOptionWindow = false;
	bool RecyclingBin = false;
	#endregion
	#region Windows Lock
	bool LockUI = false;
	//buttons
	bool LockOptionsButtonUI = false;
	bool LockHelpButtonUI = false;
	//windows
	bool LockButtonBarUI = false;
	bool LockInfomationUI = false;
	bool LockHelpUI = false;
	bool LockOptionUI = false;
	#endregion
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
	public int DeleteButtonX = 35;
	public int DeleteButtonY = 35;
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
	Vector2 scrollInfomationPosition = new Vector2 (0, 0); //set where the scroll bar starts
	Vector2 scrollHelpPosition = new Vector2 (0, 0); //set where the scroll bar starts
	#endregion
	#region button and bar current postion
	public float CurX;
	public float CurY;
	#endregion
	//logic stuffs
	static string buildingType;
	
	#endregion
	//help image box size
	int Size = 100;
	public int buildingSize = 0;
	public string[] selStrings = new string[] {"Small", "Medium", "Large"};
	//store the building type
	public int buildingNum = 0;
	//the building control object
	public GameObject buildingcont;
	//has a building been bought?
	bool buildingBought = false;

	//building cost
	public int BuildingCost;
	//totals
	int coins  = 0;
	int epoint = 0;
	float polution = 0;
	
	//MapPosistion
	public float ScrollMap;
	//map instance
	Create_map map;

	// Use this for initialization
	void Start ()
	{
		//for the 3d camera
		GameObject.Find ("3D GUI Camera").camera.enabled = false;
		coins = 10;
		map = this.gameObject.GetComponent <Create_map>();
		#region sets the size of the differant windows
		#region Buttons
		ButtonBarWindowPostion = new Rect (10, 465, 60, 70);
		ButtonWindowPostion = new Rect (100, 465, 370, 70);
		helpButtonWindowPostion = new Rect (Screen.width - 60, Screen.height * 0.005f, 50, 50);
		OptionButtonWindowPostion = new Rect (Screen.width - 120, Screen.height * 0.005f, 50, 50);
		#endregion
		#region Windows
		helpWindowPostion = new Rect (Screen.width * 0.5f - 300, Screen.height * 0.2f, 600, 250);
		InfomationWindowPostion = new Rect (Screen.width * 0.5f - 300, Screen.height * 0.2f, 600, 250);
		OptionWindowPostion = new Rect (Screen.width * 0.5f - 300, Screen.height * 0.2f, 600, 250);
		#endregion
		#endregion	
		ScrollMap = 50;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	void AddMoney(int amount)
	{
		coins += amount;
	}
	private void OnGUI ()
	{

		#region Skins and styles
		GUI.skin = mySkin;
		#endregion
		
		#region Labels
		GUI.Box (new Rect (0, 0, 470, 40), "");
		GUI.Label (new Rect (10, 10, 150, 20), "Coins :" + coins);
		GUI.Label (new Rect (110, 10, 150, 20), "E-Points : " + epoint);
		GUI.Label (new Rect (220, 10, 150, 20), "Polution level : " + map.polution);
		GameObject[] NPCTotal = GameObject.FindGameObjectsWithTag("NPC");
		GUI.Label (new Rect (350, 10, 150, 20), "Visitors : "+NPCTotal.Length);
		#endregion
		
        //#region Camera move
        //ScrollMap = GUI.HorizontalScrollbar (new Rect (Screen.width * 0.6f, Screen.height * 0.9f, 500, 70), ScrollMap, 5F, 0.0F, 100.0F);
		
        //Vector3 temp = Camera.main.transform.position;
        //temp.x = ScrollMap;
        //Camera.main.transform.position = temp;
        //#endregion
		
		#region Windows
		ButtonBarWindowPostion = CheckBounds (GUI.Window (0, ButtonBarWindowPostion, ToggleButtonWindow, ""));
		helpButtonWindowPostion = CheckBounds (GUI.Window (1, helpButtonWindowPostion, HelpButtonWindow, ""));
		OptionButtonWindowPostion = CheckBounds (GUI.Window (2, OptionButtonWindowPostion, OptionButtonWindow, ""));
		
		#region to show or not to show windows
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
		#endregion
		#endregion
	}
	
	
	
	#region Button bar
	private void ToggleButtonWindow (int id)
	{
		if (GUI.Button (new Rect (10, 10, 40, 50), ">")) {
			ButtonBarWindowPostion = new Rect (ButtonBarWindowPostion.x, ButtonBarWindowPostion.y, 60, 70);
			ShowButtonBarWindow = !ShowButtonBarWindow;
			Debug.Log ("Main Button Clicked");
		}
		
		if (ShowButtonBarWindow == true) {
			
			ButtonBarWindowPostion = new Rect (ButtonBarWindowPostion.x, ButtonBarWindowPostion.y, 550, 70);
			
			if (GUI.Button (new Rect (70, 10, 50, 50), new GUIContent (icecreamIconTexture, "Ice Cream Shop"))) {
				buildingSize = 0;
				Logic (1);					
			}		

			
			if (GUI.Button (new Rect (130, 10, 50, 50), new GUIContent (giftIconTexture, "Gift Shop"))) {
				buildingSize = 0;
				Logic (2);
			}		
			
			
			if (GUI.Button (new Rect (190, 10, 50, 50), new GUIContent (hotelIconTexture, "Hotel"))) {
				buildingSize = 0;
				Logic (3);
			}		
			
			
			if (GUI.Button (new Rect (250, 10, 50, 50), new GUIContent (lifeguardIconTexture, "Lifeguard"))) {
				buildingSize = 0;
				Logic (4);
			}
			
			
			if (GUI.Button (new Rect (310, 10, 50, 50), new GUIContent (clubsIconTexture, "Club"))) {
				buildingSize = 0;
				Logic (5);
			}
			
			
			if (GUI.Button (new Rect (370, 10, 50, 50), new GUIContent (fisheriesIconTexture, "Fisheries"))) {	
				buildingSize = 0;
				Logic (6);	
			} 

			if (GUI.Button (new Rect (420, 10, 50, 50), new GUIContent (BinIconTexture, "Recycling Bin"))) {	
				buildingSize = 0;
				Logic (7);	
			} 

			if (GUI.Button (new Rect (490, 10, 50, 50), new GUIContent (DeleteIconTexture, "Delete"))) {	
				//Delete
				//Logic (6);	
			} 
			GUI.Label (new Rect (250, 0, 100, 40), GUI.tooltip);
		}
		
		
		if (LockButtonBarUI == false) {
			GUI.DragWindow ();
		}
	}
	
	
	#endregion 
	
	
	#region Infomation
	private void InfomationWindow (int id)
	{

		GUI.Box (new Rect (0, 0, InfomationWindowPostion.width, InfomationWindowPostion.height), "");

		if (RecyclingBin == false){
		buildingSize = GUI.SelectionGrid (new Rect (15, 200, 300, 20), buildingSize, selStrings, 5);
		}

		//for the 3d camera
		GameObject.Find ("3D GUI Camera").camera.enabled = true;
		GameObject.Find ("3D GUI Camera").camera.pixelRect = new Rect(InfomationWindowPostion.x+50, -InfomationWindowPostion.y+Screen.height*0.8f,100,100);
		PickImage ();
		
		GUI.Box (new Rect (200, 50, 365, 125), "");
		GUILayout.BeginArea (new Rect (200, 50, 400, 125));
		scrollInfomationPosition = GUILayout.BeginScrollView (scrollInfomationPosition, GUILayout.Width (390), GUILayout.Height (125));
		GUILayout.Label (Infomation);
		GUILayout.EndScrollView ();	
		GUILayout.EndArea ();
		
		
		//Rorate left
		if (GUI.RepeatButton (new Rect (60, 170, 20, 20), "<")) {
			GameObject.Find("3D Model").transform.Rotate(0,5,0);
		}
		//Rotate right
		if (GUI.RepeatButton (new Rect (120, 170, 20, 20), ">")) {
			GameObject.Find("3D Model").transform.Rotate(0,-5,0);
		}
		
		GUI.Label (new Rect (240, 200, 200, 30), "Cost : " + BuildingCost);
		
		if (GUI.Button (new Rect (300, 190, 200, 40), "Build")) {

			if (BuildingCost <= coins){
				coins = coins - BuildingCost;
			//buildingSize & buildingNum
			int [] SendNum = new int[2];
			SendNum [0] = buildingNum;
			SendNum [1] = buildingSize;
				buildingcont.SendMessage ("Build", SendNum);
			}
		}
		


		GUI.backgroundColor = new Color (0, 0, 0, 0);
		if (GUI.Button (new Rect (InfomationWindowPostion.width - 40,10, DeleteButtonX, DeleteButtonY), CloseButtonTexture)) {
			ShowInfomationWindow = !ShowInfomationWindow;
		}
		if (LockInfomationUI == false) {
			GUI.DragWindow ();
		}
	}
	#endregion
	
	
	#region  Help controls
	private void HelpButtonWindow (int id)
	{
		if (GUI.Button (new Rect (10, 10, 30, 30), HelpTexture)) {
			ShowHelpWindow = !	ShowHelpWindow;				
			Debug.Log ("Help Button Clicked");
		}
		if (LockHelpButtonUI == false) {
			GUI.DragWindow ();
		}
	}
	
	private void HelpWindow (int id)
	{
		GUILayout.BeginArea (new Rect (10, 30, 600, 250));
		scrollHelpPosition = GUILayout.BeginScrollView (scrollHelpPosition, GUILayout.Width (580), GUILayout.Height (200));
		GUILayout.BeginVertical ();
		
		#region Ice creams
		
		#region Small ice cream
		GUILayout.BeginHorizontal ();
		GUILayout.Box (icecreamSmallTexture, GUILayout.Width (Size), GUILayout.Height (Size));
		
		GUILayout.Label ("Small Ice cream shop");
		GUILayout.EndHorizontal ();
		#endregion
		
		GUILayout.Label (LineTexture);
		
		#region Medium ice cream
		GUILayout.BeginHorizontal ();
		GUILayout.Box (icecreamMediumTexture, GUILayout.Width (Size), GUILayout.Height (Size));
		
		GUILayout.Label ("Medium Ice cream shop");
		GUILayout.EndHorizontal ();
		#endregion
		
		GUILayout.Label (LineTexture);
		
		#region Large ice cream
		GUILayout.BeginHorizontal ();
		GUILayout.Box (icecreamLargeTexture, GUILayout.Width (Size), GUILayout.Height (Size));
		
		GUILayout.Label ("Large Ice cream shop");
		GUILayout.EndHorizontal ();
		#endregion
		
		GUILayout.Label (LineTexture);
		
		#endregion
		
		#region Gift Shop
		
		#region Small Gift Shop
		GUILayout.BeginHorizontal ();
		GUILayout.Box (giftSmallTexture, GUILayout.Width (Size), GUILayout.Height (Size));
		
		GUILayout.Label ("Small Gift Shop");
		GUILayout.EndHorizontal ();
		#endregion
		
		GUILayout.Label (LineTexture);
		
		#region Medium ice cream
		GUILayout.BeginHorizontal ();
		GUILayout.Box (giftMediumTexture, GUILayout.Width (Size), GUILayout.Height (Size));
		
		GUILayout.Label ("Medium Gift shop");
		GUILayout.EndHorizontal ();
		#endregion
		
		GUILayout.Label (LineTexture);
		
		#region Large ice cream
		GUILayout.BeginHorizontal ();
		GUILayout.Box (giftLargeTexture, GUILayout.Width (Size), GUILayout.Height (Size));
		
		GUILayout.Label ("Large Gift shop");
		GUILayout.EndHorizontal ();
		#endregion
		
		GUILayout.Label (LineTexture);
		
		#endregion
		
		#region Hotel
		
		#region Small Hotel
		GUILayout.BeginHorizontal ();
		GUILayout.Box (hotelSmallTexture, GUILayout.Width (Size), GUILayout.Height (Size));
		
		GUILayout.Label ("Small Hotel");
		GUILayout.EndHorizontal ();
		#endregion
		
		GUILayout.Label (LineTexture);
		
		#region Medium Hotel
		GUILayout.BeginHorizontal ();
		GUILayout.Box (hotelMediumTexture, GUILayout.Width (Size), GUILayout.Height (Size));
		
		GUILayout.Label ("Medium Hotel");
		GUILayout.EndHorizontal ();
		#endregion
		
		GUILayout.Label (LineTexture);
		
		#region Large Hotel
		GUILayout.BeginHorizontal ();
		GUILayout.Box (hotelLargeTexture, GUILayout.Width (Size), GUILayout.Height (Size));
		
		GUILayout.Label ("Large Hotel");
		GUILayout.EndHorizontal ();
		#endregion
		
		GUILayout.Label (LineTexture);
		
		#endregion
		
		#region Life guard
		
		#region Small Life Guard
		GUILayout.BeginHorizontal ();
		GUILayout.Box (lifeguardSmallTexture, GUILayout.Width (Size), GUILayout.Height (Size));
		
		GUILayout.Label ("Small Life Guard");
		GUILayout.EndHorizontal ();
		#endregion
		
		GUILayout.Label (LineTexture);
		
		#region Medium Life Guard
		GUILayout.BeginHorizontal ();
		GUILayout.Box (lifeguardMediumTexture, GUILayout.Width (Size), GUILayout.Height (Size));
		
		GUILayout.Label ("Medium Life Guard");
		GUILayout.EndHorizontal ();
		#endregion
		
		GUILayout.Label (LineTexture);
		
		#region Large Life Guard
		GUILayout.BeginHorizontal ();
		GUILayout.Box (lifeguardLargeTexture, GUILayout.Width (Size), GUILayout.Height (Size));
		
		GUILayout.Label ("Large Life Guard");
		GUILayout.EndHorizontal ();
		#endregion
		
		GUILayout.Label (LineTexture);
		
		#endregion
		
		#region Clubs
		
		#region Small Club
		GUILayout.BeginHorizontal ();
		GUILayout.Box (clubsSmallTexture, GUILayout.Width (Size), GUILayout.Height (Size));
		
		GUILayout.Label ("Small Club");
		GUILayout.EndHorizontal ();
		#endregion
		
		GUILayout.Label (LineTexture);
		
		#region Medium Club
		GUILayout.BeginHorizontal ();
		GUILayout.Box (clubsMediumTexture, GUILayout.Width (Size), GUILayout.Height (Size));
		
		GUILayout.Label ("Medium Club");
		GUILayout.EndHorizontal ();
		#endregion
		
		GUILayout.Label (LineTexture);
		
		#region Large Club
		GUILayout.BeginHorizontal ();
		GUILayout.Box (clubsLargeTexture, GUILayout.Width (Size), GUILayout.Height (Size));
		
		GUILayout.Label ("Large Club");
		GUILayout.EndHorizontal ();
		#endregion
		
		GUILayout.Label (LineTexture);
		
		#endregion
		
		#region Fisheries
		
		#region Small Fisherie
		GUILayout.BeginHorizontal ();
		GUILayout.Box (fisheriesSmallTexture, GUILayout.Width (Size), GUILayout.Height (Size));
		
		GUILayout.Label ("Small Fisherie");
		GUILayout.EndHorizontal ();
		#endregion
		
		GUILayout.Label (LineTexture);
		
		#region Medium Fisherie
		GUILayout.BeginHorizontal ();
		GUILayout.Box (fisheriesMediumTexture, GUILayout.Width (Size), GUILayout.Height (Size));
		
		GUILayout.Label ("Medium Fisherie");
		GUILayout.EndHorizontal ();
		#endregion
		
		GUILayout.Label (LineTexture);
		
		#region Large Fisherie
		GUILayout.BeginHorizontal ();
		GUILayout.Box (fisheriesMediumTexture, GUILayout.Width (Size), GUILayout.Height (Size));
		
		GUILayout.Label ("Large Fisherie");
		GUILayout.EndHorizontal ();
		#endregion
		
		GUILayout.Label (LineTexture);
		
		#endregion
		
		GUILayout.EndVertical ();
		
		
		GUILayout.EndScrollView ();
		GUILayout.EndArea ();
		GUI.backgroundColor = new Color (0, 0, 0, 0);
		if (GUI.Button (new Rect (helpWindowPostion.width - 40,10, DeleteButtonX, DeleteButtonY), CloseButtonTexture)) {
			ShowHelpWindow = !	ShowHelpWindow;
		}
		
		if (LockHelpUI == false) {
			GUI.DragWindow ();
		}
	}
	#endregion
	
	
	#region Option controls
	private void OptionButtonWindow (int id)
	{
		if (GUI.Button (new Rect (10, 10, 30, 30), OptionsTexture)) {
			ShowOptionWindow = !ShowOptionWindow;
			Debug.Log ("Options Button Clicked");
		}
		if (LockOptionsButtonUI == false) {
			GUI.DragWindow ();
		}
	}
	
	private void OptionWindow (int id)
	{
		GUILayout.BeginVertical ();
		
		#region Button Bar
		GUILayout.BeginHorizontal ();
		if (LockButtonBarUI == false) {
			GUILayout.Label ("Lock Button Bar");
			if (GUILayout.Button (RadioOffTexture, GUILayout.Width (30), GUILayout.Height (30))) {
				LockButtonBarUI = ! LockButtonBarUI;
			}		
		} else {
			GUILayout.Label ("Un-Lock Button Bar");
			if (GUILayout.Button (RadioOnTexture, GUILayout.Width (30), GUILayout.Height (30))) {
				LockButtonBarUI = ! LockButtonBarUI;
			}
		}
		GUILayout.EndHorizontal ();
		#endregion
		
		#region Help Window
		GUILayout.BeginHorizontal ();
		if (LockHelpUI == false) {
			GUILayout.Label ("Lock Help Window");
			if (GUILayout.Button (RadioOffTexture, GUILayout.Width (30), GUILayout.Height (30))) {
				LockHelpUI = ! LockHelpUI;
			}	
		} else {
			GUILayout.Label ("Un-Lock Help Window");
			if (GUILayout.Button (RadioOnTexture, GUILayout.Width (30), GUILayout.Height (30))) {
				LockHelpUI = ! LockHelpUI;
			}	
		}
		GUILayout.EndHorizontal ();
		#endregion
		
		#region Infomation Window
		GUILayout.BeginHorizontal ();
		if (LockInfomationUI == false) {
			GUILayout.Label ("Lock Infomation Window");
			if (GUILayout.Button (RadioOffTexture, GUILayout.Width (30), GUILayout.Height (30))) {
				LockInfomationUI = ! LockInfomationUI;
			}		
		} else {
			GUILayout.Label ("Un-Lock Infomation Window");
			if (GUILayout.Button (RadioOnTexture, GUILayout.Width (30), GUILayout.Height (30))) {
				LockInfomationUI = ! LockInfomationUI;
			}	
		}
		GUILayout.EndHorizontal ();
		#endregion
		
		#region Infomation Window
		GUILayout.BeginHorizontal ();
		if (LockOptionUI == false) {
			GUILayout.Label ("Lock Option Window");
			if (GUILayout.Button (RadioOffTexture, GUILayout.Width (30), GUILayout.Height (30))) {
				LockOptionUI = ! LockOptionUI;
			}		
		} else {
			GUILayout.Label ("Un-Lock Option Window");
			if (GUILayout.Button (RadioOnTexture, GUILayout.Width (30), GUILayout.Height (30))) {
				LockOptionUI = ! LockOptionUI;
			}	
		}
		GUILayout.EndHorizontal ();
		#endregion		
		
		#region Infomation Window
		GUILayout.BeginHorizontal ();
		if (LockOptionsButtonUI == false) {
			GUILayout.Label ("Lock Option Button");
			if (GUILayout.Button (RadioOffTexture, GUILayout.Width (30), GUILayout.Height (30))) {
				LockOptionsButtonUI = ! LockOptionsButtonUI;
			}		
		} else {
			GUILayout.Label ("Un-Lock Option Button");
			if (GUILayout.Button (RadioOnTexture, GUILayout.Width (30), GUILayout.Height (30))) {
				LockOptionsButtonUI = ! LockOptionsButtonUI;
			}	
		}
		GUILayout.EndHorizontal ();
		#endregion	
		
		#region Infomation Window
		GUILayout.BeginHorizontal ();
		if (LockHelpButtonUI == false) {
			GUILayout.Label ("Lock Help Button");
			if (GUILayout.Button (RadioOffTexture, GUILayout.Width (30), GUILayout.Height (30))) {
				LockHelpButtonUI = ! LockHelpButtonUI;
			}		
		} else {
			GUILayout.Label ("Un-Lock Help Button");
			if (GUILayout.Button (RadioOnTexture, GUILayout.Width (30), GUILayout.Height (30))) {
				LockHelpButtonUI = ! LockHelpButtonUI;
			}	
		}
		GUILayout.EndHorizontal ();
		#endregion	
		
		GUILayout.EndVertical ();
		
		GUI.backgroundColor = new Color (0, 0, 0, 0);
		if (GUI.Button (new Rect (OptionWindowPostion.width - 40,10, DeleteButtonX, DeleteButtonY), CloseButtonTexture)) {
			ShowOptionWindow = !ShowOptionWindow;
		}
		
		
		if (LockOptionUI == false) {
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
				RecyclingBin = false;
				break;
			case 2:
				//gift shop
				buildingType = "Gift Shop";
				Infomation = "This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test";
				RecyclingBin = false;
				break;
			case 3:
				//hotel
				buildingType = "Hotel";
				Infomation = "This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test";
				RecyclingBin = false;
				break;
			case 4:
				//lifeguard
				buildingType = "Life Guard";
				Infomation = "This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test";
				RecyclingBin = false;
				break;
			case 5:
				//clubs
				buildingType = "Club";
				Infomation = "This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test";
				RecyclingBin = false;
				break;
			case 6:
				//fisheries
				buildingType = "Fisheries";
				Infomation = "This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test";
				RecyclingBin = false;
				break;
			case 7:
				//Bin
				buildingType = "Recycling Bin";
				Infomation = "This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test";
				RecyclingBin = true;
				break;
			}
		}
	}
	
	private void PickImage ()
	{
		switch (buildingNum) {
			#region Ice cream
		case 1:
			switch (buildingSize) {
			case 0:
				BuildingCost = 1;
				break;
			case 1:
				BuildingCost = 2;
				break;
			case 2:
				BuildingCost = 3;
				break;
			}
			break;
			#endregion
			
			#region Gift
		case 2:
			switch (buildingSize) {
			case 0:
				BuildingCost = 1;
				break;
			case 1:
				BuildingCost = 2;
				break;
			case 2:
				BuildingCost = 3;
				break;
			}
			break;
			#endregion
			
			#region Hotel
		case 3:
			switch (buildingSize) {
			case 0:
				BuildingCost = 1;
				break;
			case 1:
				BuildingCost = 2;
				break;
			case 2:
				BuildingCost = 3;
				break;
			}
			break;
			#endregion
			
			#region Life guard
		case 4:
			switch (buildingSize) {
			case 0:
				BuildingCost = 1;
				break;
			case 1:
				BuildingCost = 2;
				break;
			case 2:
				BuildingCost = 3;
				break;
			}
			break;
			#endregion
			
			#region Clubs
		case 5:
			switch (buildingSize) {
			case 0:
				BuildingCost = 1;
				break;
			case 1:
				BuildingCost = 2;
				GUI.DrawTexture (new Rect (0, 0, 200, 200), clubsMediumTexture, ScaleMode.ScaleToFit, true, 0);
				break;
			case 2:
				BuildingCost = 3;
				break;
			}
			break;
			#endregion
			
			#region Fisherie
		case 6:
			switch (buildingSize) {
			case 0:
				BuildingCost = 1;
				break;
			case 1:
				BuildingCost = 2;
				break;
			case 2:
				BuildingCost = 3;
				break;
			}
			break;
			#endregion

			#region  Bin
		case 7:
			switch (buildingSize) {
			case 0:
				BuildingCost = 1;
				break;
			}
			break;
			#endregion
		}
	}
	
	Rect CheckBounds (Rect r)
	{
		
		
		r.x = Mathf.Clamp (r.x, 0, Screen.width - r.width);
		r.y = Mathf.Clamp (r.y, 0, Screen.height - r.height);
		return r;
		
		
	}
}