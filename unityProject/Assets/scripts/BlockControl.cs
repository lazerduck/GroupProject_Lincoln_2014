using UnityEngine;
using System.Collections;

public class BlockControl : MonoBehaviour {

	public float PollutionLevel;
	bool BuiltOn;
	public Material Tex1;
	public Material Tex2;
	void Start () {
		PollutionLevel = 0;
		BuiltOn = false;
	}
	
	// Update is called once per frame
	void Update () {
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
		PollutionLevel += 0.0001f;
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
