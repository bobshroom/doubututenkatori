using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void Game_start()
    {
        SceneManager.LoadScene("Game");
    }
    public static void go_to_zukan()
    {
        SceneManager.LoadScene("zukan");
    }
}

public static class Hensu
{
    public static int charaNum;
}