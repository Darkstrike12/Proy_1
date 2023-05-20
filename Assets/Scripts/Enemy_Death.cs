using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Death : MonoBehaviour
{
    public GameObject slime;
    private Animator animator;
    private PolygonCollider2D collider;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        animator = slime.GetComponent<Animator>();
        collider = slime.GetComponent<PolygonCollider2D>();
        rb = slime.GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.GetComponent<SlimeBasic_Movement>().Fase2 == false)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                rb.gravityScale = 0;
                animator.SetTrigger("Damaged");
            }
            if (collision.gameObject.tag == "Player")
            {

                collider.enabled = false;
                StartCoroutine("Timer");
            }
        }


    }
    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.8f);
        animator.SetTrigger("Killed");
        yield return new WaitForSeconds(0.4f);
        gameObject.GetComponent<SlimeBasic_Movement>().Fase2 = true;
        collider.enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        animator.SetTrigger("Fase2");
        rb.gravityScale = 2.5f;
    }
}
