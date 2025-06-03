using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class summonItemNum : MonoBehaviour
{
    [SerializeField] private bool teamRed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        string text = "";
        if(teamRed)
        {
            text = GameObject.Find("GameManager").GetComponent<GameManager_game>().redSummonItem.ToString();
        } else {
            text = GameObject.Find("GameManager").GetComponent<GameManager_game>().blueSummonItem.ToString();
        }
        gameObject.GetComponent<Text>().text = text;
    }
}
