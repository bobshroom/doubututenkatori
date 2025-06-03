using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHantei : MonoBehaviour
{

    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager_game.debug)
        {
            sprite.enabled = true;
        } else {
            sprite.enabled = false;
        }
    }
}
