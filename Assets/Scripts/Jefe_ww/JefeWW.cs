using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeWW : MonoBehaviour
{
    [Header("Referencias Externas")]
    [SerializeField] public Transform Player;

    [Header("Variables")] 
    [SerializeField] public float Distance;
    bool FaceRight = true;
    Animator animator;
    SpriteRenderer spriteRenderer;

    [Header("Ataque")]
    [SerializeField] float AttkTimer;
    [SerializeField] float CurrentAttkTimer;
    [SerializeField] int AttkOrder;

    [Header("Vida Jefe")]
    //[Range(1,20)]
    [SerializeField] int BossMaxLife;
    [SerializeField] int BossDmgTaken;
    [SerializeField] int BossCurrentLife;
    
    void Start()
    {
        animator= GetComponent<Animator>();
        spriteRenderer= GetComponent<SpriteRenderer>();
        AttkTimer = CurrentAttkTimer;
        BossMaxLife = BossCurrentLife;
    }
    
    void Update()
    {
        Distance = Vector2.Distance(transform.position, Player.position);
        CurrentAttkTimer -= Time.deltaTime;
        //FacePlayer();

        switch ( AttkOrder )
        {
            case 1:
                animator.SetTrigger("RunStart");
                break;
        }
    }

    public void FacePlayer()
    {
        if ((Player.position.x > transform.position.x && !FaceRight) || (Player.position.x < transform.position.x && FaceRight))
        {
            FaceRight = !FaceRight;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }

    void BossDeath()
    {

    }

    void TakeDamage(int value)
    {
        BossCurrentLife -= value;
    }
}
