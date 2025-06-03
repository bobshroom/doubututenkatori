using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{

    private GameManagerTimer GameManagerTimer;
    private float timeLimit;
    private bool lowTime = false;
    private bool additionalTime = false;
    // Start is called before the first frame update
    void Start()
    {  
        GameManagerTimer = GameObject.Find("GameManager").GetComponent<GameManagerTimer>();
        timeLimit = GameManagerTimer.timeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        if(!StartTimer.isWait){
            timeLimit -= Time.deltaTime;
        }
        if(timeLimit < GameManagerTimer.lowTimeLimit && !lowTime && !additionalTime)
        {
            lowTime = true;
            GameManager_game.speedMultiplier = 2;
            gameObject.GetComponent<Text>().color = Color.yellow;
            GameObject.Find("StartTimer").GetComponent<StartTimer>().ChangeText("ラストスパート!", Color.yellow);
        }
        if(timeLimit < 0)
        {
            if(additionalTime)
            {
                GameObject.Find("GameManager").GetComponent<GameManagerDicisionOfVictory>().Check3();
            }
            if(!additionalTime && GameObject.Find("GameManager").GetComponent<GameManagerDicisionOfVictory>().CheckPoint())
            {
                GameManager_game.speedMultiplier = 3;
                timeLimit += GameManagerTimer.additionalTimeLimit;
                additionalTime = true;
                gameObject.GetComponent<Text>().color = Color.red;
                GameObject.Find("StartTimer").GetComponent<StartTimer>().ChangeText("延長中に突入!", Color.red);
            }
        }
        gameObject.GetComponent<Text>().text = SetTime((int)(timeLimit / 60), (int)(timeLimit % 60));
    }

    string SetTime(int a, int b)
    {
        return $"{a}:{b:D2}";
    }
}
