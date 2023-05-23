using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBasic_Movement : MonoBehaviour
{
    public bool Fase2 = false;
    public GameObject[] positioner;
    public GameObject Player;
    public GameObject Slime;
    private int currentPositionIndex = 0;
    public float speed = 3f;
    public float CurrentX = 1;

    // Update is called once per frame
    void Update()
    {
        if(Fase2 == false) {
            if (Vector2.Distance(positioner[currentPositionIndex].transform.position, transform.position) < .1f)
            {
                currentPositionIndex++;
                if (currentPositionIndex >= positioner.Length)
                {
                    currentPositionIndex = 0;
                }
                flip();
            }
            transform.position = Vector2.MoveTowards(transform.position, positioner[currentPositionIndex].transform.position, Time.deltaTime * speed);
        }
        else if(Fase2 == true)
        {
            Vector3 Pposition = Player.transform.position;
            CurrentX = Player.transform.position.x - Slime.transform.position.x;
            if(CurrentX < 0)
            {
                Vector3 Flip = Slime.transform.localScale;
                Flip.x = -1;
                Slime.transform.localScale = Flip;
            }
            else
            {
                Vector3 Flip = Slime.transform.localScale;
                Flip.x = 1;
                Slime.transform.localScale = Flip;
            }
            Slime.transform.position = Vector3.MoveTowards(Slime.transform.position, Pposition, Time.deltaTime * speed);
        }
    
    }
    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
