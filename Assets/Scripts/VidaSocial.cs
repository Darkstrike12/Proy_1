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
    public AudioSource AudioHurt;
    public AudioSource AudioDeath;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            animator.SetTrigger("hurt");
            Invoke("ResetHurtTrigger", 0.2f);
            VidaActual = VidaActual -25;
            AudioHurt.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("cherry"))
        {
            VidaActual = VidaActual + 10;
        }
    }
   
    void ResetHurtTrigger()
    {
        animator.ResetTrigger("hurt");
    }

    void Update()
    {
        vida.fillAmount = VidaActual / VidaMaxima;
        if (VidaActual <= 0)
        {
            animator.SetTrigger("Death");
            rb.bodyType = RigidbodyType2D.Static;
            AudioDeath.Play();
        }
    }
    void Muerte()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
