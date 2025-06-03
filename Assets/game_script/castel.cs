using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class castel : MonoBehaviour
{
    [SerializeField] private float hp;
    public float RedHp;
    public float BlueHp;
    [SerializeField] private GameObject RedArea;
    [SerializeField] private GameObject BlueArea;
    [SerializeField] private AudioClip sound;
    [SerializeField] private Sprite spriteWhite;
    [SerializeField] private Sprite spriteRed;
    [SerializeField] private Sprite spriteBlue;
    [SerializeField] private GameObject gauge;
    [SerializeField] private List<AudioClip> soundalt = new List<AudioClip>();
    [SerializeField] private float soundCoolDownMax;
    [SerializeField] private float soundCoolDownMin;
    private float soundCoolDowning = 0.0f;

    private float invincibility = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        RedHp = hp;
        BlueHp = hp;
        if(gameObject.tag == "TeamRedCastel")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteRed;
            gameObject.layer = LayerMask.NameToLayer("teamRedCastel");
        } else if (gameObject.tag == "TeamBlueCastel")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteBlue;
            gameObject.layer = LayerMask.NameToLayer("teamBlueCastel");
        } else if(gameObject.name != "MainCastel_blue" && gameObject.name != "MainCastel_red"){
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteWhite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        invincibility -= Time.deltaTime;
        soundCoolDowning -= Time.deltaTime;


        if(gameObject.tag == "TeamRedCastel")
        {
            Swap(true, true);
            Swap(false, false);
        } else if (gameObject.tag == "TeamBlueCastel")
        {
            Swap(true, false);
            Swap(false, true);
        } else {
            Swap(true, false);
            Swap(false, false);
        }


        if(invincibility <= 0.0f)
        {
            GetComponent<Renderer>().material.color = Color.white;
        }
        if(RedHp <= 0 && (gameObject.tag == "TeamBlueCastel" || gameObject.tag == "EmptyCastel") && gameObject.name != "MainCastel_blue")       // 城が赤チームに切り替わる
        {
            BlueHp = hp;
            gameObject.tag = "TeamRedCastel";
            gameObject.layer = LayerMask.NameToLayer("teamRedCastel");
            if(gameObject.name != "MainCastel_blue" && gameObject.name != "MainCastel_red")
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = spriteRed;
            }
        }
        else if(BlueHp <= 0 && (gameObject.tag == "TeamRedCastel" || gameObject.tag == "EmptyCastel") && gameObject.name != "MainCastel_red")  //　城が青チームに切り替わる
        {
            RedHp = hp;
            gameObject.tag = "TeamBlueCastel";
            gameObject.layer = LayerMask.NameToLayer("teamBlueCastel");
            if(gameObject.name != "MainCastel_blue" && gameObject.name != "MainCastel_red")
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = spriteBlue;
            }
        }
        /*
        else if(RedHp <= 0 && gameObject.name == "MainCastel_blue")
        {
            GameObject.Find("StartTimer").GetComponent<StartTimer>().ChangeText("青の完全勝利!", Color.blue);
            StartTimer.isStopTimer = true;
            RedHp = hp * 100;
        }
        else if(BlueHp <= 0 && gameObject.name == "MainCastel_red")
        {
            GameObject.Find("StartTimer").GetComponent<StartTimer>().ChangeText("赤の完全勝利!", Color.blue);
            StartTimer.isStopTimer = true;
            BlueHp = hp * 100;
        }
        */
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(invincibility <= 0.0f)
            if((other.tag == "TeamRedAttack" && (gameObject.tag == "TeamBlueCastel" || gameObject.tag == "EmptyCastel")) || other.tag == "TeamBlueAttack" && (gameObject.tag == "TeamRedCastel" || gameObject.tag == "EmptyCastel"))
            {
                GetComponent<AudioSource>().PlayOneShot(sound);  // 音をならす
                if(gameObject.name == "MainCastel_red" || gameObject.name == "MainCastel_blue")
                {
                    if(soundCoolDowning <= 0.0f)
                    {
                        soundCoolDowning = Random.Range(soundCoolDownMin, soundCoolDownMax);
                        GetComponent<AudioSource>().PlayOneShot(soundalt[Random.Range(0, soundalt.Count)]);
                    }
                }
                invincibility = 0.1f;
                GetComponent<Renderer>().material.color = Color.red;
                attack_area hitObject = other.GetComponent<attack_area>();
                if((gameObject.tag == "TeamRedCastel" || gameObject.tag == "EmptyCastel") && other.tag == "TeamBlueAttack")
                {
                    BlueHp -= hitObject.strength;
                } else if((gameObject.tag == "TeamBlueCastel" || gameObject.tag == "EmptyCastel") && other.tag == "TeamRedAttack")
                {
                    RedHp -= hitObject.strength;
                }
            }
            if(gauge != null)
            {
                if(gameObject.tag == "TeamRedCastel")
                {
                    if(BlueHp == 0)
                    {
                        gauge.GetComponent<chargeingGaugeManager>().gauge = 0;
                    } else {
                        gauge.GetComponent<chargeingGaugeManager>().gauge = BlueHp / hp;
                    }
                } else if (gameObject.tag == "TeamBlueCastel")
                {
                    if(RedHp == 0)
                    {
                        gauge.GetComponent<chargeingGaugeManager>().gauge = 0;
                    } else {
                        gauge.GetComponent<chargeingGaugeManager>().gauge = RedHp / hp;
                        Debug.Log("現在のHP:" + RedHp + "最大HP:" + hp);
                        Debug.Log(RedHp / hp);
                    }
                }
            }
    }

    void Swap(bool red, bool set)
    {
        if(red)
        {
            if(RedArea != null)
            {
                RedArea.SetActive(set);
            }
        }
        if(!red)
        {
            if(BlueArea != null)
            {
                BlueArea.SetActive(set);
            }
        }
    }
}
