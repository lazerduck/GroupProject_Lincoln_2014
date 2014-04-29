using UnityEngine;
using System.Collections;

public class WaterPollution : MonoBehaviour {
	
	public float smooth = 2;
	private Color newWaterColor;
	private GameObject water;
	void Start () {
		water = GameObject.FindWithTag("Water");
		newWaterColor = water.renderer.material.GetColor("_horizonColor");
	}
	
	void Update () {
		ColorChanging();
	}
	
	void ColorChanging(){
		GameObject[] temp;
		temp= GameObject.FindGameObjectsWithTag("Litter");
		Color waterColorBlack = new Color(0.0f,temp.Length/10f,0.0f,1.0f);
		newWaterColor = waterColorBlack;
		water.renderer.material.SetColor("_horizonColor", Color.Lerp(water.renderer.material.GetColor("_horizonColor"), newWaterColor, Time.deltaTime * smooth));
	}
	
	
	
}