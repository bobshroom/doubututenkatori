using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_game : MonoBehaviour
{
    public GameManagerGauge GameManagerGauge;
    public static bool debug = false;   // デバッグモード
    public string GameState;
    /*プレイヤーのステータス*/
    public int move_speed;
    public int summon_delay;
    public float brake;
    public bool isforced;
    /*召喚アイテムの制御*/
    public int redSummonItem;
    public int blueSummonItem;
    public int MaxSummonItem;
    [SerializeField] private float cooltimeSummonItem;
    public float redSummonGauge;
    public float blueSummonGauge;
    public static float wastedTime;
    public static float speedMultiplier = 1;
    public static float itemmultiplier = 1;
    [SerializeField] private GameObject redGauge;
    [SerializeField] private GameObject blueGauge;

    // Start is called before the first frame update
    void Start()
    {
        GameManagerGauge = gameObject.GetComponent<GameManagerGauge>();
        wastedTime = 0.0f;
        GameManagerGauge.MakeGauge(true);
        GameManagerGauge.MakeGauge(false);
    }

    // Update is called once per frame
    void Update()
    {
        int a = 0;
        wastedTime += Time.deltaTime * 60.0f;
        if(GameState == "戦闘中")
        {
            redSummonGauge += Time.deltaTime * (60 / cooltimeSummonItem * speedMultiplier);
            blueSummonGauge += Time.deltaTime * (60 / cooltimeSummonItem * speedMultiplier);
            if(redSummonItem < MaxSummonItem * itemmultiplier)
            {
                a = (int)(redSummonGauge / 1.0f);
                redSummonItem += a;
                redSummonGauge %= 1.0f;
                if(a > 0)
                {
                    GameManagerGauge.MakeGauge(true);
                }
            } else if (redSummonGauge > 1.0f)
            {
                redSummonGauge = 1.0f;
            }
            if(blueSummonItem < MaxSummonItem * itemmultiplier)
            {
                a = (int)(blueSummonGauge / 1.0f);
                blueSummonItem += a;
                blueSummonGauge %= 1.0f;
                if(a > 0)
                {
                    GameManagerGauge.MakeGauge(false);
                }
            } else if (blueSummonGauge > 1.0f)
            {
                blueSummonGauge = 1.0f;
            }
        }
        if(Input.GetKeyDown(KeyCode.U))
        {
            swapDebug();
        }
        if(Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene("Title");
        }
        redGauge.GetComponent<chargeingGaugeManager>().gauge = redSummonGauge;
        blueGauge.GetComponent<chargeingGaugeManager>().gauge = blueSummonGauge;
    }
    void swapDebug()
    {
        if(debug){
            debug = false;
            speedMultiplier = 1;
            itemmultiplier = 1;
            Debug.Log("デバッグモード終了");
        } else {
            debug = true;
            speedMultiplier = 100;
            itemmultiplier = 100;
            Debug.Log("デバッグモード開始");
        }
    }
}