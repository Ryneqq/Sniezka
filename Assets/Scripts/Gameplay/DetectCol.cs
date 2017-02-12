using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCol : MonoBehaviour {

	public bool flag;
	public GameObject kamerka;
    private Vector3 scale, velocity;
    private float deltaRise, deltaFall, dupa;
    private bool done = false;

	void Start () 
	{
		flag = false;
        deltaRise = 1.005f; deltaFall = 0.60f;
        scale = gameObject.GetComponent<SpriteRenderer>().transform.localScale;
        velocity = gameObject.GetComponent<Rigidbody2D>().velocity;

    }
    public void DecreaseDeltaFall(float delta)
    {
        deltaFall -= delta;
    }
    public void IncreaseDeltaRise(float delta)
    {
        deltaRise += delta;
    }

	void OnCollisionEnter2D (Collision2D col)
	{
		flag = true;
        velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        if (col.gameObject.CompareTag("kamien"))
		{
			kamerka.GetComponent<CamerControl> ().Impact ();
            //* ======================== rynek ======================== 
            col.gameObject.GetComponent<PolygonCollider2D>().enabled = false; //usun kolizje
            col.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None; //wylacz freeza
            scale = gameObject.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(scale.x * deltaFall, scale.y * deltaFall);
            // ======================================================== */
            Variables.rocksHit++;
        }
        if (col.gameObject.CompareTag("snieg"))
        {
            scale = gameObject.GetComponent<SpriteRenderer>().transform.localScale = 
                new Vector3(scale.x * deltaRise + (deltaRise/60.0f)*((4*velocity.x + 10.0f)/20.0f), 
                scale.y * deltaRise + (deltaRise/60.0f) * ((4*velocity.x + 10.0f) / 20.0f));
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x, velocity.y / 2);
        }
    }
    public void DeSetFlag()
	{
		flag = false;
	}
}
