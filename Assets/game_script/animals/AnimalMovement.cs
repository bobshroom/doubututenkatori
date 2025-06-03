using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    public bool useHighQualityMovement;
    public bool teamRed;
    // Start is called before the first frame update
    void Start()
    {
        teamRed = GetComponent<AnimalManager>().TeamRed;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            Destroy(gameObject);
        }
    }
}
