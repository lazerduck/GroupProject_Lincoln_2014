using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour {

	public GameObject CameraObj;
	public GUITexture CursorObj;
	float MouseScroll = 0;
	float MouseAccel = 0.01f;
	void Start () {
		Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis("Mouse Y");
		float v = Input.GetAxis("Mouse X");
		Vector3 Pos = new Vector3(MouseAccel*v,MouseAccel*h,0);
		MouseScroll = Input.GetAxis("Mouse ScrollWheel");
		CameraObj.transform.Translate(0,MouseScroll,0);
		CursorObj.transform.position += Pos;
		while(CursorObj.transform.position.x < 25)
		{
			CursorObj.transform.position = new Vector3(0,CursorObj.transform.position.y);
		}
	}
}
