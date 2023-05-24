using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_HeadDamage : MonoBehaviour
{
    private Animator animator;
    public GameObject Ghost;

    // Start is called before the first frame update
    void Start()
    {
        animator = Ghost.GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            animator.SetTrigger("Hit");
            StartCoroutine("Timer");
        }
    }
    IEnumerator Timer()
    {

        yield return new WaitForSeconds(.5f);
        AudioManager.instance.PlayEnvironmentSfx("Enemy_Die");
        animator.SetTrigger("Death");
        yield return new WaitForSeconds(.5f);
        Destroy(Ghost.gameObject);
    }
}
