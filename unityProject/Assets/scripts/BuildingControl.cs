using UnityEngine;
using System.Collections;

public class BuildingControl : MonoBehaviour {

	// Use this for initialization
	public GameObject[] buildings = new GameObject[18];
	GameObject current;
	int type = 0;
	int size = 0;
	bool building = false;
	GameObject build;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (building) 
		{
		RaycastHit[] hits;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		hits = Physics.RaycastAll (ray, 100);
		foreach (RaycastHit hit in hits) {
			if (hit.transform.tag == "Space") {
				build.transform.position = hit.transform.position;
					current = hit.transform.gameObject;
			}
		}
		if (Input.GetMouseButton (0)) {
				BlockControl blockTemp = current.GetComponent<BlockControl>();
				if(!blockTemp.BuiltOn)
				{
					building = false;
					blockTemp.BuiltOn = true;
					blockTemp.size = size;
					blockTemp.type = type;
				}
			}
		}
	}
	void Build(int[] input)
	{
		string test = "test " + input [0] + " " + input [1];
		type = input [0] - 1;
		size = input [1];
		building = true;
		Debug.Log (test);
		build = (GameObject)Instantiate (buildings [(type*3)+size]);
	}
}
