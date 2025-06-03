using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSummonChara : MonoBehaviour
{
    [SerializeField] private GameObject gamane;
    private GameManager_game gameManager;
    [SerializeField] private UnityEngine.KeyCode SummonKey;
    public List<GameObject> SummonList = new List<GameObject>();
    private List<int> costList = new List<int>();
    [SerializeField] private List<UnityEngine.KeyCode> SummonKeyList = new List<UnityEngine.KeyCode>();
    [SerializeField] private List<UnityEngine.KeyCode> SummonKeyList2 = new List<UnityEngine.KeyCode>();
    [SerializeField] private Transform summon_parent;
    [SerializeField] int summon_delay;
    [SerializeField] bool player_team_red;
    public int SelectingChara = 0;
    
    private float summonReset = 0.0f;
    private float timeElapsed;
    private bool isSummon = false;
    
    private int movemove;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = gamane.GetComponent<GameManager_game>();
        for(int i=0; i<SummonList.Count; i++)
        {
            AnimalManager animalManager = SummonList[i].GetComponent<AnimalManager>();
            costList.Add(animalManager.cost);
        }
        if(gameManager.isforced) // もしGameManager_gameの強制設定がtrueならステータスをそれに変更する
        {
            summon_delay = gameManager.summon_delay;
        }
        if(player_team_red)
        {
            movemove = 1;
        } else {
            movemove = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        timeElapsed += Time.deltaTime * 60;
        summonReset -= Time.deltaTime;
        if(summonReset <= 0.0f)
        {
            isSummon = false;
            summonReset = 0.2f;
        }
        for(int n=0; n<SummonKeyList.Count; n++)
        {
            if(Input.GetKey(SummonKeyList[n]))
            {
                SelectingChara = n;
            }
        }
        if(SummonKeyList2 != null)
        {
        for(int n=0; n<SummonKeyList2.Count; n++)
        {
            if(Input.GetKey(SummonKeyList2[n]))
            {
                SelectingChara = n;
            }
        }
        }

        if(Input.GetKey(SummonKey)){
            if(timeElapsed >= summon_delay) {
                if(isSummon && ((player_team_red && costList[SelectingChara] <= gameManager.redSummonItem) || (!player_team_red && costList[SelectingChara] <= gameManager.blueSummonItem))){
                    if(player_team_red)
                    {
                        gameManager.redSummonItem -= costList[SelectingChara];
                    } else {
                        gameManager.blueSummonItem -= costList[SelectingChara];
                    }
                    Instantiate(SummonList[SelectingChara], new Vector3(this.transform.position.x + movemove, this.transform.position.y, 0), Quaternion.identity, summon_parent);
                    timeElapsed = 0.0f;
                }
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(player_team_red && other.tag == "TeamRedSummonArea")
        {
            isSummon = true;
        }
        if(!player_team_red && other.tag == "TeamBlueSummonArea")
        {
            isSummon = true;
        }
    }
}
