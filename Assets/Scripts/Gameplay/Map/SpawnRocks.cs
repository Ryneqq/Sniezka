using UnityEngine;
using System.Collections;

public class SpawnRocks : MonoBehaviour {
    public GameObject rock;
    private MapControl map;
    private Vector2 pos;
    private float time;

	void Start () { 
        map = gameObject.GetComponent<MapControl>();
        Spawn();
    }

	void Update () {
        if (!Variables.gameOver)
        {
            if (map.Distance(pos) < 10.0f)
            {
                Spawn();
                time = 0.0f;
            }
            else
            {
                time += Time.deltaTime;
                if (time > 5.0f)
                {
                    Spawn();
                    time = 0.0f;
                }
            }
        }
	}
    public void Spawn()
    {
        int quantity = Random.Range(1, 10);
        for (int i = 0; i < quantity; i++)
        {
            pos = gameObject.GetComponent<MapControl>().ReRockPos();
            Instantiate(rock, pos, Quaternion.Euler(new Vector3(0, 0, Random.Range(-20.0f, 20.0f))));
        } 
    }
}
