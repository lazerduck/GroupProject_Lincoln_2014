using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour
{


    Create_map Map;
    //camera object
    public GameObject CameraObj;
    //store the size of the map
    int MapColumns;
    int MapRows;
    //where we want to go
    Vector3 GoalPos;

    void Start()
    {
        //get the size
        Map = CameraObj.GetComponent<Create_map>();
        MapColumns = Map.Columns;
        MapRows = Map.Rows;
        this.gameObject.transform.position = new Vector3(0, 1, 0);
        calcNextGoal();
    }

    // Update is called once per frame
    void Update()
    {
        this.rigidbody.velocity = new Vector3(0, 0, 0);
        this.transform.position = Vector3.MoveTowards(this.transform.position, GoalPos, 2 * Time.deltaTime);
        this.transform.position = new Vector3(this.transform.position.x, 1, this.transform.position.z);
        if(Vector3.Distance(this.transform.position, GoalPos) < 3)
        {
            calcNextGoal();
        }
    }
    void calcNextGoal()
    {
        GoalPos.x = Random.Range(0, MapColumns);
        GoalPos.z = Random.Range(0, MapRows);
        GoalPos.y = 1;
        Debug.Log("goal");
        Debug.Log(GoalPos);
    }
}
