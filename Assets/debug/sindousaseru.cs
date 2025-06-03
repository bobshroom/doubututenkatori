using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sindousaseru : MonoBehaviour
{
    private Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos.x = pos.x + 0.01f;
        transform.position = pos;
    }
}
