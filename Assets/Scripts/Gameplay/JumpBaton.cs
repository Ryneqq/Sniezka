﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBaton : MonoBehaviour {


	public GameObject kulka;
	private float jump, time;
	private bool flag, pressed;


	void Start () 
	{
        pressed = false;
		jump = 6;		
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (pressed)
        {
            Debug.Log("Clicked");
            time += Time.deltaTime;
            if (time >= 1.0f)
            {
                time = 1.0f;
            }
        }
	}

	public void Dzamp()
	{	
		if (kulka.GetComponent<DetectCol> ().flag) 
		{
			kulka.GetComponent<Rigidbody2D> ().velocity = new Vector2 (kulka.GetComponent<Rigidbody2D> ().velocity.x, kulka.GetComponent<Rigidbody2D> ().velocity.y + jump);
			kulka.GetComponent<DetectCol> ().DeSetFlag ();
		}
        jump = 6;
		
	}
    public void Clicked()
    {
        pressed = true;
    }

    public void Released()
    {
        Debug.Log("Released");
        pressed = false;
        jump = jump * time + 5.0f;
        time = 0.0f;
        Dzamp();
    }

}