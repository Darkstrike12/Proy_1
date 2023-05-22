using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class JefeWW : MonoBehaviour
{
    [Header("Referencias Externas")]
    [SerializeField] public GameObject Player;
    [SerializeField] public GameObject ShootControler;
    VidaSocial PlayerLife;

    [Header("Variables")] 
    [SerializeField] public float Distance;
    [SerializeField] public bool AllowTakeDamage;
    bool FaceRight = true;
    Animator animator;
    Rigidbody2D rigidbody;

    [Header("Ataque")]
    [HideInInspector] public int AttkOrder;
    [SerializeField] public float AttkTimer;
    [SerializeField] public float CurrentAttkTimer;
    [SerializeField] public int MaxShootingTimes;
    [Range(0f, 100f)]
    [SerializeField] float TackleDamage;

    [Header("Vida Jefe")]
    //[Range(1,20)]
    [SerializeField] int BossMaxLife;
    [SerializeField] int BossCurrentLife;
    [SerializeField] int BossDmgTaken;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        PlayerLife = Player.GetComponent<VidaSocial>();
        CurrentAttkTimer = AttkTimer;
        BossCurrentLife = BossMaxLife;
    }
    
    void Update()
    {
        Distance = Vector2.Distance(transform.position, Player.transform.position);
        ShootControler.transform.right = Player.transform.position - ShootControler.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if(AllowTakeDamage)
            {
                TakeDamage(BossDmgTaken);
            }
            if (animator.GetBool("RunStart"))
            {
                PlayerLife.TakeDamage(TackleDamage);
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

    public void SetRigidbodyStatic()
    {
        rigidbody.bodyType = RigidbodyType2D.Static;
    }

    public void SetRigidbodyDynamic()
    {
        rigidbody.bodyType = RigidbodyType2D.Dynamic;
    }

    void TakeDamage(int Damage)
    {
        BossCurrentLife -= Damage;
        Debug.Log("Boss Life: " + BossCurrentLife);
        animator.SetTrigger("Hurt");
        if(BossCurrentLife <= 0)
        {
            Debug.Log("Derrotado");
            rigidbody.bodyType = RigidbodyType2D.Static;
            animator.SetTrigger("Death");
        }
    }
}
