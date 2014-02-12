using UnityEngine;
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
				Vector3 Pos = new Vector3(j*TileSize,0,i*TileSize)*ScrollAccel;
				GameObject TempTile = (GameObject)Instantiate(Tile);
				TempTile.transform.Translate(Pos);
				Tiles[i*j + j] = TempTile;
			}
		}
	}


	void Update () {
	
	}
}
