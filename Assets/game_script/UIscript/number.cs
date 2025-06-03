using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class number : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprite = new List<Sprite>();
    public int num;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite[num];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
