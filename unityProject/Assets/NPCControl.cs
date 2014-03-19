using UnityEngine;
using System.Collections;

public class NPCControl : MonoBehaviour {

	// Use this for initialization
    public GameObject npc;
	void Start () {

            for (int x = 0; x < 100; x++)
            {
                GameObject cube = (GameObject)Instantiate(npc);
            }
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
