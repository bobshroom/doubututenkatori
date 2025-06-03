using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack_area : MonoBehaviour
{

    private GameObject parentObj;
    private AnimalManager parentScript;
    public int attack;
    public int strength;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.layer = 9;
        parentObj = transform.parent.gameObject;
        parentScript = transform.parent.GetComponent<AnimalManager>();

        if(parentObj.gameObject.tag == "TeamRed")
        {
            gameObject.tag = "TeamRedAttack";
        } else if(parentObj.gameObject.tag == "TeamBlue"){
            gameObject.tag = "TeamBlueAttack";
        } else {
            Debug.Log("攻撃範囲のタグ指定に失敗しました");
        }

        attack = parentScript.attack;
        strength = parentScript.strength;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
