﻿using UnityEngine;
using System.Collections;

public class CreateSnowBG : MonoBehaviour {
    public GameObject snowing;

public void CreateSnowin()
    {
        Vector3 pos = Camera.main.transform.position;
        pos.y = pos.y + 70.0f;
        pos.z = Random.Range(0.0f,22.7f);
        pos.x += Random.Range(-2.0f, 2.0f);
        GameObject temp = (GameObject)Instantiate(snowing, pos , Quaternion.identity);
        temp.transform.SetParent(Camera.main.transform);
    }
}
