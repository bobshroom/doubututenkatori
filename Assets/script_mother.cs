using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_mother : MonoBehaviour
{
    public static string game_state;
    private float timeOut = 1.0f;
	private float timeElapsed;
    // Start is called before the first frame update
    void Start()
    {
        script_mother.game_state = "スタート画面";
        Debug.Log(script_mother.game_state);
    }
    void Update()
    {
        timeElapsed += Time.deltaTime;
        
        if(timeElapsed >= timeOut) {
        	// Do anything
        	ShowGameState();
        	timeElapsed = 0.0f;
        }
    }
    public void ShowGameState()
    {
        Debug.Log("現在の状況は" + script_mother.game_state + "です");
    }
}