using UnityEngine;
using System.Collections;

public class BuildingControl : MonoBehaviour {

	// Use this for initialization
	public GameObject[] buildings = new GameObject[18];
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	void Build(int[] input)
	{
		string test = "test " + input [0] + " " + input [1];
		Debug.Log (test);
	}
}
