﻿using UnityEngine;
using System.Collections;

public class Create_map : MonoBehaviour {

	public GameObject Tile;
	public static int Rows = 5;
	public static int Columns = 10;
	public float TileSize = 1.5f;
	public float ScrollAccel = 1.5f;
	GameObject [] Tiles = new GameObject[Rows*Columns];

	void Start () {
		for(int i = 0; i<Rows;i++)
		{
			for(int j = 0; j<Columns;j++)
			{
				//create a position for the tile
				Vector3 Pos = new Vector3(j*TileSize,0,i*TileSize);
				//make a new game object from a prefab
				GameObject TempTile = (GameObject)Instantiate(Tile);
				//move it to the predetermined position
				TempTile.transform.Translate(Pos);
				//add it to our array for easy access
				Tiles[i*j + j] = TempTile;
			}
		}
	}


	void Update () {
	
	}
}
