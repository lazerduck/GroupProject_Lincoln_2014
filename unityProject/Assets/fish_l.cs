using UnityEngine;
using System.Collections;

public class fish_l : MonoBehaviour {

	public bool placed = false;
	public GameObject cam;
	public float timer_money = 0;
	public float litter_timer = 0;
	void Start () {
		cam = GameObject.Find ("Camera");
	}
	
	// Update is called once per frame
	void Update () {
		if (placed) {
			timer_money += Time.deltaTime;
			litter_timer += Time.deltaTime;
			if(timer_money > 10)
			{
				timer_money = 0;
				cam.SendMessage("AddMoney",8);
				//make litter
			}
		}
	}
	void foo()
	{
		placed = true;
	}
}