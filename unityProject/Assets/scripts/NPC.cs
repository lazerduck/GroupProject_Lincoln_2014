using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPC : MonoBehaviour
{
	
	
	public Create_map Map;
	//camera object
	GameObject CameraObj;
	//store the size of the map
	int MapColumns;
	int MapRows;
	//where we want to go
	public Vector3 GoalPos;
	//should we leave
	bool goHome = false;
	//what speed to travel
	float speed = 2;
	//needs
	public float iceCreamNeed = 0;
	public float clubNeed = 0;
	public float giftNeed = 0;
	float LitterNeed = 0;
	
	public bool needing = false;
	bool litter = false;
	float clenlinessNeed = 0;
	float polTollerance;
	float tile_size = 0;
	bool lerp = true;
	public List<GameObject>Tiles;
	void Start()
	{
		CameraObj = GameObject.FindGameObjectWithTag ("theCamera");
		//get the size
		Map = CameraObj.GetComponent<Create_map>();
		Tiles = Map.Tiles;
		MapColumns = Map.Columns;
		MapRows = Map.Rows;
		tile_size = Map.TileSize;
		this.gameObject.transform.position = new Vector3(0, 1, 0);
		calcNextGoal();
		polTollerance = Random.Range (1, 10);
		
		//set the start need values and then count down like an action movie
		iceCreamNeed = Random.Range(5,100);
		clubNeed = Random.Range (40, 100);
		giftNeed = Random.Range (60, 100);
	}
	
	// Update is called once per frame
	void Update()
	{
		//idling
		this.rigidbody.velocity = new Vector3 (0, 0, 0);
		this.transform.LookAt (GoalPos);
		this.transform.position = Vector3.MoveTowards (this.transform.position, GoalPos, speed * Time.deltaTime);
		//this.transform.position = new Vector3 (this.transform.position.x, 1, this.transform.position.z);
		if (goHome && !needing) {
			GoalPos = new Vector3(0,0,4);
		}
		if (!needing) {
			Debug.Log("really");
			if (Vector3.Distance (this.transform.position, GoalPos) < 3) {
				if (goHome) {
					Destroy (this.gameObject);
				}
				calcNextGoal ();
			}
		} else {
			Debug.Log(GoalPos.x);
			if (Vector3.Distance (this.transform.position, GoalPos) < Map.TileSize*2f) {
				Debug.Log("how");
				if(iceCreamNeed<=0)
				{
					needing = false;
					calcNextGoal();
					iceCreamNeed = Random.Range(5,100);
					Debug.Log("test");
				}
				if(clubNeed<=0)
				{
					needing = false;
					calcNextGoal();
					clubNeed = Random.Range(40,100);
					Debug.Log("test3");
				}
				if(giftNeed<=0)
				{
					Debug.Log("test4");
					needing = false;
					calcNextGoal();
					giftNeed = Random.Range(60,100);
				}
			}
		}
		//if they go off the beach
		if (this.transform.position.z < 0)
		{
			this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);
		}
		if (this.transform.position.z > MapRows*Map.TileSize)
		{
			this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, MapRows*Map.TileSize);
		}
		//sort out needs
		if (litter) {
			LitterNeed += Time.deltaTime;
			if(LitterNeed > 10)
			{
				//drop litter
				litter = false;
			}
		}
		//get polution level
		float pollution  = Map.polution/ Map.Columns*Map.Rows;
		if(pollution > polTollerance)
		{
			clenlinessNeed += Time.deltaTime;
		}
		if(clenlinessNeed > 10)
		{
			//leave();
		}
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
		//deal with the needs
		if (!needing) {//if the npc is not needing anything
			iceCreamNeed -= Time.deltaTime;
			clubNeed -= Time.deltaTime;
			giftNeed -= Time.deltaTime;
		}
		//check if any of the need timers have run out
		if (iceCreamNeed < 0) {
			needing = true;
			GameObject[] obj = GameObject.FindGameObjectsWithTag("Icecream");
			float dist = float.MaxValue;
			foreach(GameObject g in obj)
			{
				if(Vector3.Distance(transform.position,g.transform.position)<dist)
				{
					dist = Vector3.Distance(transform.position,g.transform.position);
					GoalPos.x = g.transform.position.x;
					GoalPos.z = g.transform.position.z;
				}
			}

		}
		if (clubNeed < 0) {
			needing = true;
			GameObject[] obj = GameObject.FindGameObjectsWithTag("Club");
			float dist = float.MaxValue;
			foreach(GameObject g in obj)
			{
				if(Vector3.Distance(transform.position,g.transform.position)<dist)
				{
					dist = Vector3.Distance(transform.position,g.transform.position);
					GoalPos.x = g.transform.position.x;
					GoalPos.z = g.transform.position.z;
				}
			}

		}
		if (giftNeed < 0) {
			needing = true;
			GameObject[] obj = GameObject.FindGameObjectsWithTag("Shop");
			float dist = float.MaxValue;
			foreach(GameObject g in obj)
			{
				if(Vector3.Distance(transform.position,g.transform.position)<dist)
				{
					dist = Vector3.Distance(transform.position,g.transform.position);
					GoalPos.x = g.transform.position.x;
					GoalPos.z = g.transform.position.z;
				}
			}

		}
		
	}
	void calcNextGoal()
	{
	Start:
			GoalPos.x = Random.Range(0, MapColumns);
		GoalPos.z = Random.Range(0, MapRows);
		int place = (int)(GoalPos.z * MapColumns + GoalPos.x);
		BlockControl blocktemp = Tiles [place].GetComponent<BlockControl> ();
		if (blocktemp.BuiltOn) {
			//hope no one sees this goto 0_0, its a bit lazy, but i am using labels and its all nicely contained in the same function so it should be fine
			goto Start;
		}
		GoalPos.y = 2;
		GoalPos.x *= tile_size;
		GoalPos.z *= tile_size;
		speed = (float)(Random.Range (10, 30)/10f);
	}
	void leave()
	{
		goHome = true;
	}
}
