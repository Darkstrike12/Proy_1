using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_Movement : MonoBehaviour
{
    public GameObject Player;
    public GameObject Active;
    private Animator animator;
    public float speed = 3f;
    private float CurrentX = 1;
    // Start is called before the first frame update
    void Start()
    {
        animator = Active.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distancia = Vector2.Distance(Active.transform.position, Player.transform.position);
        if (distancia >= 20)
        {
            animator.SetTrigger("Desappear");
            StartCoroutine("Cron");
        }
        else
        {
                Active.gameObject.SetActive(true);
                animator.SetTrigger("Appear");
                StartCoroutine("Timer");
                CurrentX = Player.transform.position.x - Active.transform.position.x;
                if (CurrentX < 0)
                {
                    Vector3 Flip = Active.transform.localScale;
                    Flip.x = 1;
                    Active.transform.localScale = Flip;
                }
                else
                {
                    Vector3 Flip = Active.transform.localScale;
                    Flip.x = -1;
                    Active.transform.localScale = Flip;
                }
                Active.transform.position = Vector3.MoveTowards(Active.transform.position, Player.transform.position, Time.deltaTime * speed);
        }
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(.25f);
        animator.SetTrigger("Move");
    }
    IEnumerator Cron()
    {
        yield return new WaitForSeconds(.25f);
        animator.SetTrigger("Idle");
        Active.gameObject.SetActive(false);

    }
}
