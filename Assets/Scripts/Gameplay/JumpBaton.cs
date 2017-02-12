using System.Collections;
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
			kulka.GetComponent<Rigidbody2D> ().velocity = new Vector2 (kulka.GetComponent<Rigidbody2D> ().velocity.x, (kulka.GetComponent<Rigidbody2D> ().velocity.y)/2 + jump);
			kulka.GetComponent<DetectCol> ().DeSetFlag ();
		}
        jump = 6;
		
	}
    public void Clicked()
    {
        if (!Variables.gameOver)
            pressed = true;
        else
            Application.LoadLevel("MainMenu");
    }

    public void Released()
    {
        pressed = false;
        jump = jump * time + 5.0f;
        time = 0.0f;
        Dzamp();
    }

}
