using UnityEngine;
using System.Collections;

public class BGControl : MonoBehaviour {
    private float time = 0.0f,maxTime = 20.0f;
    private bool created = false;
	void Update () {
        time += Time.deltaTime;
        if (time > maxTime)
        {
            Destroy(this.gameObject);
        }
        if (time > 5.0f && !created)
        {
            Camera.main.GetComponent<CreateSnowBG>().CreateSnowin();
            created = true;
        }
    }
}
