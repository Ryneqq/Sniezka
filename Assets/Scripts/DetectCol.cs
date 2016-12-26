using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCol : MonoBehaviour {

	public bool flag;
	public GameObject kamerka;
    private Vector3 scale;
    private float deltaRise, deltaFall;

	void Start () 
	{
		flag = false;
        deltaRise = 1.004f; deltaFall = 0.9f;
        scale = gameObject.GetComponent<SpriteRenderer>().transform.localScale;

    }

	void OnCollisionEnter2D (Collision2D col)
	{
		flag = true;
		if(col.gameObject.CompareTag("kamien"))
		{
			kamerka.GetComponent<CamerControl> ().Impact ();
            //* ======================== rynek ======================== 
            col.gameObject.GetComponent<PolygonCollider2D>().enabled = false; //usun kolizje
            col.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None; //wylacz freeza
            scale = gameObject.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(scale.x * deltaFall, scale.y * deltaFall);
            // ======================================================== */
        }
    }
    void OnCollisionStay2D (Collision2D col)
    {
        //* ======================== rynek ======================== 
        if (col.gameObject.CompareTag("snieg"))
        {
            scale = gameObject.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(scale.x * deltaRise, scale.y * deltaRise);
        }
        // ======================================================== */
    }

    public void DeSetFlag()
	{
		flag = false;
	}
	/*
	void OnCollisionExit2D (Collision2D col)
	{	
		flag = false;
		Debug.Log (flag);
	}	
	*/
}
