using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball_Normal : MonoBehaviour
{
    //[SerializeField] GameObject player;
    [SerializeField] float FireballSpeed;
    Animator animator;
    Rigidbody2D rigidbody;
    CircleCollider2D CircleCollider;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        CircleCollider = GetComponent<CircleCollider2D>();

        ShootSpeed(FireballSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Jefe_ww"))
        {
            StartCoroutine(IgnoreBoss(CircleCollider));
        }
        else 
        {
            animator.SetTrigger("Hit");
            if (collision.collider.CompareTag("Player"))
            {
                Debug.Log("HitPlayer");
            }
            
        }
    }

    IEnumerator IgnoreBoss(CircleCollider2D collider)
    {
        collider.isTrigger = true;
        yield return new WaitForSeconds(0.01f);
        collider.isTrigger = false;
    }

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
