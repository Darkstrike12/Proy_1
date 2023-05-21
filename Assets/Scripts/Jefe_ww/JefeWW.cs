using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeWW : MonoBehaviour
{
    [Header("Referencias Externas")]
    [SerializeField] public Transform Player;

    [Header("Variables")] 
    [SerializeField] float Distance;
    Animator animator;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidbody2D;

    [Space]
    //[Range(1,20)]
    [SerializeField] int BossMaxLife;
    [SerializeField] int BossDmgTaken;
    [SerializeField] int BossCurrentLife;
    
    void Start()
    {
        animator= GetComponent<Animator>();
        spriteRenderer= GetComponent<SpriteRenderer>();
        rigidbody2D= GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        Distance = Vector2.Distance(transform.position, Player.position);
        //FacePlayer(Player.position);
    }

    public void FacePlayer(Vector3 Objective)
    {
        if (transform.position.x > Objective.x)
        {
            //spriteRenderer.flipX= true;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
        else
        {
            spriteRenderer.flipX= false;
        }
    }

    void BossDeath()
    {

    }
}
