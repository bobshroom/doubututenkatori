using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player_move_test : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject gamane;
    Vector3 pos;
    private GameManager_game gameManager;
    private Rigidbody2D rb;
    [SerializeField] private List<UnityEngine.KeyCode> KeyList = new List<UnityEngine.KeyCode>();   // 右、左、上、下
    int move_speed;
    [SerializeField] float brake;
    private Vector2 force;
    void Start()
    {
        pos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        gameManager = gamane.GetComponent<GameManager_game>();
    }

    // Update is called once per frame
    void Update()
    {
        float speedBairitu = 1.0f;
        if(GameManager_game.debug)
        {
            speedBairitu = 5.0f;
        }
        if(gameManager.isforced) // もしGameManager_gameの強制設定がtrueならステータスをそれに変更する
        {
            move_speed = gameManager.move_speed;
            brake = gameManager.brake;
        }


        Vector2 velocity = rb.velocity;
        force = new Vector2(0, 0);
        //移動に関するプログラム
        if(Input.GetKey(KeyList[0])){ //右移動
            if(velocity.x < move_speed * 0.01f * speedBairitu)
            {
            force = new Vector2(move_speed * 2.5f * Time.deltaTime, 0);
            }
        }
        else if(velocity.x > 0.0f)
        {
            rb.AddForce(new Vector2(-velocity.x * brake, 0), ForceMode2D.Impulse);
        }
        if(Input.GetKey(KeyList[1])){ //左移動
            if(-velocity.x < move_speed * 0.01f * speedBairitu)
            force = new Vector2(-move_speed * 2.5f * Time.deltaTime, 0);
        }
        else if(velocity.x < 0.0f)
        {
            rb.AddForce(new Vector2(-velocity.x * brake, 0), ForceMode2D.Impulse);
        }
        if(Input.GetKey(KeyList[2])){ //上移動
            if(velocity.y < move_speed * 0.01f * speedBairitu)
            force = new Vector2(0, move_speed * 2.5f * Time.deltaTime);
        }
        else if(velocity.y > 0.0f)
        {
            rb.AddForce(new Vector2(0, -velocity.y * brake), ForceMode2D.Impulse);
        }
        if(Input.GetKey(KeyList[3])){ //下移動
            if(-velocity.y < move_speed * 0.01f * speedBairitu)
            force = new Vector2(0, -move_speed * 2.5f * Time.deltaTime);
        }
        else if(velocity.y < 0.0f)
        {
            rb.AddForce(new Vector2(0, -velocity.y * brake), ForceMode2D.Impulse);
        }



        rb.AddForce(force);
    }
}
