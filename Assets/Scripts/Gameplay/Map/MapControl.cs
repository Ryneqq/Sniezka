using UnityEngine;
using System.Collections;

public class MapControl : MonoBehaviour {

    private Vector2 posK;
    private DetectCol col;
    private float x, y, a, b, bp; // a b i bp to zmienne dla funkcji rownoleglych
    private float def = 1.0f; //stala - potrzebna do obnizenie z lekka prostej zeby kamienie nie lewitowaly
    private float time, clearTime = 8.0f;

    void Start () {
        col = GameObject.FindGameObjectWithTag("sniezka").GetComponent<DetectCol>();
        posK = GameObject.FindGameObjectWithTag("sniezka").transform.position;
	}

	void Update ()
    {
        posK = GameObject.FindGameObjectWithTag("sniezka").transform.position; // sledzi pozycje sniezki
        time += Time.deltaTime;
        if (time > clearTime)
        {
            ClearMap();
            col.IncreaseDeltaRise(0.0005f);
            col.DecreaseDeltaFall(0.0005f);
            time = 0.0f;
        }
	
	}
    private void ClearMap()
    {
        GameObject[] groundList = GameObject.FindGameObjectsWithTag("snieg");
        GameObject[] rockList = GameObject.FindGameObjectsWithTag("kamien");

        foreach (GameObject ground in groundList)
        {
            if (Distance(ground.transform.position) > 150.0f)
            {
                Destroy(ground.gameObject);
            }
        }
        foreach (GameObject rock in rockList)
        {
            if (Distance(rock.transform.position) > 150.0f)
            {
                Destroy(rock.gameObject);
            }
        }
    }
    // zwraca dystans pomiedzy obiektem a kulka
    public float Distance(Vector2 pos)
    {
        float d = Mathf.Sqrt(Mathf.Pow(pos.x - posK.x, 2) + Mathf.Pow(pos.y - posK.y, 2)); //odleglosc
        return d;
    }
    // zwraca aktualna pozycje kulki
    public Vector2 GetPos()
    {
        return posK;
    }
    // zwraca pozycje zespawnowania kolejnego kamienia
    public Vector2 ReRockPos()
    {
        Vector2 temp = posK;
        temp.x += Random.Range(30.0f, 45.0f);
        temp.y = a * temp.x + bp; //y=ax+b - rownanie prostej
        return temp;
    }
    // inicjalizuje proste na ktorych sa spawnowane przeszkody
    public void InitialzeMap(Vector2 posA, Vector2 posB)
    {
        //wyznaczenie prostej prostopadlej
        a = (posB.y - posA.y) / (posB.x - posA.x);
        b = posA.y - posA.x * a;
        float c = (-1) / a; // wsp kierunkowy prostej prostopadlej
        float d = posK.y - posK.x * c; // wyliczenie d na podstawie pk nalezacego do tej prostej
        Vector2 PP = new Vector2((b - d) / (a - c), (b - d) / (a - c) * a - b); // wyliczenie punktu przeciecia dwoch funkcji
        float length = Mathf.Sqrt(Mathf.Pow(PP.x + posK.x, 2) + Mathf.Pow(PP.y + posK.y, 2)); //odleglosc pomiedzy nimi
        bp = b + length - def; // bprim - miejce przeciecia prostej rownoleglej z osia y
    }
}
