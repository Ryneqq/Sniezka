using UnityEngine;
using System.Collections;

public class SpawnRocks : MonoBehaviour {
    public GameObject rock;
    private Vector2 pos;
    private float time;
    private float delta;
	// Use this for initialization
	void Start () {
        delta = Random.Range(1.0f, 2.0f);
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
	    if (time > delta)
        {
            SpawnR();
        }
	}
    public void SpawnR()
    {
        pos = Camera.main.GetComponent<SpawnGround>().ReturnPos(GameObject.Find("sniezka").gameObject.transform.position);
        Instantiate(rock, pos, Quaternion.Euler(new Vector3(0, 0, Random.Range(-15.0f,15.0f))));
        time = 0.0f;
    }
}
