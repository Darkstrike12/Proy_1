using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VidaSocial : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    public Image vida;
    public float VidaActual;
    public float VidaMaxima;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        vida.fillAmount = VidaActual / VidaMaxima;
        if (VidaActual > VidaMaxima)
        {
            VidaActual = VidaMaxima;
        }
        if (VidaActual <= 0)
        {
            animator.SetTrigger("Death");
            AudioManager.instance.PlayPlayerSfx("Player_Death");
            rb.bodyType = RigidbodyType2D.Static;
            VidaActual = 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            animator.SetTrigger("hurt");
            Invoke("ResetHurtTrigger", 0.2f);
            VidaActual = VidaActual - 25;
        }
        /*
        if (VidaActual <= 0)
        {
            animator.SetTrigger("Death");
            rb.bodyType = RigidbodyType2D.Static;
        }
        */

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("cherry"))
        {
            VidaActual = VidaActual + 10;
        }
    }

    public void TakeDamage(float DmgValue)
    {
        VidaActual -= DmgValue;
        animator.SetTrigger("hurt");
        AudioManager.instance.PlayPlayerSfx("Player_Hurt");
        Invoke("ResetHurtTrigger", 0.2f);
    }

    void ResetHurtTrigger()
    {
        animator.ResetTrigger("hurt");
    }

    public void Muerte()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
