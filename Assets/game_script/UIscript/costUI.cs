using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class costUI : MonoBehaviour
{
    [SerializeField] private GameObject number;
    private int a = 1;
    // Start is called before the first frame update
    void Start()
    {
        CharaSelect charaSelect = gameObject.GetComponent<CharaSelect>();
        playerSummonChara playerSummonChara = null;
        if(charaSelect.TeamRed)
        {
            playerSummonChara = GameObject.Find("redgod").GetComponent<playerSummonChara>();
        } else {
            playerSummonChara = GameObject.Find("bluegod").GetComponent<playerSummonChara>();
        }
        AnimalManager animalManager = playerSummonChara.SummonList[charaSelect.CharaId].GetComponent<AnimalManager>();
        int cost = animalManager.cost;
        
        foreach(char num in cost.ToString().ToList())
        {
            GameObject instant = Instantiate(number, gameObject.transform.position + new Vector3(0.4f - ((cost.ToString().Length - a) * 0.25f), 0.45f, 0), Quaternion.identity, gameObject.transform);
            instant.transform.localScale = new Vector3(0.8f, 0.8f, 0);
            instant.GetComponent<number>().num = (int)num - 48;
            a += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
