using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaSelect : MonoBehaviour
{
    public int CharaId;
    public bool TeamRed;
    [SerializeField] private GameObject redGod;
    [SerializeField] private GameObject blueGod;
    [SerializeField] private float MoveUp;
    private playerSummonChara redgodscript;
    private playerSummonChara bluegodscript;
    private GameObject child; 
    private float oriposi;

    public bool test;
    private float currentColorType = 1.0f;

    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        redgodscript = redGod.GetComponent<playerSummonChara>();
        bluegodscript = blueGod.GetComponent<playerSummonChara>();
        child = transform.GetChild(0).gameObject;
        pos = transform.position;
        oriposi = pos.y;
    }

    // Update is called once per frame
    void Update()
    {
        if((TeamRed && redgodscript.SelectingChara == CharaId) || !TeamRed && bluegodscript.SelectingChara == CharaId)
        {
            if(pos.y < oriposi + MoveUp)
            {
                pos.y += 5.0f * Time.deltaTime;
            }
            if(currentColorType < 1.0f)
            {
                currentColorType += Time.deltaTime;
            }
        }
        else
        {
            if(pos.y > oriposi)
            {
                pos.y -= 5.0f * Time.deltaTime;
            }
            if(currentColorType > 0.7f)
            {
                currentColorType -= Time.deltaTime;
            }
        }
        if(pos.y > oriposi + MoveUp)
        {
            pos.y = oriposi + MoveUp;
        }
        if(pos.y < oriposi)
        {
            pos.y = oriposi;
        }
        if(currentColorType > 1.0f)
        {
            currentColorType = 1.0f;
        }
        if(currentColorType < 0.7f)
        {
            currentColorType = 0.7f;
        }
        transform.position = pos;
        ChangeAlpha(currentColorType);
    }

    public void ChangeAlpha(float alphaValue)
    {
        // alphaValueは0（完全に透明）から1（完全に不透明）の間の値
        Renderer renderer = GetComponent<Renderer>();
        Renderer childrenderer = child.GetComponent<Renderer>();
        Color currentColor = renderer.material.color;
        Color currentColorChild = childrenderer.material.color;
        currentColor.a = alphaValue;
        currentColorChild.a = alphaValue;
        renderer.material.color = currentColor;
        childrenderer.material.color = currentColorChild;
    }
}
