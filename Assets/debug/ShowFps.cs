using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowFps : MonoBehaviour
{

    private float time;

    [SerializeField] float timeDelay;
    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (time > timeDelay){
            gameObject.GetComponent<Text>().text = "FPS : " + ((int)(1 / Time.deltaTime)).ToString();
            time = 0.0f;
        }
        time += Time.deltaTime;
    }
}
