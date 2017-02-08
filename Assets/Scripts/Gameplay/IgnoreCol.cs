using UnityEngine;
using System.Collections;

public class IgnoreCol : MonoBehaviour {
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("sniezka"))
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
