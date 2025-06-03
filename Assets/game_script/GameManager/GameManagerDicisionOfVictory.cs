using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerDicisionOfVictory : MonoBehaviour
{
    public int teamRedPoint;
    public int teamBluePoint;
    [SerializeField] private List<GameObject> castelList = new List<GameObject>();
    [SerializeField] private GameObject redMainCastel;
    [SerializeField] private GameObject blueMainCastel;
    private float redHp;
    private float blueHp;
    [SerializeField] private Sprite redWin;
    [SerializeField] private Sprite blueWin;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        redHp = redMainCastel.GetComponent<castel>().BlueHp;
        blueHp = blueMainCastel.GetComponent<castel>().RedHp;

        if(redHp <= 0.0f)
        {
            GameObject.Find("StartTimer").GetComponent<StartTimer>().ChangeText("青の完全勝利!", Color.blue);
            StartTimer.isStopTimer = true;
            GetComponent<SpriteRenderer>().sprite = blueWin;
            animator.SetTrigger("winStart");
        }
        if(blueHp <= 0.0f)
        {
            GameObject.Find("StartTimer").GetComponent<StartTimer>().ChangeText("赤の完全勝利!", Color.red);
            StartTimer.isStopTimer = true;
            GetComponent<SpriteRenderer>().sprite = redWin;
            animator.SetTrigger("winStart");
        }
    }

    public bool CheckPoint()
    {
        teamRedPoint = teamBluePoint = 0;
        foreach(GameObject castel in castelList)
        {
            if(castel.gameObject.tag == "TeamRedCastel")
            {
                teamRedPoint += 1;
            } else if (castel.gameObject.tag == "TeamBlueCastel")
            {
                teamBluePoint += 1;
            }
        }
        if(teamRedPoint == teamBluePoint)
        {
            return true;
        } else if(teamRedPoint < teamBluePoint)
        {
            GameObject.Find("StartTimer").GetComponent<StartTimer>().ChangeText("青の判定勝利", Color.blue);
            StartTimer.isStopTimer = true;
            GetComponent<SpriteRenderer>().sprite = blueWin;
            animator.SetTrigger("winStart");
        } else {
            GameObject.Find("StartTimer").GetComponent<StartTimer>().ChangeText("赤の判定勝利", Color.red);
            StartTimer.isStopTimer = true;
            GetComponent<SpriteRenderer>().sprite = redWin;
            animator.SetTrigger("winStart");
        }
        return false;
    }
    public void Check3()
    {
        if(redHp == blueHp)
        {
            GameObject.Find("StartTimer").GetComponent<StartTimer>().ChangeText("引き分け", Color.white);
            StartTimer.isStopTimer = true;
        } else if (redHp > blueHp)
        {
            GameObject.Find("StartTimer").GetComponent<StartTimer>().ChangeText("赤の点差勝利", Color.red);
            StartTimer.isStopTimer = true;
            GetComponent<SpriteRenderer>().sprite = redWin;
            animator.SetTrigger("winStart");
        } else {
            GameObject.Find("StartTimer").GetComponent<StartTimer>().ChangeText("青の判定勝利", Color.blue);
            StartTimer.isStopTimer = true;
            GetComponent<SpriteRenderer>().sprite = blueWin;
            animator.SetTrigger("winStart");
        }
    }
}
