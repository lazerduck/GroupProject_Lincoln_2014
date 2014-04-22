using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour
{


    public Create_map Map;
    //camera object
    public GameObject CameraObj;
    //store the size of the map
    int MapColumns;
    int MapRows;
    //where we want to go
    Vector3 GoalPos;
	//should we leave
	bool goHome = false;
	//what speed to travel
	float speed = 2;
	//needs
	float foodNeed = 0;
	float LitterNeed = 0;
	bool litter = false;
	float clenlinessNeed = 0;
	float polTollerance;
    void Start()
    {
        //get the size
        Map = CameraObj.GetComponent<Create_map>();
        MapColumns = Map.Columns;
        MapRows = Map.Rows;
        this.gameObject.transform.position = new Vector3(0, 1, 0);
        calcNextGoal();
		polTollerance = Random.Range (1, 10);
    }

    // Update is called once per frame
    void Update()
    {
		//idling
			this.rigidbody.velocity = new Vector3 (0, 0, 0);
		this.transform.LookAt (GoalPos);
			this.transform.position = Vector3.MoveTowards (this.transform.position, GoalPos, speed * Time.deltaTime);
			this.transform.position = new Vector3 (this.transform.position.x, 1, this.transform.position.z);
		if (goHome) {
			GoalPos = new Vector3(0,0,4);
		}
        if(Vector3.Distance(this.transform.position, GoalPos) < 3)
        {
			if(goHome)
			{
				Destroy(this.gameObject);
			}
            calcNextGoal();
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
		foodNeed += Time.deltaTime / 10;
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
			leave();
		}
    }
    void calcNextGoal()
    {
        GoalPos.x = Random.Range(0, MapColumns);
        GoalPos.z = Random.Range(0, MapRows);
        GoalPos.y = 1;
		speed = (float)(Random.Range (10, 30)/10f);
    }
	void leave()
	{
		goHome = true;
	}
}
