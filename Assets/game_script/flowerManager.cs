using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerManager : MonoBehaviour
{
    
    Animator animator;

    [SerializeField] private bool teamRed;
    [SerializeField] private int randmin;
    [SerializeField] private int randmax;
    private int waitTime;
    private float time;
    [SerializeField] private bool isSummon;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isSummon = false;
        waitTime = Random.Range(randmin, randmax);
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        animator.ResetTrigger("redBloom");
        animator.ResetTrigger("blueBloom");
        animator.ResetTrigger("redDisbloom");
        animator.ResetTrigger("blueDisbloom");
        time += Time.deltaTime * 60.0f;
        if(time > waitTime)
        {
            waitTime = Random.Range(randmin, randmax);
            time = 0.0f;
            if(isSummon){
                if(teamRed){
                    animator.SetTrigger("redBloom");
                } else {
                    animator.SetTrigger("blueBloom");
                }
            } else {
                if(teamRed){
                    animator.SetTrigger("redDisbloom");
                } else {
                    animator.SetTrigger("blueDisbloom");
                }
            }
            isSummon = false;
        }
        if(false)
        {
            animator.SetTrigger("Reset");
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if((teamRed && other.tag == "TeamRedSummonArea") || (!teamRed && other.tag == "TeamBlueSummonArea"))
        {
            isSummon = true;
        }
    }
}
