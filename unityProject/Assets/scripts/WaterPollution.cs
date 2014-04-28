using UnityEngine;
using System.Collections;

public class WaterPollution : MonoBehaviour {

	private GameObject water;
	private Color newWaterColor;
	public float smooth = 2;
	// Use this for initialization
	void Start () {
		water = GameObject.FindWithTag("Water");
		newWaterColor = water.renderer.material.GetColor("_horizonColor");
	}

	void Update () {
		ColorChanging();

			//this.renderer.material.SetColor = new Color(0,225,0);
			
			//http://answers.unity3d.com/questions/230315/change-water-color-through-script-when-an-action-o.html
		}


	void ColorChanging(){
		Color waterColorBlack = new Color(0.0f,0.0f,0.0f,1.0f);
		Color waterColorGrey = new Color(0.145f,0.165f,0.18f,1.0f);         
		//if(/*Something happens*/){
			newWaterColor = waterColorBlack;
		//}
	//	if(/*Something else happens*/){
		//	newWaterColor = waterColorGrey;
		//}         
		
		water.renderer.material.SetColor("_horizonColor", Color.Lerp(water.renderer.material.GetColor("_horizonColor"), newWaterColor, Time.deltaTime * smooth));
	}
}
