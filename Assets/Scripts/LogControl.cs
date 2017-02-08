using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LogControl : MonoBehaviour {
    public Text Log;

    public void Set(string t)
    {
        Log.text = t;
    }
}
