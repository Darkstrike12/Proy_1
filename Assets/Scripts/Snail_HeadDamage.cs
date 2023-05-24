using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail_HeadDamage : MonoBehaviour
{
    private Animator animator;
    public GameObject Snail;
    public int hit = 1;
    // Start is called before the first frame update
    void Start()
    {
        animator = Snail.GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
 
        if(collision.gameObject.tag == "Player")
        {
        animator.SetTrigger("Hit");
        StartCoroutine("Timer");
        if (collision.gameObject.tag == "Player" && hit == 2)
        {
            animator.SetTrigger("Death");
            StartCoroutine("Crono");
        }
        hit++;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(.2f);
        animator.SetTrigger("Walk");
    }
    IEnumerator Crono()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(Snail.gameObject);
    }
}
