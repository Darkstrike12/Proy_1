using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball_Normal : MonoBehaviour
{
    VidaSocial PlayerLife;

    [Header("Parameters")]
    [SerializeField] float FireballSpeed;
    [SerializeField] float Damage;
    

    [Header("Lifetime")]
    [SerializeField] float LifeTime;
    [SerializeField] bool UseLifetime;
    Animator animator;
    new Rigidbody2D rigidbody;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        ShootSpeed(FireballSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (UseLifetime) Destroy(gameObject, LifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetTrigger("Hit");
        if (collision.collider.CompareTag("Player"))
        {
            PlayerLife = collision.gameObject.GetComponent<VidaSocial>();
            PlayerLife.TakeDamage(Damage);
        }
    }

    /*
    IEnumerator IgnoreBoss(CircleCollider2D collider)
    {
        collider.isTrigger = true;
        yield return new WaitForSeconds(0.01f);
        collider.isTrigger = false;
    }
    */

    void ShootSpeed(float Speed)
    {
        rigidbody.velocity = new Vector2(rigidbody.velocity.x + Speed, rigidbody.velocity.y + Speed) * transform.right;
    }

    void SetRigidbodyStatic()
    {
        rigidbody.bodyType = RigidbodyType2D.Static;
    }

    void DestryFireball()
    {
        Destroy(gameObject);
    }
}
