using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class fishControl : MonoBehaviour {
		
	List<GameObject> fish = new List<GameObject>();
	public GameObject fishmodel;
	int pop = 0;
	int pollution = 0;
	void Start () {
	//-2 to -3.5
		for (int i = 0; i<50; i++) {
						float xpos = Random.Range (0, 100);
						float ypos = Random.Range (400, 700);
						ypos *= -0.01f;
						GameObject temp = (GameObject)Instantiate (fishmodel);
						temp.transform.position = new Vector3 (xpos, -2, ypos);
						fish.Add (temp);
				}
		pop = 50;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject[] pol = GameObject.FindGameObjectsWithTag ("Litter");
		pollution = pol.Length;
		pop = 30 - pollution/2;
		if (pop < 0) {
			pop = 0;
				}
		if (fish.Count > pop) {
			Destroy(fish[0],1);
			fish.RemoveAt(0);
		}
		if (fish.Count < pop) {
			float xpos = Random.Range (0, 100);
			float ypos = Random.Range (400, 700);
			ypos *= -0.01f;
			GameObject temp = (GameObject)Instantiate (fishmodel);
			temp.transform.position = new Vector3 (xpos, -2, ypos);
			fish.Add (temp);
						}
		Debug.Log(fish.Count);
	}
}
