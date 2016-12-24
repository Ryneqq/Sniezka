using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCol : MonoBehaviour {

	public bool flag;
	public GameObject kamerka;

	void Start () 
	{
		flag = false;	
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
            gameObject.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(2.0f, 2.0f);
            // ======================================================== */
        }
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
