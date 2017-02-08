using UnityEngine;
using System.Collections;

public class GOButton : MonoBehaviour {
    public void Clicked()
    {
        Application.LoadLevel("Gameplay");
    }
}
