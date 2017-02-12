using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
    private Vector2 min, max;
    private bool gameEnd = false, win = false, done = false;
    private float time = 0.0f;

    void Start()
    {
        min = new Vector2(0.5f, 0.5f);
        max = new Vector2(5.0f, 5.0f);
    }
    void Update()
    {
        if (gameEnd)
        {
            time += Time.deltaTime;
            if (time > 3.0f && !done)
            {
                Variables.gameOver = true;
                SaveRecord();
                EndTheGame();
                done = true;
            }
            if (!GameObject.FindGameObjectWithTag("sniezka").GetComponent<Rigidbody2D>().isKinematic)
            {
                if (gameObject.transform.position.x > Camera.main.transform.position.x + 50.0f)
                    GameObject.FindGameObjectWithTag("sniezka").GetComponent<Rigidbody2D>().isKinematic = true;
            }
        }
        else
        {
            if (gameObject.transform.localScale.x < min.x && !gameEnd)
            {
                Camera.main.GetComponent<CamerControl>().relased = true;
                gameEnd = true;
            }
            if (gameObject.transform.localScale.x > max.x && !gameEnd)
            {
                Camera.main.GetComponent<CamerControl>().relased = true;
                gameEnd = true;
                win = true;
            }
        }
    }
    private void SaveRecord()
    {
        if (!PlayerPrefs.HasKey("record"))
        {
            PlayerPrefs.SetFloat("record", Variables.time);
            PlayerPrefs.Save();
        }
        else if (PlayerPrefs.GetFloat("record") > Variables.time)
        {
            PlayerPrefs.SetFloat("record", Variables.time);
            PlayerPrefs.Save();
        }
    }
    private void EndTheGame()
    {
        if (win == true)
        {
            Camera.main.GetComponent<LogControl>().Set("WINNER\r\n\r\nTime:" + CutStr(Variables.time.ToString()) + 
                "s\r\nRecord:" + CutStr(PlayerPrefs.GetFloat("record").ToString()) + "s");
            GameObject.FindGameObjectWithTag("log").GetComponent<Canvas>().enabled = true;
        }
        else
        {
            Camera.main.GetComponent<LogControl>().Set("Game Over\r\n\r\nTime:" + 
                CutStr(Variables.time.ToString()) + "s\r\n Rocks hit: " + Variables.rocksHit.ToString());
            GameObject.FindGameObjectWithTag("log").GetComponent<Canvas>().enabled = true;
        }
    }
    private string CutStr(string t)
    {
        string temp = " ";
        for(int i=0; i < t.Length; i++)
        {
            temp += t[i];
            if (t[i] == '.')
            {
                temp += t[i+1];
                break;
            }
        }
        return temp;
    }
}
