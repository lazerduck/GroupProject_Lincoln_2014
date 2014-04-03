using UnityEngine;
using System.Collections;

public class NPCControl : MonoBehaviour {

	// Use this for initialization
    public Queue npcs;
    public Object npc;
	void Start () {

            for (int x = 0; x < 20; x++)
            {
                GameObject cube = (GameObject)GameObject.Instantiate(npc);
                //npcs.Enqueue(cube);
            }
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
