using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Vulture : MonoBehaviour
{
    [SerializeField] public Transform Player;
    [SerializeField] private float distancia;
    public Vector3 PuntoInicial;
    private Animator animator;
    public float speed = 3f;
    private float CurrentX = 1;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        PuntoInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distancia = Vector2.Distance(gameObject.transform.position, Player.position);
        animator.SetFloat("Distancia", distancia);
        CurrentX = Player.transform.position.x - gameObject.transform.position.x;
        if (CurrentX <= 0)
        { 
            Vector3 Flip = gameObject.transform.localScale;
            Flip.x = -1;
            gameObject.transform.localScale = Flip;
        }
        else
        {
            Vector3 Flip = gameObject.transform.localScale;
            Flip.x = 1;
            gameObject.transform.localScale = Flip;
        } 
        Seguir();

    }

    private void Seguir() {
        if(distancia <= 11) {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Player.position, Time.deltaTime * speed);
            animator.SetBool("Origen", false);
        }
        else
        {
            Vector3 Voltear = gameObject.transform.localScale;
            Voltear.x = Voltear.x * -1;
            gameObject.transform.localScale = Voltear;
            transform.position = Vector3.MoveTowards(transform.position, PuntoInicial, Time.deltaTime * speed);
            if (PuntoInicial == gameObject.transform.position)
            {
                if (CurrentX <= 0)
                {
                    Vector3 Flip = gameObject.transform.localScale;
                    Flip.x = -1;
                    gameObject.transform.localScale = Flip;
                }
                else
                {
                    Vector3 Flip = gameObject.transform.localScale;
                    Flip.x = 1;
                    gameObject.transform.localScale = Flip;
                }
                animator.SetBool("Origen", true);
            }

        }
    }

}
