using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerControl : MonoBehaviour {

	public GameObject kulka;
    private Vector3 startPos;
    private Vector3 offset;
    private Vector2 impact;
	private bool startimpact;
    private float time = 0.0f;


	void Start () 
	{
		offset.x = startPos.x = 6;
		offset.y = startPos.y = 0;
        offset.z = startPos.z = -15;
		impact.x = 0;
		impact.y = 0;
		startimpact = false;
		transform.position = new Vector3(kulka.transform.position.x + offset.x, kulka.transform.position.y + offset.y, offset.z);
	}

	void Update () 
	{
		if(startimpact)
		{
			impact.x = Random.Range (-0.2f, 0.2f);
			impact.y = Random.Range (-0.2f, 0.2f);
            time += Time.deltaTime;
		}
		else
		{
			impact.x = 0;
			impact.y = 0;
		}
        //* === rynek === 
        if (time > 1.0f)
        {
            startimpact = false;
            impact.x = 0; offset.x = startPos.x;
            impact.y = 0; offset.y = startPos.y;
            time = 0.0f;
        }
        // ============= */

		offset.x += impact.x;
		offset.y += impact.y;
        transform.position = new Vector3(kulka.transform.position.x + offset.x, kulka.transform.position.y + offset.y, offset.z);
    }

	public void Impact()
	{
		startimpact = true;
	}


}
