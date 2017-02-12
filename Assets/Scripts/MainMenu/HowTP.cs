using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HowTP : MonoBehaviour {
    public Button htp;
  
    public void Spawn()
    {
        /* if (!Variables.howTP)
         {
             Button temp = (Button)Instantiate(htp, pos, Quaternion.identity);
             temp.transform.SetParent(can.transform);
             Variables.howTP = true;
         }*/
        htp.GetComponent<Image>().enabled = true;
    }
    public void DeSpawn()
    {
        //Destroy(this.gameObject);
        //Variables.howTP = false;
        htp.GetComponent<Image>().enabled = false;
    }
}
