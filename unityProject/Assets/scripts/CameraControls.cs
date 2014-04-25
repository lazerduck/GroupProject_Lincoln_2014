using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraControls : MonoBehaviour
{
	//camera object
	public GameObject CameraObj;
	//gui object
	public GUITexture GuiObject;
	//building test
	public GameObject Building;
	//building placer
	public List<GameObject> BuildPlace = new List<GameObject>();
	//speed scrolling in x
	float XSpeed = 0.3f;
	//columns imported from create map
	public int Columns = 0;
	//size of tiles
	public float Size;
	//instance of the create map
	Create_map Map;
	Vector3 MouseClick;
	void Start()
	{
		
		Map = this.GetComponent<Create_map>();
		Columns = Map.Columns;
		Size = Map.TileSize;;
		CameraObj.transform.Translate((float)(Columns / 2) * (Size), 0, 0);
		Screen.orientation = ScreenOrientation.AutoRotation;
	}
	
	// Update is called once per frame
	void Update()
	{
		//Movement//
		/*on pc we can use the arrows to move and zoom
         *as well as some mouse control
         *on mobile we will need sliders
         *or perhaps swiping
         */
		//calculate the aspect ratio
		//Mouse controls
		float scrollWheel = Input.GetAxis ("Mouse ScrollWheel");
		scrollWheel = -scrollWheel*4;
		if (scrollWheel < 0 && CameraObj.transform.position.y < 1) {
			scrollWheel = 0;
		}
		if (scrollWheel >0 && CameraObj.transform.position.y > 10) {
			scrollWheel = 0;
		}
		CameraObj.transform.Translate(new Vector3(0, 0.4f*scrollWheel, -0.6f*scrollWheel));
		//keyboard controls
		if (Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.A))
		{
			if(CameraObj.transform.position.x >3)
			{
				CameraObj.transform.Translate(new Vector3(-XSpeed, 0, 0));
			}
		}
		if (Input.GetKey(KeyCode.RightArrow)|| Input.GetKey(KeyCode.D))
		{
			if(CameraObj.transform.position.x < Map.Columns*Map.TileSize -3)
			{
				CameraObj.transform.Translate(new Vector3(XSpeed, 0, 0));
			}
		}
		if (Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.W))
		{
			if(CameraObj.transform.position.y > 1)
			{
				CameraObj.transform.Translate(new Vector3(0, -0.2f, 0.3f));
			}
		}
		if (Input.GetKey(KeyCode.DownArrow)|| Input.GetKey(KeyCode.S))
		{
			if(CameraObj.transform.position.y < 10)
			{
				CameraObj.transform.Translate(new Vector3(0, 0.2f, -0.3f));
			}
		}
		float aspect = Screen.width / Screen.height;
		//get polution level
		Create_map tempMap = this.gameObject.GetComponent<Create_map>();
		//Debug.Log (tempMap.polution);
	}
	
	private bool ClickTest(GUITexture Button, Vector2 MousePos)
	{
		if(Button.HitTest(MousePos))
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	
}
