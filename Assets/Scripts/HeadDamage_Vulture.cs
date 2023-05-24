using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadDamage_Vulture : MonoBehaviour
{
    private Animator animator;
    public GameObject vulture;
    public int damaged;

    // Start is called before the first frame update
    void Start()
    {
        animator = vulture.GetComponent<Animator>();
        damaged = 1;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player" && damaged == 2)
        {
            AudioManager.instance.PlayEnvironmentSfx("Enemy_Die");
            animator.SetTrigger("Killed");
            StartCoroutine("Timer");
        }
        else if(collision.gameObject.tag == "Player")
        {
            damaged++;
        }
    }
    IEnumerator Timer()
    {

        yield return new WaitForSeconds(.5f);
        Destroy(vulture.gameObject);
    }
}
