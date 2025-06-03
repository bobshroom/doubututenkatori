using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chargedGauge : MonoBehaviour
{
    public bool teamRed;
    public int number;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(teamRed)
        {
            if(GameObject.Find("GameManager").GetComponent<GameManager_game>().redSummonItem < number)
            {
                Destroy(gameObject);
                GameObject.Find("GameManager").GetComponent<GameManagerGauge>().teamRedChargedGauge -= 1;
            }
        } else {
            if(GameObject.Find("GameManager").GetComponent<GameManager_game>().blueSummonItem < number)
            {
                Destroy(gameObject);
                GameObject.Find("GameManager").GetComponent<GameManagerGauge>().teamBlueChargedGauge -= 1;
            }
        }
    }
}
