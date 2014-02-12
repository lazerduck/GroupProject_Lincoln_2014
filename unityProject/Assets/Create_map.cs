using UnityEngine;
using System.Collections;

public class Create_map : MonoBehaviour {

	public GameObject Tile;
	public int Rows = 7;
	public int Columns = 100;
	public float TileSize;
	GameObject [] Tiles;


	void Start () {
		Tiles = new GameObject[Rows*Columns];
		TileSize = 1.1f;
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
