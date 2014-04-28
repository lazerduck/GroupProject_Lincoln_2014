using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Picker : MonoBehaviour {

	public Create_map Map;
	//camera object
	GameObject CameraObj;
	//store the size of the map
	int MapColumns;
	int MapRows;
	//tiles
	public List<GameObject>Tiles;
	//trash held
	int TrashCount = 0;
	bool lerp = true;
	public Vector3 GoalPos;
	float speed = 1;
	GameObject litter;
	float tile_size = 0;
	bool picking = false;

	void Start () {

		CameraObj = GameObject.FindGameObjectWithTag ("theCamera");
		//get the size
		Map = CameraObj.GetComponent<Create_map>();
		Tiles = Map.Tiles;
		MapColumns = Map.Columns;
		MapRows = Map.Rows;
		tile_size = Map.TileSize;
		this.gameObject.transform.position = new Vector3(0, 1, 0);
		CalcPos();
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.LookAt (GoalPos);
		this.transform.position = Vector3.MoveTowards (this.transform.position, GoalPos, speed * Time.deltaTime);
		//bobbing
		if (lerp) {
			this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(this.transform.position.x,2,this.transform.position.z),0.005f);
			if(this.transform.position.y > 1.2f)
			{
				lerp  = false;
			}
		}
		else {
			this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(this.transform.position.x,0,this.transform.position.z),0.005f);
			if(this.transform.position.y < 1.1f)
			{
				lerp  = true;
			}
		}
		//moving

		//arriving
		if (Vector3.Distance (this.transform.position, GoalPos) < 3) {
			if(picking)
			{
			Destroy(litter);
			}
			CalcPos();
		}
	}
	void CalcPos()
	{
		GameObject[] temp = GameObject.FindGameObjectsWithTag("Litter");
		float dist = float.MaxValue;
		if (temp.Length >0)
		{
			picking = true;
		foreach(GameObject G in temp)
		{
			float distance = Vector3.Distance(this.transform.position,G.transform.position);
			if(distance < dist)
			{
				dist = distance;
				litter = G;
				GoalPos = litter.transform.position;
			}
		}
		}else{
			picking = false;
		
				GoalPos.x = Random.Range(0, MapColumns);
			GoalPos.z = Random.Range(0, MapRows);
			int place = (int)(GoalPos.z * MapColumns + GoalPos.x);

			GoalPos.y = 2;
			GoalPos.x *= tile_size;
			GoalPos.z *= tile_size;
		}
	}
}
