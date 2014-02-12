using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour {

	public GameObject CameraObj;
	public GUITexture CursorObj;
	float MouseScroll = 0;
	float MouseAccel = 0.01f;
	float TexWidth = 0.03f;
	float XSpeed = 0.3f;
	void Start () {
		Screen.lockCursor = true;
		TexWidth = (float)CursorObj.texture.width/(float)Screen.width*2;
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
		MouseScroll = Input.GetAxis("Mouse ScrollWheel")*3;
		//mose the camera according to scrolling
		CameraObj.transform.Translate(0,MouseScroll,0);
		//add the cange in mouse pos to the current cursor pos
		CursorObj.transform.position += Pos;
		//keep the mouse on the screen
		//left
		if(CursorObj.transform.position.x <TexWidth)
		{
			CameraObj.transform.Translate(-XSpeed,0,0);
			CursorObj.transform.position = new Vector3(TexWidth,CursorObj.transform.position.y);
		}
		//right
		if(CursorObj.transform.position.x > 1+TexWidth)
		{
			CameraObj.transform.Translate(XSpeed,0,0);
			CursorObj.transform.position = new Vector3(1+TexWidth,CursorObj.transform.position.y);
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
	}
}
