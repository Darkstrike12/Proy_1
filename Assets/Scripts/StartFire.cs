using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class StartFire : MonoBehaviour
{
    private Animator animator;
    public GameObject Fire;
    private PolygonCollider2D poly;
    private float timer, crono;
    // Start is called before the first frame update
    void Start()
    {
        poly = Fire.GetComponent<PolygonCollider2D>();
        animator = GetComponent<Animator>();
        poly.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        crono += Time.deltaTime;
        timer += Time.deltaTime;

        if (timer >= 3)
        {
            animator.SetBool("Start", true);
            poly.enabled = true;
            Cronometro();
            timer = 0;
        }
    }
    private void Cronometro()
    {
        if (crono >= 6)
        {
            animator.SetBool("Start", false);
            poly.enabled = false;
            crono = 0;
        }


    }
}
