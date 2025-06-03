using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class GameManagerGauge : MonoBehaviour
{
    [SerializeField] private GameObject Gamane;
    private GameManager_game GameManager;
    [SerializeField] private Transform redParent;
    [SerializeField] private Transform blueParent;
    public float spacing;
    [SerializeField] private Vector2 teamRedPos;
    [SerializeField] private Vector2 teamBluePos;
    [SerializeField] private GameObject gauge;
    private costGauge costGauge;
    [SerializeField] private GameObject chargedGauge;
    [SerializeField] private Transform redChargedParent;
    [SerializeField] private Transform blueChargedParent;
    public int teamRedChargedGauge;
    public int teamBlueChargedGauge;
    // Start is called before the first frame update
    void Start()
    {
        teamRedChargedGauge = GameObject.Find("GameManager").GetComponent<GameManager_game>().redSummonItem;
        teamBlueChargedGauge = GameObject.Find("GameManager").GetComponent<GameManager_game>().blueSummonItem;
        GameManager = Gamane.GetComponent<GameManager_game>();
        costGauge = gauge.GetComponent<costGauge>();
        Vector2 pos = teamRedPos;
        for(int i=0; i<GameManager.MaxSummonItem; i++)
        {
            Instantiate(gauge, pos, Quaternion.identity, redParent);
            pos.x += spacing;
        }
        pos = teamBluePos;
        for(int i=0; i<GameManager.MaxSummonItem; i++)
        {
            Instantiate(gauge, pos, Quaternion.identity, blueParent);
            pos.x -= spacing;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeGauge(bool teamRed)
    {
        GameObject instant = null;
        if(teamRed)
        {
            while(teamRedChargedGauge < GameObject.Find("GameManager").GetComponent<GameManager_game>().redSummonItem)
            {
                teamRedChargedGauge += 1;
                instant = Instantiate(chargedGauge, new Vector2(teamRedPos.x + spacing * (teamRedChargedGauge - 1), teamRedPos.y), Quaternion.identity, redChargedParent);
                instant.GetComponent<chargedGauge>().number = teamRedChargedGauge;
                instant.GetComponent<chargedGauge>().teamRed = true;
            }
        } else {
            while(teamBlueChargedGauge < GameObject.Find("GameManager").GetComponent<GameManager_game>().blueSummonItem)
            {
                teamBlueChargedGauge += 1;
                instant = Instantiate(chargedGauge, new Vector2(teamBluePos.x - spacing * (teamBlueChargedGauge - 1), teamBluePos.y), Quaternion.identity, blueChargedParent);
                instant.GetComponent<chargedGauge>().number = teamBlueChargedGauge;
                instant.GetComponent<chargedGauge>().teamRed = false;
            }
        }
    }

}
