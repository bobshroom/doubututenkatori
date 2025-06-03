using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class deathSoul : MonoBehaviour
{
    [SerializeField] private float y;
    private float time = 0.5f;
    [SerializeField] private float sinSpeed;
    [SerializeField] private float sinHaba;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        transform.position = new Vector3(transform.position.x + math.sin(time * sinSpeed) * sinHaba * time, transform.position.y + y * time, 0);
        if(transform.position.y > 10)
        {
            Destroy(gameObject);
        }
    }
}
