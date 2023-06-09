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
        VidaActual = VidaMaxima;
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
        if (VidaActual > VidaMaxima)
        {
            VidaActual = VidaMaxima;
        }
        if (VidaActual <= 0)
        {
            animator.SetTrigger("Death");
            AudioManager.instance.PlayPlayerSfx("Player_Death");
            rb.bodyType = RigidbodyType2D.Static;
            return;
        }
    }

    public void TakeDamage(float DmgValue)
    {
        VidaActual -= DmgValue;
        animator.SetTrigger("hurt");
        AudioManager.instance.PlayPlayerSfx("Player_Hurt");
        Invoke("ResetHurtTrigger", 0.2f);
    }

    public void Heal(float HealValue)
    {
        VidaActual += HealValue;
    }

    public void Muerte()
    {
        //Destroy(gameObject);
        AudioManager.instance.PlayPlayerSfx("PLayer_Death");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
