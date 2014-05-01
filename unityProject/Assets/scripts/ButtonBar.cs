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
	public Texture ButtonTexture;
	public Texture ButtonBarTexture;
	public Texture WindowBackgroundTexture;
	public Texture LitterIconTexture;
	public Texture WarningTexture;
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
	bool ShowWarningWindow = false;
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
	public Rect WarningWindowPostion = new Rect (0, 0, 0, 0);
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
	float pollution = 0;
	
	//MapPosistion
	public float ScrollMap;
	//map instance
	Create_map map;

	GameObject thing;
	public GameObject[] buildings = new GameObject[19];
	GameObject buildingthing;
	string OpenorClose;


	GameObject np;
				
	bool quitButton = false;
	int curPolution;
	string leveltoload = "Start";

	bool n10 = false;
	bool n20 = false;
	bool n30 = false;
	bool n40 = false;
	bool n50 = false;
	bool n60 = false;
	bool n70 = false;
	bool n80 = false;
	bool n90 = false;
	bool n100 = false;

	//ice cream		1
	//gift shop		2
	//hotel			3
	//lifeguard		4
	//clubs			5
	//fisheries		6
	string InfomationSmallIceCream = "Building a small ice cream shop will allow for a small percentage of income from the sale of ice cream. Make sure those wrappers, dropped ice cream and sticks do not end up in the sea though. Although not an immediate problem, Ice Cream Shops can eventually cause significant damage to the environment.";
	string InfomationMediumIceCream = "This mobile ice cream van will accommodate more customers per day. The vans products come mainly in wrappers, however, which are non-biodegradable. Make sure those are dealt with before they start costing fish their lives.";
	string InfomationLargeIceCream = "With the new permanent Ice Cream Shop pollution will not increase any further. Although business will increase, causing more trash, the shop itself produces little. Compared to the gas guzzling van, this shop is an upgrade in a cleaner direction.";

	string InfomationSmallGiftShop = "The shop is generates a steady, moderate income with an equally moderate pollution level. Plastic bags, receipts and cardboard boxes can slowly litter the beach if left unchecked. The shop can make for a nice addition to the beach, however, so long as it is catered for correctly.";
	string InfomationMediumGiftShop = "A medium shop. Increased profit and increased pollution. The increased profits can easily be used to keep the increased pollution in check. Bins and litter pickers can be expensive but are ultimately essential.";
	string InfomationLargeGiftShop = "The number of plastic bags that wind up littering the beach is increased further. Those plastic bags catered customers, however. Make sure that larger income goes toward keeping the beach clean though. Plastic bags and other trash can rapidly cause an environmental issue if left unchecked.";

	string InfomationSmallHotel = "A small privately run Bed & Breakfast is a classic trademark of the sea side, usually a 2-3 room capacity. These building will mean your guests will show up quicker. As more visitors show up, pollution levels will slightly rise as the visitors will be around longer to drop litter.";
	string InfomationMediumHotel = "A medium sized hotel with a larger maximum capacity. Plenty of people from all over will be staying for now meaning more frequently arriving people. Just remember to cater for the increased litter from the increased customers!";
	string InfomationLargeHotel =  "A large hotel can accommodate a massive amount of customers, causing more to turn up. More money from the larger amount of customers will be a nice boost to the economy. With the money increase, however, the increased pollution can sometimes be forgotten. do not let it get out of hand.";

	string InfomationSmallLifeguard = "The lifeguard stand is one of the most important parts of running a beach. Having someone around to watch over the beach will increase the maximum number of visitors possible at one time. Luckily, this boost comes with no increased pollution besides the increased business.";
	string InfomationMediumLifeguard = "The maximum number of visitors is increased once again. Although this has no immediate effect on the environment, it is easy to forget that more people mean more business. More business means more pollution.";
	string InfomationLargeLifeguard = "The maximum boost to visitor number. Businesses will thank you but will the fish? More visitors means more trash. Remember to use your increased money to keep the trash at bay.";

	string InfomationSmallClub = "Clubs are large contributors to the pollution and trash problems on beaches. All things sold in clubs come in cans, glasses and bottles, all of which are very dangerous to aquatic life. Their large income can be a great boost to the economy, providing things are in place to deal with the large amount of trash produced.";
	string InfomationMediumClub="As a club expands so does its customer base; normally this would be a good thing but a larger customer base means more trash. The pockets of this clubs owner will be filling up quickly but most of the profit will have to go on marine conservation. Is the larger income worth the stronger pollution?";
	string InfomationLargeClub = "The largest a club can hope to get. Producing a huge amount of pollution every day, this club will help in the terms of economy but everything comes at a cost. The cans, bottles and glasses left behind by customers pose a massive threat to aquatic life and can also be very expensive to deal with.";
	
	string InfomationSmallFisherie = "Fisheries are good for the economy and aren’t bad pollutants, in moderation. Fisheries make their money from fish which, so long as there isn’t already a fish shortage,should not be a problem. Just remember though, there are only so many fish. Having too many fisheries will potentially cause a large amount of damage.";
	string InfomationMediumFisherie =  "This larger version of the fishery is finding much more business, thanks to their new fishing methods. Money will be coming in much faster but so will pollution. The new ships and tools used are great for the economy but really push the boundaries on whats environmentally okay. Dead fish will slowly start popping up on the beach, meaning more bins and litter pickers are needed to keep the fishery in check.";
	string InfomationLargeFisherie = "Although not necessarily becoming a better business, the large fishery produces slightly less pollution than the medium at the cost of a larger price tag. This fishery tries its best to remain environmentally friendly whilst still turning a profit. Remember to keep the trash produced in check though.";

	string TheMessage;
	bool GameOver;
	// Use this for initialization
	void Start ()
	{
			np = GameObject.FindGameObjectWithTag ("npccontrol");
		thing = GameObject.Find ("3D Model");
		//for the 3d camera
		GameObject.Find ("3D GUI Camera").camera.enabled = false;
		coins = 1000;
		map = this.gameObject.GetComponent <Create_map>();
		#region sets the size of the differant windows
		#region Buttons
		ButtonBarWindowPostion = new Rect (10, 465, 60, 100);
		ButtonWindowPostion = new Rect (100, 465, 370, 70);
		helpButtonWindowPostion = new Rect (Screen.width - 60, Screen.height * 0.005f, 50, 50);
		OptionButtonWindowPostion = new Rect (Screen.width - 120, Screen.height * 0.005f, 50, 50);
		#endregion
		#region Windows
		helpWindowPostion = new Rect (Screen.width * 0.5f - 300, Screen.height * 0.2f, 600, 250);
		InfomationWindowPostion = new Rect (Screen.width * 0.5f - 300, Screen.height * 0.2f, 600, 250);
		OptionWindowPostion = new Rect (Screen.width * 0.5f - 300, Screen.height * 0.2f, 600, 250);
		WarningWindowPostion = new Rect (Screen.width * 0.5f - 300, Screen.height * 0.2f, 200, 150);
		#endregion
		#endregion	
		ScrollMap = 50;
		OpenorClose = ">";
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if(quitButton == false)
			{
				quitButton = true;
			} else{
				quitButton = false;
			}
			
				}

		curPolution = (int)map.polution;
		Debug.Log (ShowWarningWindow);
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
		GUI.Label (new Rect (220, 10, 150, 20), "Pollution level : " + map.polution);
		GameObject[] NPCTotal = GameObject.FindGameObjectsWithTag("NPC");
		NPCControl npc = np.GetComponent<NPCControl> ();
		GUI.Label (new Rect (350, 10, 150, 20), "Visitors : "+NPCTotal.Length+"\\"+npc.totalNpc);
		#endregion
		
       	
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

		if (ShowWarningWindow == true){
			WarningWindowPostion = CheckBounds (GUI.Window (7, WarningWindowPostion, WarningWindow, "Warning!"));
		}
		#endregion
		#endregion


		if (curPolution >= 100&& n100 ==false) {
			n100 = true;
			TheMessage = "The pollution at 100  \nGame Over";
			GameOver = true;
			ShowWarningWindow = true;
		} else if (curPolution >= 90&& n90 ==false) {
			n90 = true;
			TheMessage = "The pollution is over 90  \nSea life may never return!";
			ShowWarningWindow = true;
		} else if (curPolution >= 80&& n80 ==false) {
			n80 = true;
			TheMessage = "The pollution is over 80  \nAll the sea life is dead!";
			ShowWarningWindow = true;
		} else if (curPolution >= 70&& n70 ==false) {
			n70 = true;	
			TheMessage = "The pollution is over 10  \nMost the sea life is dead!";
			ShowWarningWindow = true;
		} else if (curPolution >= 60&& n60 ==false) {
			n60 = true;
			TheMessage = "The pollution is over 60  \nThe sea is very polluted!";
			ShowWarningWindow = true;
		} else if (curPolution >= 50&& n50 ==false) {
			n50 = true;
			TheMessage = "The pollution is over 50  \nA lot of the sea life is dead";
			ShowWarningWindow = true;
		} else if (curPolution >= 40&& n40 ==false) {
			n40 = true;
			TheMessage = "The pollution is over 40  \nThe fish are begining to die";
			ShowWarningWindow = true;
		} else if (curPolution >= 30&& n30 ==false) {
			n30 = true;
			TheMessage = "The pollution is over 30  \nThe sea life is under threat";
			ShowWarningWindow = true;
		} else if (curPolution >= 20&& n20 ==false) {
			n20 = true;
			TheMessage = "The pollution is over 20  \nThe sea has become polluted";
			ShowWarningWindow = true;
		} else if (curPolution >= 10 && n10 ==false) {
			n10 = true;
			TheMessage = "The pollution is over 10  \nKeep and eye on it";
			ShowWarningWindow = true;
		}

		//pressing escape to quit ect
		if (quitButton == true) {
			GUI.Box(new Rect (Screen.width/2-100, Screen.height/2*0.4f, 200, 100),"Are you sure you want to quit?");
						if (GUI.Button (new Rect (Screen.width/2-100, Screen.height/2*0.4f+30, 200, 30), "Yes"))
			{
				Application.LoadLevel(leveltoload);		
			}
			if (GUI.Button (new Rect (Screen.width/2-100, Screen.height/2*0.4f+65, 200, 30), "no"))
			{
				quitButton=false;
			}
				}
	}
	
	
	
	#region Button bar
	private void ToggleButtonWindow (int id)
	{
		if (ShowButtonBarWindow == false){
			OpenorClose = ">";
		}
		GUI.DrawTexture (new Rect (0, 0, 610, 100), ButtonBarTexture, ScaleMode.ScaleToFit, true, 6.5F);
		if (GUI.Button (new Rect (10, 40, 40, 50), OpenorClose)) {
			ButtonBarWindowPostion = new Rect (ButtonBarWindowPostion.x, ButtonBarWindowPostion.y, 60, 100);
			ShowButtonBarWindow = !ShowButtonBarWindow;

				}
		
		if (ShowButtonBarWindow == true) {
			OpenorClose = "<";
						ButtonBarWindowPostion = new Rect (ButtonBarWindowPostion.x, ButtonBarWindowPostion.y, 610, 100);
					
						if (GUI.Button (new Rect (70, 40, 50, 50), new GUIContent (icecreamIconTexture, "Ice Cream Shop"))) {
								buildingSize = 0;
								Logic (1);					
						}		

			
						if (GUI.Button (new Rect (130, 40, 50, 50), new GUIContent (giftIconTexture, "Gift Shop"))) {
								buildingSize = 0;
								Logic (2);
						}		
			
			
						if (GUI.Button (new Rect (190, 40, 50, 50), new GUIContent (hotelIconTexture, "Hotel"))) {
								buildingSize = 0;
								Logic (3);
						}		
			
			
						if (GUI.Button (new Rect (250, 40, 50, 50), new GUIContent (lifeguardIconTexture, "Lifeguard"))) {
								buildingSize = 0;
								Logic (4);
						}
			
			
						if (GUI.Button (new Rect (310, 40, 50, 50), new GUIContent (clubsIconTexture, "Club"))) {
								buildingSize = 0;
								Logic (5);
						}
			
			
						if (GUI.Button (new Rect (370, 40, 50, 50), new GUIContent (fisheriesIconTexture, "Fisheries"))) {	
								buildingSize = 0;
								Logic (6);	
						} 

						if (GUI.Button (new Rect (430, 40, 50, 50), new GUIContent (BinIconTexture, "Recycling Bin"))) {	
								buildingSize = 0;
								Logic (7);	
						} 
						if (GUI.Button (new Rect (490, 40, 50, 50), new GUIContent (LitterIconTexture, "Litter Picker"))) {	
				buildingSize = 0;
				Logic (8);	
				
			} 
						if (GUI.Button (new Rect (550, 40, 50, 50), new GUIContent (DeleteIconTexture, "Delete"))) {	
								//Delete
								int[] SendNum = new int[2];
								SendNum [0] = -1;
								SendNum [1] = -1;
								buildingcont.SendMessage ("Build", SendNum);
									
						} 
						GUI.Label (new Rect (290, 10, 100, 40), GUI.tooltip);
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
		GUILayout.Label (Infomation, GUILayout.MaxWidth(360));
		GUILayout.EndScrollView ();	
		GUILayout.EndArea ();
		
		
		//Rorate left
		if (GUI.RepeatButton (new Rect (60, 170, 20, 20), "<")) {
			thing.transform.Rotate(0,5,0);
		}
		//Rotate right
		if (GUI.RepeatButton (new Rect (120, 170, 20, 20), ">")) {
			thing.transform.Rotate(0,-5,0);
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
		if (GUI.Button (new Rect (InfomationWindowPostion.width - 35,0, DeleteButtonX, DeleteButtonY), CloseButtonTexture)) {
			GameObject.Find ("3D GUI Camera").camera.enabled = false;
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
		GUI.Box (new Rect (0, 0, helpWindowPostion.width, helpWindowPostion.height), "");
		GUILayout.BeginArea (new Rect (10, 40, 600, 250));
		scrollHelpPosition = GUILayout.BeginScrollView (scrollHelpPosition, GUILayout.Width (580), GUILayout.Height (200));
		GUILayout.BeginVertical ();
		
		#region Ice creams
		
		#region Small ice cream
		GUILayout.BeginHorizontal ();
		GUILayout.Box (icecreamSmallTexture, GUILayout.Width (Size), GUILayout.Height (Size));
		
		GUILayout.Label ("Small Ice cream shop");
		GUILayout.Label (InfomationSmallIceCream);
		GUILayout.EndHorizontal ();
		#endregion
		
		GUILayout.Label (LineTexture);
		
		#region Medium ice cream
		GUILayout.BeginHorizontal ();
		GUILayout.Box (icecreamMediumTexture, GUILayout.Width (Size), GUILayout.Height (Size));
		
		GUILayout.Label ("Medium Ice cream shop");
		GUILayout.Label (InfomationMediumIceCream);
		GUILayout.EndHorizontal ();
		#endregion
		
		GUILayout.Label (LineTexture);
		
		#region Large ice cream
		GUILayout.BeginHorizontal ();
		GUILayout.Box (icecreamLargeTexture, GUILayout.Width (Size), GUILayout.Height (Size));
		
		GUILayout.Label ("Large Ice cream shop");
		GUILayout.Label (InfomationLargeIceCream);
		GUILayout.EndHorizontal ();
		#endregion
		
		GUILayout.Label (LineTexture);
		
		#endregion
		
		#region Gift Shop
		
		#region Small Gift Shop
		GUILayout.BeginHorizontal ();
		GUILayout.Box (giftSmallTexture, GUILayout.Width (Size), GUILayout.Height (Size));
		
		GUILayout.Label ("Small Gift Shop");
		GUILayout.Label (InfomationSmallGiftShop);
		GUILayout.EndHorizontal ();
		#endregion
		
		GUILayout.Label (LineTexture);
		
		#region Medium ice cream
		GUILayout.BeginHorizontal ();
		GUILayout.Box (giftMediumTexture, GUILayout.Width (Size), GUILayout.Height (Size));
		
		GUILayout.Label ("Medium Gift shop");
		GUILayout.Label (InfomationMediumGiftShop);
		GUILayout.EndHorizontal ();
		#endregion
		
		GUILayout.Label (LineTexture);
		
		#region Large ice cream
		GUILayout.BeginHorizontal ();
		GUILayout.Box (giftLargeTexture, GUILayout.Width (Size), GUILayout.Height (Size));
		
		GUILayout.Label ("Large Gift shop");
		GUILayout.Label (InfomationLargeGiftShop);
		GUILayout.EndHorizontal ();
		#endregion
		
		GUILayout.Label (LineTexture);
		
		#endregion
		
		#region Hotel
		
		#region Small Hotel
		GUILayout.BeginHorizontal ();
		GUILayout.Box (hotelSmallTexture, GUILayout.Width (Size), GUILayout.Height (Size));
		
		GUILayout.Label ("Small Hotel");
		GUILayout.Label (InfomationSmallHotel);
		GUILayout.EndHorizontal ();
		#endregion
		
		GUILayout.Label (LineTexture);
		
		#region Medium Hotel
		GUILayout.BeginHorizontal ();
		GUILayout.Box (hotelMediumTexture, GUILayout.Width (Size), GUILayout.Height (Size));
		
		GUILayout.Label ("Medium Hotel");
		GUILayout.Label (InfomationMediumHotel);
		GUILayout.EndHorizontal ();
		#endregion
		
		GUILayout.Label (LineTexture);
		
		#region Large Hotel
		GUILayout.BeginHorizontal ();
		GUILayout.Box (hotelLargeTexture, GUILayout.Width (Size), GUILayout.Height (Size));
		
		GUILayout.Label ("Large Hotel");
		GUILayout.Label (InfomationLargeHotel);
		GUILayout.EndHorizontal ();
		#endregion
		
		GUILayout.Label (LineTexture);
		
		#endregion
		
		#region Life guard
		
		#region Small Life Guard
		GUILayout.BeginHorizontal ();
		GUILayout.Box (lifeguardSmallTexture, GUILayout.Width (Size), GUILayout.Height (Size));
		
		GUILayout.Label ("Small Life Guard");
		GUILayout.Label (InfomationSmallLifeguard);
		GUILayout.EndHorizontal ();
		#endregion
		
		GUILayout.Label (LineTexture);
		
		#region Medium Life Guard
		GUILayout.BeginHorizontal ();
		GUILayout.Box (lifeguardMediumTexture, GUILayout.Width (Size), GUILayout.Height (Size));
		
		GUILayout.Label ("Medium Life Guard");
		GUILayout.Label (InfomationMediumLifeguard);
		GUILayout.EndHorizontal ();
		#endregion
		
		GUILayout.Label (LineTexture);
		
		#region Large Life Guard
		GUILayout.BeginHorizontal ();
		GUILayout.Box (lifeguardLargeTexture, GUILayout.Width (Size), GUILayout.Height (Size));
		
		GUILayout.Label ("Large Life Guard");
		GUILayout.Label (InfomationLargeLifeguard);
		GUILayout.EndHorizontal ();
		#endregion
		
		GUILayout.Label (LineTexture);
		
		#endregion
		
		#region Clubs
		
		#region Small Club
		GUILayout.BeginHorizontal ();
		GUILayout.Box (clubsSmallTexture, GUILayout.Width (Size), GUILayout.Height (Size));
		
		GUILayout.Label ("Small Club");
		GUILayout.Label (InfomationSmallClub);
		GUILayout.EndHorizontal ();
		#endregion
		
		GUILayout.Label (LineTexture);
		
		#region Medium Club
		GUILayout.BeginHorizontal ();
		GUILayout.Box (clubsMediumTexture, GUILayout.Width (Size), GUILayout.Height (Size));
		
		GUILayout.Label ("Medium Club");
		GUILayout.Label (InfomationMediumClub);
		GUILayout.EndHorizontal ();
		#endregion
		
		GUILayout.Label (LineTexture);
		
		#region Large Club
		GUILayout.BeginHorizontal ();
		GUILayout.Box (clubsLargeTexture, GUILayout.Width (Size), GUILayout.Height (Size));
		
		GUILayout.Label ("Large Club");
		GUILayout.Label (InfomationLargeClub);
		GUILayout.EndHorizontal ();
		#endregion
		
		GUILayout.Label (LineTexture);
		
		#endregion
		
		#region Fisheries
		
		#region Small Fisherie
		GUILayout.BeginHorizontal ();
		GUILayout.Box (fisheriesSmallTexture, GUILayout.Width (Size), GUILayout.Height (Size));
		
		GUILayout.Label ("Small Fisherie");
		GUILayout.Label (InfomationSmallFisherie);
		GUILayout.EndHorizontal ();
		#endregion
		
		GUILayout.Label (LineTexture);
		
		#region Medium Fisherie
		GUILayout.BeginHorizontal ();
		GUILayout.Box (fisheriesMediumTexture, GUILayout.Width (Size), GUILayout.Height (Size));
		
		GUILayout.Label ("Medium Fisherie");
		GUILayout.Label (InfomationMediumFisherie);
		GUILayout.EndHorizontal ();
		#endregion
		
		GUILayout.Label (LineTexture);
		
		#region Large Fisherie
		GUILayout.BeginHorizontal ();
		GUILayout.Box (fisheriesLargeTexture, GUILayout.Width (Size), GUILayout.Height (Size));
		
		GUILayout.Label ("Large Fisherie");
		GUILayout.Label (InfomationLargeFisherie);
		GUILayout.EndHorizontal ();
		#endregion
		
		GUILayout.Label (LineTexture);
		
		#endregion
		
		GUILayout.EndVertical ();
		
		
		GUILayout.EndScrollView ();
		GUILayout.EndArea ();
		GUI.backgroundColor = new Color (0, 0, 0, 0);
		if (GUI.Button (new Rect (helpWindowPostion.width - 35,0, DeleteButtonX, DeleteButtonY), CloseButtonTexture)) {
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
		GUI.Box (new Rect (0, 0, OptionWindowPostion.width, OptionWindowPostion.height), "");
		GUILayout.BeginArea (new Rect (10, 40, 580, 250));
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
		GUILayout.EndArea ();
		GUI.backgroundColor = new Color (0, 0, 0, 0);
		if (GUI.Button (new Rect (OptionWindowPostion.width - 35,0, DeleteButtonX, DeleteButtonY), CloseButtonTexture)) {
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
			GameObject.Find ("3D GUI Camera").camera.enabled = false;
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
				//Infomation = "This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test";
				RecyclingBin = false;
				break;
			case 2:
				//gift shop
				buildingType = "Gift Shop";
				//Infomation = "This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test";
				RecyclingBin = false;
				break;
			case 3:
				//hotel
				buildingType = "Hotel";
				//Infomation = "This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test";
				RecyclingBin = false;
				break;
			case 4:
				//lifeguard
				buildingType = "Life Guard";
				//Infomation = "This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test";
				RecyclingBin = false;
				break;
			case 5:
				//clubs
				buildingType = "Club";
			//	Infomation = "This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test";
				RecyclingBin = false;
				break;
			case 6:
				//fisheries
				buildingType = "Fisheries";
				//Infomation = "This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test";
				RecyclingBin = false;
				break;
			case 7:
				//Bin
				buildingType = "Recycling Bin";
			//	Infomation = "This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test";
				RecyclingBin = true;
				break;
			case 8:
				//Litter Picker
				buildingType = "Litter Picker";
				//Infomation = "This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test This is a test";
				RecyclingBin = true;
				break;
			}
		}
	}
	
	private void PickImage ()
	{
		Destroy (buildingthing);
		Transform[] allChildren;
		switch (buildingNum) {
			#region Ice cream
		case 1:
			switch (buildingSize) {
			case 0:
				BuildingCost = 100;
				Infomation = InfomationSmallIceCream;
				buildingthing = (GameObject)Instantiate(buildings[9]);
				buildingthing.transform.position = thing.transform.position;
				buildingthing.layer = 8;
				allChildren = buildingthing.GetComponentsInChildren<Transform>();
				foreach(Transform g in allChildren)
				{
					g.transform.rotation = thing.transform.rotation;
					g.gameObject.layer = 8;
				}
			break;
			case 1:
				BuildingCost = 300;
				Infomation = InfomationMediumIceCream;
				buildingthing = (GameObject)Instantiate(buildings[10]);
				buildingthing.transform.position = thing.transform.position;
				buildingthing.layer = 8;
				allChildren = buildingthing.GetComponentsInChildren<Transform>();
				foreach(Transform g in allChildren)
				{
					g.transform.rotation = thing.transform.rotation;
					g.gameObject.layer = 8;
				}
				break;
			case 2:
				BuildingCost = 500;
				Infomation = InfomationLargeIceCream;
				buildingthing = (GameObject)Instantiate(buildings[11]);
				buildingthing.transform.position = thing.transform.position;
				buildingthing.layer = 8;
				allChildren = buildingthing.GetComponentsInChildren<Transform>();
				foreach(Transform g in allChildren)
				{
					g.transform.rotation = thing.transform.rotation;
					g.gameObject.layer = 8;
				}
				break;
			}
			break;
			#endregion
			
			#region Gift
		case 2:
			switch (buildingSize) {
			case 0:
				BuildingCost = 300;
				Infomation = InfomationSmallGiftShop;
				buildingthing = (GameObject)Instantiate(buildings[15]);
				buildingthing.transform.position = thing.transform.position;
				buildingthing.layer = 8;
				allChildren = buildingthing.GetComponentsInChildren<Transform>();
				foreach(Transform g in allChildren)
				{
					g.transform.rotation = thing.transform.rotation;
					g.gameObject.layer = 8;
				}
				break;
			case 1:
				BuildingCost = 700;
				Infomation = InfomationMediumGiftShop;
				buildingthing = (GameObject)Instantiate(buildings[16]);
				buildingthing.transform.position = thing.transform.position;
				buildingthing.layer = 8;
				allChildren = buildingthing.GetComponentsInChildren<Transform>();
				foreach(Transform g in allChildren)
				{
					g.transform.rotation = thing.transform.rotation;
					g.gameObject.layer = 8;
				}
				break;
			case 2:
				BuildingCost = 1000;
				Infomation = InfomationLargeGiftShop;
				buildingthing = (GameObject)Instantiate(buildings[17]);
				buildingthing.transform.position = thing.transform.position;
				buildingthing.layer = 8;
				allChildren = buildingthing.GetComponentsInChildren<Transform>();
				foreach(Transform g in allChildren)
				{
					g.transform.rotation = thing.transform.rotation;
					g.gameObject.layer = 8;
				}
				break;
			}
			break;
			#endregion
			
			#region Hotel
		case 3:
			switch (buildingSize) {
			case 0:
				BuildingCost = 500;
				Infomation = InfomationSmallHotel;
				buildingthing = (GameObject)Instantiate(buildings[6]);
				buildingthing.transform.position = thing.transform.position;
				buildingthing.layer = 8;
				allChildren = buildingthing.GetComponentsInChildren<Transform>();
				foreach(Transform g in allChildren)
				{
					g.transform.rotation = thing.transform.rotation;
					g.gameObject.layer = 8;
				}
				break;
			case 1:
				BuildingCost = 800;
				Infomation = InfomationMediumHotel;
				buildingthing = (GameObject)Instantiate(buildings[7]);
				buildingthing.transform.position = thing.transform.position;
				buildingthing.layer = 8;
				allChildren = buildingthing.GetComponentsInChildren<Transform>();
				foreach(Transform g in allChildren)
				{
					g.transform.rotation = thing.transform.rotation;
					g.gameObject.layer = 8;
				}
				break;
			case 2:
				BuildingCost = 1300;
				Infomation = InfomationLargeHotel;
				buildingthing = (GameObject)Instantiate(buildings[8]);
				buildingthing.transform.position = thing.transform.position;
				buildingthing.layer = 8;
				allChildren = buildingthing.GetComponentsInChildren<Transform>();
				foreach(Transform g in allChildren)
				{
					g.transform.rotation = thing.transform.rotation;
					g.gameObject.layer = 8;
				}
				break;
			}
			break;
			#endregion
			
			#region Life guard
		case 4:
			switch (buildingSize) {
			case 0:
				BuildingCost = 100;
				Infomation = InfomationSmallLifeguard;
				buildingthing = (GameObject)Instantiate(buildings[12]);
				buildingthing.transform.position = thing.transform.position;
				buildingthing.layer = 12;
				allChildren = buildingthing.GetComponentsInChildren<Transform>();
				foreach(Transform g in allChildren)
				{
					g.transform.rotation = thing.transform.rotation;
					g.gameObject.layer = 8;
				}
				break;
			case 1:
				BuildingCost = 400;
				Infomation =InfomationMediumLifeguard;
				buildingthing = (GameObject)Instantiate(buildings[13]);
				buildingthing.transform.position = thing.transform.position;
				buildingthing.layer = 8;
				allChildren = buildingthing.GetComponentsInChildren<Transform>();
				foreach(Transform g in allChildren)
				{
					g.transform.rotation = thing.transform.rotation;
					g.gameObject.layer = 8;
				}
				break;
			case 2:
				BuildingCost = 700;
				Infomation = InfomationLargeLifeguard;
				buildingthing = (GameObject)Instantiate(buildings[14]);
				buildingthing.transform.position = thing.transform.position;
				buildingthing.layer = 8;
				allChildren = buildingthing.GetComponentsInChildren<Transform>();
				foreach(Transform g in allChildren)
				{
					g.transform.rotation = thing.transform.rotation;
					g.gameObject.layer = 8;
				}
				break;
			}
			break;
			#endregion
			
			#region Clubs
		case 5:
			switch (buildingSize) {
			case 0:
				BuildingCost = 300;
				Infomation = InfomationSmallClub;
				buildingthing = (GameObject)Instantiate(buildings[0]);
				buildingthing.transform.position = thing.transform.position;
				buildingthing.layer = 8;
				allChildren = buildingthing.GetComponentsInChildren<Transform>();
				foreach(Transform g in allChildren)
				{
					g.transform.rotation = thing.transform.rotation;
					g.gameObject.layer = 8;
				}
				break;
			case 1:
				BuildingCost = 500;
				Infomation = InfomationMediumClub;
				buildingthing = (GameObject)Instantiate(buildings[1]);
				buildingthing.transform.position = thing.transform.position;
				buildingthing.layer = 8;
				allChildren = buildingthing.GetComponentsInChildren<Transform>();
				foreach(Transform g in allChildren)
				{
					g.transform.rotation = thing.transform.rotation;
					g.gameObject.layer = 8;
				}
				break;
			case 2:
				BuildingCost = 700;
				Infomation = InfomationLargeClub;
				buildingthing = (GameObject)Instantiate(buildings[2]);
				buildingthing.transform.position = thing.transform.position;
				buildingthing.layer = 8;
				allChildren = buildingthing.GetComponentsInChildren<Transform>();
				foreach(Transform g in allChildren)
				{
					g.transform.rotation = thing.transform.rotation;
					g.gameObject.layer = 8;
				}
				break;
			}
			break;
			#endregion
			
			#region Fisherie
		case 6:
			switch (buildingSize) {
			case 0:
				BuildingCost = 500;
				Infomation = InfomationSmallFisherie;
				buildingthing = (GameObject)Instantiate(buildings[3]);
				buildingthing.transform.position = thing.transform.position;
				buildingthing.layer = 8;
				allChildren = buildingthing.GetComponentsInChildren<Transform>();
				foreach(Transform g in allChildren)
				{
					g.transform.rotation = thing.transform.rotation;
					g.gameObject.layer = 8;
				}
				break;
			case 1:
				BuildingCost = 1000;
				Infomation = InfomationMediumFisherie;
				buildingthing = (GameObject)Instantiate(buildings[4]);
				buildingthing.transform.position = thing.transform.position;
				buildingthing.layer = 8;
				allChildren = buildingthing.GetComponentsInChildren<Transform>();
				foreach(Transform g in allChildren)
				{
					g.transform.rotation = thing.transform.rotation;
					g.gameObject.layer = 8;
				}
				break;
			case 2:
				BuildingCost = 1500;
				Infomation = InfomationLargeFisherie;
				buildingthing = (GameObject)Instantiate(buildings[5]);
				buildingthing.transform.position = thing.transform.position;
				buildingthing.layer = 8;
				allChildren = buildingthing.GetComponentsInChildren<Transform>();
				foreach(Transform g in allChildren)
				{
					g.transform.rotation = thing.transform.rotation;
					g.gameObject.layer = 8;
				}
				break;
			}
			break;
			#endregion

			#region  Bin
		case 7:
			switch (buildingSize) {
			case 0:
				BuildingCost = 20;
				Infomation = "This recycling bin sits on your beach and allows Litter Pickers to keep the area clean; these are expensive in number but are essential to the beachs survival. The more bins, the less distance a picker has to travel before being able to remove some litter.";

				buildingthing = (GameObject)Instantiate(buildings[18]);
				buildingthing.transform.position = thing.transform.position;
				buildingthing.layer = 8;
				allChildren = buildingthing.GetComponentsInChildren<Transform>();
				foreach(Transform g in allChildren)
				{
					g.transform.rotation = thing.transform.rotation;
					g.gameObject.layer = 8;
				}
				break;
			}
			break;
		case 8:
			switch (buildingSize) {
			case 0:
				BuildingCost = 500;
				Infomation = "Litter Pickers are essential to the beachs welfare. The litter picker can be hired for a short period of time. During this time they will hunt down any trash lying around and put it in the nearest bin, lowering the pollution level. They can be expensive in number but when accommodating large businesses, money should be of little problem.";
//		  		buildingthing = (GameObject)Instantiate(buildings[18]);
//				buildingthing.transform.position = thing.transform.position;
//				buildingthing.layer = 8;
//				allChildren = buildingthing.GetComponentsInChildren<Transform>();
//				foreach(Transform g in allChildren)
//				{
//					g.transform.rotation = thing.transform.rotation;
//					g.gameObject.layer = 8;
//				}
				break;
			}
			break;
			#endregion
		}
	}

	private void WarningWindow (int id){
		GUI.Box (new Rect (0, 0, WarningWindowPostion.width, WarningWindowPostion.height), "");
		GUI.Label (new Rect (WarningWindowPostion.width/2-5, 20, 50, 50), WarningTexture);
		GUI.Label (new Rect (WarningWindowPostion.width/2-65, 80, 150, 50), TheMessage);

		if (GUI.Button (new Rect (WarningWindowPostion.width/2-70, WarningWindowPostion.width/2+15, 140, 30), "OK")) {
			if (GameOver == true){
				Application.LoadLevel(leveltoload);		
			}else{
			ShowWarningWindow = !ShowWarningWindow;
			}
			}

		GUI.DragWindow ();

		}
	Rect CheckBounds (Rect r)
	{
		
		
		r.x = Mathf.Clamp (r.x, 0, Screen.width - r.width);
		r.y = Mathf.Clamp (r.y, 0, Screen.height - r.height);
		return r;
		
		
	}
}