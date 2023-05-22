using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class JefeWW : MonoBehaviour
{
    [Header("Referencias Externas")]
    [SerializeField] public GameObject Player;
    [SerializeField] public GameObject ShootControler;

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
    [SerializeField] public int MaxShootingTimes;

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
        Distance = Vector2.Distance(transform.position, Player.transform.position);
        //ShootAngle = Mathf.Atan2(BulletDirection.x, BulletDirection.y) * Mathf.Rad2Deg;
        //ShootControler.transform.position = Quaternion.Euler(Vector3.forward * ShootAngle);
        ShootControler.transform.right = Player.transform.position - ShootControler.transform.position;
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
                Debug.Log("Collision Corriendo");
            }
        }
    }

    public void FacePlayer()
    {
        if ((Player.transform.position.x > transform.position.x && !FaceRight) || (Player.transform.position.x < transform.position.x && FaceRight))
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
