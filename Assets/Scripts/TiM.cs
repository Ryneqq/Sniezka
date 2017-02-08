using UnityEngine;
using System.Collections;
// yeah, TiM stands from time is money ;)
public class TiM : MonoBehaviour {
	void Start () {
        Variables.gameOver = false;
        Variables.time = 0.0f;
	}
	void Update () {
        if (!Variables.gameOver)
            Variables.time += Time.deltaTime;
	}
}
