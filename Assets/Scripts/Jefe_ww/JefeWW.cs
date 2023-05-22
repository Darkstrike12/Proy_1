using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JefeWW : MonoBehaviour
{
    [Header("Referencias Externas")]
    [SerializeField] public Transform Player;

    [Header("Variables")] 
    [SerializeField] public float Distance;
    [SerializeField] public bool AllowDamage;
    bool FaceRight = true;
    Animator animator;
    Rigidbody2D rigidbody;

    [Header("Ataque")]
    [SerializeField] public float AttkTimer;
    [SerializeField] public float CurrentAttkTimer;
    [SerializeField] public int AttkOrder;

    [Header("Vida Jefe")]
    //[Range(1,20)]
    [SerializeField] int BossMaxLife;
    [SerializeField] int BossCurrentLife;
    [SerializeField] int BossDmgTaken;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        CurrentAttkTimer = AttkTimer;
        BossCurrentLife = BossMaxLife;
    }
    
    void Update()
    {
        Distance = Vector2.Distance(transform.position, Player.position);
        //CurrentAttkTimer -= Time.deltaTime;
        /*
        if(CurrentAttkTimer <= 0)
        {
            AttkOrder = animator.GetInteger("AttackOrder");
            switch (AttkOrder)
            {
                case 1: case 2: case 3: case 4: case 5:
                    //Correr
                    animator.SetBool("RunStart", true);
                    break;
                case 6: case 7: case 8:
                    //Disparo Normal
                    animator.SetTrigger("ShootStart");
                    break;
                case 9: case 10:
                    //Disparo Especial
                    animator.SetTrigger("SpecialShoot");
                    break;
            }
            //CurrentAttkTimer = AttkTimer;
            animator.ResetTrigger("Hurt");
        }
        */
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if(AllowDamage)
            {
                TakeDamage(BossDmgTaken);
            }
            if (animator.GetBool("RunStart"))
            {
                //Debug.Log("Collision Corriendo");
            }
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
        animator.SetTrigger("Death");
    }

    void DestroyBosss()
    {
        Destroy(gameObject);
    }

    void TakeDamage(int Damage)
    {
        BossCurrentLife -= Damage;
        Debug.Log("Boss Life" + BossCurrentLife);
        animator.SetTrigger("Hurt");
        if(BossCurrentLife <= 0)
        {
            Debug.Log("Derrotado");
            rigidbody.bodyType = RigidbodyType2D.Static;
            animator.SetTrigger("Death");
        }
    }
}
