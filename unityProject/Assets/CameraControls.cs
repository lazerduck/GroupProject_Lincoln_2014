﻿using UnityEngine;
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
    void Start()
    {
        Clicked = false;
        Map = CameraObj.GetComponent<Create_map>();
        Columns = Map.Columns;
        Size = Map.TileSize;
        Margin = 0.01f;
        CameraObj.transform.Translate((float)(Columns / 2) * (Size), 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        //Movement//
        /*on pc we can use the arrows to move and zoom
         *as well as some mouse control
         *on mobile we will need sliders 
         */
        //calculate the aspect ratio
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("pressed");
            CameraObj.transform.Translate(new Vector3(-XSpeed, 0, 0));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("pressed");
            CameraObj.transform.Translate(new Vector3(XSpeed, 0, 0));
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("pressed");
            CameraObj.transform.Translate(new Vector3(0, 0.2f, -0.3f));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("pressed");
            CameraObj.transform.Translate(new Vector3(0, -0.2f, 0.3f));
        }
        float aspect = Screen.width / Screen.height;
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
