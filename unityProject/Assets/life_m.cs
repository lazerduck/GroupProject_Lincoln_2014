﻿using UnityEngine;
using System.Collections;

public class life_m : MonoBehaviour {

	// Use this for initialization
	GameObject np;
	public bool placed = false;
	void Start () {
		np = GameObject.FindGameObjectWithTag ("npccontrol");
	}
	
	// Update is called once per frame
	void Update () {
		if (placed) {
			NPCControl npc = np.GetComponent<NPCControl> ();
			npc.totalNpc += 5;
			placed = false;
			Debug.Log(npc.wait);
		}
	}
	void foo()
	{
		placed = true;
	}
}
