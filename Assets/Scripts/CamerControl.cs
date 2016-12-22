using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerControl : MonoBehaviour {

	public GameObject kulka;
	private float offset_x;
	private float offset_y;
	private float impact_x;
	private float impact_y;
	private bool startimpact;


	void Start () 
	{
		offset_x = 4;
		offset_y = 1;
		impact_x = 0;
		impact_y = 0;
		startimpact = false;
		transform.position = new Vector3(kulka.transform.position.x + offset_x, kulka.transform.position.y + offset_y, -10);
	}

	void Update () 
	{
		if(startimpact)
		{
			impact_x = Random.Range (-0.2f, 0.2f);
			impact_y = Random.Range (-0.2f, 0.2f);
		}
		else
		{
			impact_y = 0;
			impact_x = 0;
		}

		offset_x += impact_x;
		offset_y += impact_y;

		transform.position = new Vector3(kulka.transform.position.x + offset_x , kulka.transform.position.y + offset_y, -10);
	}

	public void Impact()
	{
		startimpact = true;
	}


}
