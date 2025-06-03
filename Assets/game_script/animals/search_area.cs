using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class search_area : MonoBehaviour
{
    private GameObject parent;
    private AnimalManager parentScript;
    private float time;
    private float t = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.layer = 8;
        parent = transform.parent.gameObject;
        parentScript = transform.parent.GetComponent<AnimalManager>();
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= 0.2f)
        {
            t -= Time.deltaTime;
            if(t < 0.0f)
            {
                parentScript.isAttack = false;
                time = 0.0f;
            }
            
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if((parent.tag == "TeamRed" && (other.tag == "TeamBlue" || other.tag == "TeamBlueCastel" || other.tag == "EmptyCastel")) || (parent.tag == "TeamBlue" && (other.tag == "TeamRed" || other.tag == "TeamRedCastel" || other.tag == "EmptyCastel")))
        {
            parentScript.isAttack = true;
            t = 0.2f;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        parentScript.isAttack = false;
    }
}
