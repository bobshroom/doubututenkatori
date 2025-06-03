using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartTimer : MonoBehaviour
{
    private float StartTime;
    public static bool isWait;
    [SerializeField] private float showTime;
    public float showTimeLimit;
    public TextMeshProUGUI text;
    private bool isStart = false;
    private bool isChanged = false;
    public static bool isStopTimer = false;
    [SerializeField] private AudioClip sound;
    // Start is called before the first frame update
    void Start()
    {
        StartTime = GameObject.Find("GameManager").GetComponent<GameManagerTimer>().preparationTime;
        isWait = true;
        text = gameObject.GetComponent<TextMeshProUGUI>();
        isStopTimer = false;
    }

    // Update is called once per frame
    void Update()
    {
        showTimeLimit -= Time.deltaTime;
        StartTime -= Time.deltaTime;
        if (StartTime >= 0.0f)
        {
            ChangeText(((int)StartTime+1).ToString(), Color.white);
            isWait = true;
        } else if(isStopTimer){
            isWait = true;
        } else {
            isWait = false;
        }

        if(StartTime <= 0.0f && !isStart)
        {
            GetComponent<AudioSource>().PlayOneShot(sound);
            GameObject.Find("GameManager").GetComponent<GameManager_game>().GameState = "戦闘中";
            ChangeText("GO!", Color.white);
            isStart = true;
        }

        if(showTimeLimit < 0.0f && !isChanged)
        {
            ChangeText("", Color.white);
            isChanged = true;
        }
    }
    public void ChangeText(string showText, UnityEngine.Color color)
    {
        text.color = color;
        text.text = showText;
        showTimeLimit = showTime;
        isChanged = false;
    }
}
