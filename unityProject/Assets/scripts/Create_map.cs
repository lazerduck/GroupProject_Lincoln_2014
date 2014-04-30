using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Create_map : MonoBehaviour {
	
	public GameObject Tile;
	public static int temp_cols;
	public int Rows;
	public int Columns;
	public float TileSize;
	public List<GameObject>Tiles = new List<GameObject> ();
	public float polution = 0;
	
	void Start () {
		TileSize = 5;
		Rows = 6;
		if (temp_cols != 0) {
						Columns = temp_cols;
				} else {
			Columns = 33;
				}
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
				TempTile.transform.localScale = new Vector3(TileSize,0.1f,TileSize);
				//add it to our array for easy access
				Tiles.Add(TempTile);
			}
		}
		
	}
	
	
	void Update () {
		polution = 0;
//		foreach (GameObject t in Tiles) {
//			BlockControl temp = t.GetComponent<BlockControl>();
//			polution += temp.PollutionLevel;
//		}
		GameObject[] litter = GameObject.FindGameObjectsWithTag("Litter");
		foreach(GameObject L in litter)
		{
			++polution;
		}
	}
}
