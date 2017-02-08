using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
    private Vector2 min, max;
    private bool gameEnd = false, win = false;
    private float time = 0.0f;

    void Start()
    {
        min = new Vector2(0.5f, 0.5f);
        max = new Vector2(5.0f, 5.0f);
    }
	void Update ()
    {   
        if(gameObject.transform.localScale.x < min.x && !gameEnd)
        {
            Camera.main.GetComponent<CamerControl>().relased = true;
            gameEnd = true;
            Camera.main.GetComponent<LogControl>().Set("You Lose");
        }
        if (gameObject.transform.localScale.x > max.x && !gameEnd)
        {
            Camera.main.GetComponent<CamerControl>().relased = true;
            gameEnd = true;
            win = true;
            Camera.main.GetComponent<LogControl>().Set("You Win");
        }
        if (gameEnd)
        {
            Variables.gameOver = true;
            time += Time.deltaTime;
            if (time > 3.0f)
            {
                if (win == true)
                {
                    Application.LoadLevel("GameOver");
                }
                else
                {
                    Application.LoadLevel("GameOver");
                }
            }   
        }
    }
}
