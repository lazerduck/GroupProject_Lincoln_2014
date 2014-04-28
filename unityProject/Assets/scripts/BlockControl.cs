using UnityEngine;
using System.Collections;

public class BlockControl : MonoBehaviour {

	public float PollutionLevel;
	public bool BuiltOn;
	public int type;
	public int size;
	public bool pier;
	public Material Tex1;
	public Material Tex2;
	void Start () {
		PollutionLevel = 0;
		BuiltOn = false;
	}
	
	// Update is called once per frame
	void Update () {
		PollutionLevel = 0;
		if(BuiltOn)
		{
			PollutionLevel = 0;
		}
		if(PollutionLevel < 1)
		{
			this.gameObject.renderer.material = Tex1;
		}
		else
		{
			this.gameObject.renderer.material = Tex2;
		}
		Rect hit = new Rect(this.transform.position.x-0.5f,this.transform.position.y-0.5f,1f,1f);
		//find all the litter

	}
	void mousepos(bool state)
	{
		BuiltOn = true;
	}
	void IncreasePollution(float Increase)
	{
		PollutionLevel += Increase;
	}
}
