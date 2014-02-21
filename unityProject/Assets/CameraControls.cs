using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraControls : MonoBehaviour {
	//camera object
	public GameObject CameraObj;
	//gui object
	public GUITexture GuiObject;
	//mouse texture
	public GUITexture CursorObj;
	//building test
	public GameObject Building;
	//building placer
	public List<GameObject> BuildPlace = new List<GameObject>();
	//mouse variables
	float MouseScroll = 0;
	float MouseAccel = 0.01f;
	//width of the texture
	float TexWidth = 0.03f;
	//speed scrolling in x
	float XSpeed = 0.3f;
	//margin for scrolling
	float Margin = 0.01f;
	//has the button been clicked
	bool Clicked;
	//columns imported from create map
	public int Columns = 0;
	//size of tiles
	public float Size;
	//distance the end of the map is from the center
	float Spacer = 3;
	//instance of the create map
	Create_map Map;
	Vector3 MouseClick;
	void Start () {
		Clicked = false;
		Map = CameraObj.GetComponent<Create_map>();
		Columns = Map.Columns;
		Size = Map.TileSize;
		Margin = 0.01f;
		Screen.lockCursor = true;
		TexWidth = (float)CursorObj.texture.width/(float)Screen.width*2;
		CameraObj.transform.Translate((float)(Columns/2)*(Size),0,0);
		CursorObj.transform.position = new Vector3(CursorObj.transform.position.x,CursorObj.transform.position.y,5);
	}
	
	// Update is called once per frame
	void Update () {
		//Get the mouse position change
		float h = Input.GetAxis("Mouse Y");
		float v = Input.GetAxis("Mouse X");
		//calculate the aspect ratio
		float aspect = Screen.width/Screen.height;
		//stor the mouse change as a vector3 and include mouse accelleration
		Vector3 Pos = new Vector3(MouseAccel*v,MouseAccel*h*aspect,0);
		//get the amount scrolled
		MouseScroll = -Input.GetAxis("Mouse ScrollWheel")*3;
		//mose the camera according to scrolling
		if(CameraObj.transform.position.y+MouseScroll > 1 && CameraObj.transform.position.y+MouseScroll < 10)
		{
			CameraObj.transform.Translate(0,MouseScroll,-MouseScroll);
		}
		//add the cange in mouse pos to the current cursor pos
		CursorObj.transform.position += Pos;
		//keep the mouse on the screen
		//left
		if(CursorObj.transform.position.x <TexWidth)
		{

			CursorObj.transform.position = new Vector3(TexWidth,CursorObj.transform.position.y);
		}
		if(CursorObj.transform.position.x <TexWidth+ Margin)
		{
			if(CameraObj.transform.position.x > 0+Spacer)
			{
				CameraObj.transform.Translate(-XSpeed,0,0);
			}
		}
		//right
		if(CursorObj.transform.position.x > 1+TexWidth)
		{
			CursorObj.transform.position = new Vector3(1+TexWidth,CursorObj.transform.position.y);
		}
		if(CursorObj.transform.position.x > 1+TexWidth - Margin)
		{
			if(CameraObj.transform.position.x < Columns*Size - Spacer)
			{
				CameraObj.transform.Translate(XSpeed,0,0);
			}
		}
		//top
		if(CursorObj.transform.position.y <TexWidth)
		{

			CursorObj.transform.position = new Vector3(CursorObj.transform.position.x,TexWidth);
		}
		//bottom
		if(CursorObj.transform.position.y >1+TexWidth)
		{
			
			CursorObj.transform.position = new Vector3(CursorObj.transform.position.x,1+TexWidth);
		}
		//ready to place building
		if(Clicked)
		{
			Vector3 mousepos = CursorObj.transform.position;
			mousepos.x -= TexWidth;
			RaycastHit hit = new RaycastHit();
			Ray ray = Camera.main.ViewportPointToRay(mousepos);
			
			if (Physics.Raycast (ray,out hit,100f)){
				BuildPlace[BuildPlace.Count-1].transform.position = hit.transform.position;

			}
		}
		//Clicking
		if(Input.GetMouseButtonDown(0))
		{

			Vector2 MousePosition = Camera.main.ViewportToScreenPoint(CursorObj.transform.position);
			if(Clicked)
			{
				Vector3 mousepos = CursorObj.transform.position;
				mousepos.x -= TexWidth;
				Ray ray = Camera.main.ViewportPointToRay(mousepos);
				RaycastHit []hit = Physics.RaycastAll(ray);
				for(int i = 0; i<hit.Length;i++)
				{
					if(hit[i].transform.tag == "Space")
					{
						Clicked = false;
						hit[i].transform.gameObject.SendMessage("mousepos",true);
						Debug.Log("found Place");
					}
				}
			}
			else
			{
			if(ClickTest(GuiObject,MousePosition))
			{
				Clicked = true;
				Debug.Log("clicked");
				BuildPlace.Add((GameObject)Instantiate(Building));
			}
			else
			{
				Vector3 mousepos = CursorObj.transform.position;
				mousepos.x -= TexWidth;
				RaycastHit hit = new RaycastHit();
				Ray ray = Camera.main.ViewportPointToRay(mousepos);

				if (Physics.Raycast (ray,out hit,100f)){
					hit.transform.gameObject.SendMessage("IncreasePollution",0.1f);
				}
			}
			}
		}
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
