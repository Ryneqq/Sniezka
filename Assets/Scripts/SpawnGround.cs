using UnityEngine;
using System.Collections;

public class SpawnGround : MonoBehaviour {
    public GameObject ground;
    public GameObject ground2;
    public GameObject newGround;
    private Vector2 posA;
    private Vector2 posB;
    private Vector2 pos;
    private float x, y;
    private float time;
	// Use this for initialization
	void Start () {
        posA = ground.transform.position;
        posB = ground2.transform.position;
        x = posB.x - posA.x;
        y = posB.y - posB.y;
        Debug.Log(x); Debug.Log(y);
        pos = posB;
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if(time > 3.0f)
        {
            Spawn();
            time = 0.0f;
        }
	}
    private void Spawn()
    {
        Vector2 temp = new Vector2(x, y);
        pos += temp;
        Instantiate(newGround, pos, Quaternion.identity);
    }
}
