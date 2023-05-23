using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shoting : MonoBehaviour
{
    public GameObject Bullet;
    public Transform bulletPos;
    private GameObject Player;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        float distancia = Vector2.Distance(transform.position, Player.transform.position);

        if(distancia >= 11 ) {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                timer = 0;
                Shoot();
            }
        }

    }
    private void Shoot()
    {
        Instantiate(Bullet, bulletPos.position, Quaternion.identity);
    }
}
