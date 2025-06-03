using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Mathematics;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    Vector3 pos;
    Vector3 child_pos;
    private Rigidbody2D rb;
    private GameManager_game gameManager;

    public string CharaName;
    public int hp;
    public int attack;
    public int strength;
    public int MoveSpeed;
    public int AttackSpeed;
    public int AttackRange;
    public int AttackingTime;       // 攻撃開始してからモーションが終わるまでの時間
    public bool TeamRed;
    public int cost;
    public float accelerat;
    public float hanteikakudai = 1.0f;

    // 以下は状態に関する変数
    public bool walking = true;
    public bool idleing = false;
    private bool death = false;
    private float Attacking;        // 攻撃開始してからどれくらい時間がたったか
    private bool NowAttacking = false;
    private float invincibility = 0.0f; //無敵時間
    public bool isAttack = false;
    

    public float Move;
    
    private float AttackCooldown;

    private GameObject parentObj;
    private GameObject SearchArea;
    [SerializeField] GameObject AttackArea;
    Animator animator;
    [SerializeField] GameObject child;
    [SerializeField] GameObject childSub;
    [SerializeField] GameObject halo;
    public bool isAttack2 = false;
    public bool is3 = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        pos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        SpriteRenderer[] spriteRenderer = GetComponentsInChildren<SpriteRenderer>();
        gameManager = GetComponent<GameManager_game>();
        SearchArea = transform.Find("search_area").gameObject;
        child_pos = SearchArea.transform.position;

        AttackCooldown = 0.0f;
        Attacking = AttackingTime;

        parentObj = transform.parent.gameObject;
        if(parentObj.name == "team_red_monster"){
            TeamRed = true;
            child_pos.x += AttackRange * 0.003f;
            gameObject.tag = "TeamRed";
            gameObject.layer = 15;
        }else{
            TeamRed = false;
            if(childSub == null)
            {
                foreach(SpriteRenderer child in spriteRenderer)
                {
                    child.flipX = true;
                }
            }
            child_pos.x -= AttackRange * 0.003f;
            gameObject.tag = "TeamBlue";
            gameObject.layer = 16;
        }
        if(childSub != null && parentObj.name != "team_red_monster")
        {
            childSub.transform.localScale = new Vector2(childSub.transform.localScale.x * -1, childSub.transform.localScale.y);
        }

        SearchArea.transform.position = child_pos;
        AttackArea.transform.position = child_pos;

        SearchArea.transform.localScale = SearchArea.transform.localScale * hanteikakudai;
        AttackArea.transform.localScale = AttackArea.transform.localScale * hanteikakudai;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = rb.velocity;
        Move = 0.0f;
        invincibility -= Time.deltaTime;

        AttackCooldown -= Time.deltaTime * 60.0f;
        Attacking += Time.deltaTime * 60.0f;

        if(invincibility <= 0.0f)
        {
            foreach(Renderer child in GetComponentsInChildren<Renderer>())
            {
                child.material.color = Color.white;
            }
        }
        if(hp <= 0)
        {
            death = true;
        }
        if(Attacking < AttackingTime){
            NowAttacking = true;
        } else {
            NowAttacking = false;
        }
        if(walking && !death && !StartTimer.isWait)
        {
            if(TeamRed && velocity.x < MoveSpeed * 0.03f){
                Move += accelerat * Time.deltaTime * 0.03f;
            } else if (velocity.x > MoveSpeed * 0.03f * -1){
                Move -= accelerat * Time.deltaTime * 0.03f;
            }
            Vector2 force = new Vector2(Move, 0);
            // Debug.Log(velocity.x);
            rb.AddForce(force);
        } else if(!death){
            Vector2 force = new Vector2(velocity.x * -0.4f, velocity.y * -0.4f);
            // Debug.Log(velocity.x);
            rb.AddForce(force, ForceMode2D.Impulse);
        }
        if ((isAttack || (Input.GetKey(KeyCode.Space) && GameManager_game.debug)) || isAttack2 && !death)    // 敵が攻撃範囲内に存在する場合
        {
            walking = false;
            if(AttackCooldown <= 0.0f)
            {
                idleing = false;
                animator.SetTrigger("attack");
                if(child != null)
                {
                    child.GetComponent<Animator>().SetTrigger("attack");
                }
                AttackCooldown = AttackSpeed;
                Attacking = 0.0f;
            }
            if(!NowAttacking)
            {
                idleing = true;
            }
        } else if (!NowAttacking && !death)
        {
            walking = true;
            idleing = false;
        }
        if (NowAttacking && !death)
        {
            walking = false;
            idleing = false;
        }
        if(StartTimer.isWait)
        {
            idleing = true;
            walking = false;
        }
        if(death)
        {
            if(halo != null)
            {
                GameObject Halo = Instantiate(halo, new Vector3(transform.position.x, transform.position.y+0.3f, 0), quaternion.identity);
            }
            Destroy(gameObject);
        }
        if(is3)
        {
            idleing = true;
            walking = false;
        }
        animator.SetBool("walk", walking);
        animator.SetBool("idle", idleing);
        if(child != null)
        {
            child.GetComponent<Animator>().SetBool("walk", walking);
            child.GetComponent<Animator>().SetBool("idle", idleing);
        }
        if(isAttack2)
        {
            AttackCooldown = 0.0f;
        }
        isAttack2 = false;
        is3 = false;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if((gameObject.tag == "TeamRed" && other.tag == "TeamBlueAttack") || (gameObject.tag == "TeamBlue" && other.tag == "TeamRedAttack"))
        {
            if(invincibility <= 0.0f)
            {
                attack_area hitObject = other.GetComponent<attack_area>();
                GetComponent<Renderer>().material.color = Color.red;
                foreach(Renderer child in GetComponentsInChildren<Renderer>())
                {
                    child.material.color = Color.red;
                }
                invincibility = 0.1f;
                hp -= hitObject.attack;
            }
        }
    }
}