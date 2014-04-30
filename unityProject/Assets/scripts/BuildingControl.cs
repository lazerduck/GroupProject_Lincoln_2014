using UnityEngine;
using System.Collections;

public class BuildingControl : MonoBehaviour
{

    // Use this for initialization
    public GameObject[] buildings = new GameObject[19];
	public GameObject Picker;
    GameObject current;
    int type = 0;
    int size = 0;
    bool building = false;
    GameObject build;
    bool deteing = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (building) {
			Debug.Log("building");
						RaycastHit[] hits;
						Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
						hits = Physics.RaycastAll (ray, 100);
						if (!deteing) {
								foreach (RaycastHit hit in hits) {
										if (hit.transform.tag == "Space") {
												build.transform.position = hit.transform.position;
												current = hit.transform.gameObject;
										}
								}
						}
						if (!deteing) {
								if (Input.GetMouseButton (0)) {
										BlockControl blockTemp = current.GetComponent<BlockControl> ();
										if (!blockTemp.BuiltOn) {
												building = false;
												blockTemp.BuiltOn = true;
												blockTemp.size = size;
												blockTemp.type = type;
						build.SendMessage("foo");
										}
								}
						}
				}
            
            if(deteing)
		{
                if (Input.GetMouseButton(0))
                {
				RaycastHit[] hits;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
                    hits = Physics.RaycastAll(ray, 100);
                    foreach (RaycastHit hit in hits)
                    {
					if (hit.transform.tag == "LifeGaurd"||hit.transform.tag == "Fish"||hit.transform.tag == "Club" || hit.transform.tag == "Icecream" || hit.transform.tag == "Hotel" || hit.transform.tag == "Shop" || hit.transform.tag == "TrashCan")
                        {
						Debug.Log(hit.transform.tag);
                            Destroy(hit.transform.gameObject);
                            building = false;
                        }
                    }
                    foreach (RaycastHit hit in hits)
                    {
                        if (hit.transform.tag == "Space")
                        {
                            current = hit.transform.gameObject;
                        }
                    }


                    BlockControl blockTemp = current.GetComponent<BlockControl>();

                    blockTemp.BuiltOn = false;
                    deteing = false;
			}
            
        }
    }
    void Build(int[] input)
    {
        if (input [0] == -1) {
						deteing = true;
		} else if (input [0] == 8) {
			 	Instantiate(Picker);

		}
     	else
        {
            string test = "test " + input[0] + " " + input[1];
            type = input[0] - 1;
            size = input[1];
            building = true;
            Debug.Log(test);
            build = (GameObject)Instantiate(buildings[(type * 3) + size]);
			if(input[0] == 5)
			{
				build.transform.tag = "Club";
			}
			if(input[0] == 6)
			{
				build.transform.tag = "Fish";
			}
        }
    }
}
