using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Noble : MonoBehaviour {
    private float time;
	void Awake () {
        time = 0.0f;
        if(!Variables.start)
            gameObject.GetComponent<Image>().enabled = false;
    }
	void Update () {
        time += Time.deltaTime;
        if (time >= 1.0f && Variables.start)
        {
            gameObject.GetComponent<Image>().enabled = false;
            Variables.start = false;
        }
        
	}
}
