using UnityEngine;
using System.Collections;

public class SpawnGround : MonoBehaviour {
    public GameObject ground;
    public GameObject ground2;
    public GameObject newGround;
    private MapControl map;
    private Vector2 posA;
    private Vector2 posB;
    private Vector2 pos;
    private float x,y;

    void Start()
    {
        posA = ground.transform.position;
        posB = ground2.transform.position;
        x = posB.x - posA.x;
        y = posB.y - posA.y;
        pos = posB;
        map = gameObject.GetComponent<MapControl>();
        map.InitialzeMap(posA, posB);
    }
	void Update () {
        if(map.Distance(pos) < 120.0f)
        {
            Spawn();
        }
	}
    // funkcja wylicza pozycje i spawnuje ground'a
    private void Spawn()
    {
        Vector2 temp = new Vector2(x, y);
        pos += temp;
        Instantiate(newGround, pos, Quaternion.identity);
    }
}
