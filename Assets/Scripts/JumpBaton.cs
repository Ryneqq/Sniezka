using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBaton : MonoBehaviour {


	public GameObject kulka;
	private float jump;
	private bool flag;

	void Start () 
	{
		jump = 10;		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void Dzamp()
	{	
		if (kulka.GetComponent<DetectCol> ().flag) 
		{
			kulka.GetComponent<Rigidbody2D> ().velocity = new Vector2 (kulka.GetComponent<Rigidbody2D> ().velocity.x, kulka.GetComponent<Rigidbody2D> ().velocity.y + jump);
			kulka.GetComponent<DetectCol> ().DeSetFlag ();
		}
		
	}

}
