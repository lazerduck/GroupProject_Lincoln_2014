using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraControls : MonoBehaviour
{
	//camera object
	public GameObject CameraObj;
	//gui object
	public GUITexture GuiObject;
    //camera look at
    public GameObject camref;
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
	float dist = 0;
	float old_dist = 0;
	Vector3 MouseClick;
	void Start()
	{
        camref = GameObject.FindGameObjectWithTag("camref");
		Map = this.GetComponent<Create_map>();
		Columns = Map.Columns;
		Size = Map.TileSize;;
		CameraObj.transform.Translate((float)(Columns / 2) * (Size), 0, 0);
		Screen.orientation = ScreenOrientation.AutoRotation;
	}
	
	// Update is called once per frame
	void Update()
	{
        camref.transform.position = new Vector3(transform.position.x, 0, camref.transform.position.z);
        this.transform.LookAt(camref.transform.position);
		//Mouse controls
		float scrollWheel = Input.GetAxis ("Mouse ScrollWheel");
		scrollWheel = -scrollWheel*4;
		if (scrollWheel < 0 && CameraObj.transform.position.y < 1) {
			scrollWheel = 0;
		}
		if (scrollWheel >0 && CameraObj.transform.position.y > 10) {
			scrollWheel = 0;
		}
		CameraObj.transform.Translate(new Vector3(0, 0.4f*scrollWheel, 0));//-0.6f*scrollWheel));
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
				CameraObj.transform.Translate(new Vector3(0, -0.2f, 0));
			}
		}
		if (Input.GetKey(KeyCode.DownArrow)|| Input.GetKey(KeyCode.S))
		{
			if(CameraObj.transform.position.y < 10)
			{
				CameraObj.transform.Translate(new Vector3(0, 0.2f, 0));
			}
		}
		//get polution level
		Create_map tempMap = this.gameObject.GetComponent<Create_map>();
		//Debug.Log (tempMap.polution);
		if (Input.touchCount == 2) {
			Touch t0 = Input.GetTouch(0);
			Touch t1 = Input.GetTouch(1);
			Vector2 t0prev = t0.position - t0.deltaPosition;
			Vector2 t1prev = t1.position - t1.deltaPosition;
			float prevtouchmag = (t0prev - t1prev).magnitude;
			float touchmag = (t0.position - t1.position).magnitude;
			float diff = (prevtouchmag - touchmag);

//			if (diff < 0 && CameraObj.transform.position.y < 1) {
//				diff = 0;
//			}
//			if (diff >0 && CameraObj.transform.position.y > 10) {
//				diff = 0;
//			}
			CameraObj.transform.Translate(new Vector3(0, 0.4f*diff, -0.6f*diff));
		} else
		if (Input.touchCount == 1) {
						Touch t0 = Input.GetTouch (0);
						float t0prev = t0.position.x - t0.deltaPosition.x;
			if(t0prev>10)
			{
				t0prev = 10;
			}
			if(t0prev<-10)
			{
				t0prev = -10;
			}
						this.transform.position = new Vector3(transform.position.x -t0prev,transform.position.y,transform.position.z);
		}else {
			dist = 0;
			old_dist = 0;
		}
	}	
}
