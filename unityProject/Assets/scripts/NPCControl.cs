using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPCControl : MonoBehaviour {

	// Use this for initialization
	public List<GameObject> npcs = new List<GameObject> ();
    public Object[] npc = new Object[11];
	int currNpc = 0;
	int prevNPC = 0;
	public int totalNpc = 20;
	float timer = 0f;
	float waitTime = 1;
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > waitTime) {
			int num = Random.Range(0,11);
			while(num == prevNPC)
			{
				num = Random.Range(0,11);
			}
			prevNPC = num;
			GameObject npcTemp = (GameObject)Instantiate(npc[num]);
			npcs.Add(npcTemp);
			currNpc++;
			timer = 0;
			waitTime = Random.Range(1,10);
		}
		if (currNpc > totalNpc) {
			npcs[0].SendMessage("leave");
			npcs.RemoveAt(0);
			currNpc --;
		}
	}
}
