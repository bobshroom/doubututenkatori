using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerZukan : MonoBehaviour
{
    [SerializeField] private List<GameObject> gameObjects = new List<GameObject>();
    [SerializeField] private Transform teamredparent;
    [SerializeField] private Transform teamblueparent;
    private GameObject instant;
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.name == "GameManager-summoner")
        {   
            Transform parent;
            if(Hensu.charaNum <= 2 || Hensu.charaNum == 6)
            {
                parent = teamredparent;
            }
            else
            {
                parent = teamblueparent;
            }
            instant = Instantiate(gameObjects[Hensu.charaNum], new Vector3(0,0,0), quaternion.identity, parent);
        
            instant.transform.localScale = instant.transform.localScale * 3.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Zukan");
        }
        if(instant != null)
        {
            instant.transform.position = new Vector3(0, 0, 0);
            if(Hensu.charaNum == 3)
            {
                instant.transform.position = new Vector3(0, -4, 0);
            }
            if(Hensu.charaNum == 2)
            {
                instant.transform.position = new Vector3(-4, 0, 0);
            }
        }

        if(gameObject.name == "GameManager-summoner")
        {
            if(Input.GetKeyDown(KeyCode.A))
            {
                instant.GetComponent<AnimalManager>().isAttack2 = true;
            }
            if(Input.GetKey(KeyCode.S))
            {
                instant.GetComponent<AnimalManager>().is3 = true;
            }
        }
    }
    public static void OnClickTest(int n)
    {
        Hensu.charaNum = n;
        SceneManager.LoadScene("Zukan2");
    }

    public static void OnClickNext()
    {
        SceneManager.LoadScene("Zukan hiden");
    }
}
