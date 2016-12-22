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
		Debug.Log (flag);
		if(col.gameObject.CompareTag("kamien"))
		{
			kamerka.GetComponent<CamerControl> ().Impact ();
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
