using UnityEngine;
using System.Collections;

public class SpawnGround : MonoBehaviour {
    public GameObject ground;
    public GameObject ground2;
    public GameObject newGround;
    private Vector2 posA;
    private Vector2 posB;
    private Vector2 posK; // pozycja kulki
    private Vector2 pos;
    private float x, y, a, b, bp; // a b i bp to zmienne dla funkcji rownoleglych
    private float py; //odleglosc do powierzchni sniegu od prostej utworzonej ze srodkow 
    private float time;

	void Start () {
        posA = ground.transform.position;
        posB = ground2.transform.position;
        x = posB.x - posA.x;
        y = posB.y - posA.y;
        Debug.Log(x); Debug.Log(y);
        pos = posB;
        InitialzeFunc(GameObject.Find("sniezka").gameObject.transform.position);
    }
	void Update () {
        time += Time.deltaTime;
        if(time > 3.0f) // zrobic nie czas a pozycja sniezki
        {
            Spawn();
            time = 0.0f;
        }
	}
    // funkcja wylicza pozycje i spawnuje ground'a
    private void Spawn()
    {
        Vector2 temp = new Vector2(x, y);
        pos += temp;
        Instantiate(newGround, pos, Quaternion.identity);
    }
    // funkcja przyjmuje aktualna pozycje kulki;
    public Vector2 ReturnPos(Vector2 pT)
    {
        posK = pT;
        posK.x += Random.Range(15.0f, 30.0f);
        posK.y = a * posK.x + bp; //y=ax+b
        return posK;
    }
    public void InitialzeFunc(Vector2 pT)
    {
        posK = pT;
        //wyznaczenie prostej prostopadlej
        a = (posB.y - posA.y) / (posB.x - posA.x);
        b = posA.y - posA.x * a;
        float c = (-1) / a;
        float d = posK.y - posK.x * c;
        Vector2 PP = new Vector2((b - d) / (a - c), (b - d) / (a - c) * a - b); // punkt przeciecia dwoch funkcji
        float length = Mathf.Sqrt(Mathf.Pow(PP.x + posK.x, 2) + Mathf.Pow(PP.y + posK.y, 2)); //odleglosc
        bp = b + length; // bprim
    }
}
