using UnityEngine;
using System.Collections;

public class hotel_l : MonoBehaviour {

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
			npc.wait *= 0.6f;
			placed = false;
		}
	}
	void foo()
	{
		placed = true;
	}
}
