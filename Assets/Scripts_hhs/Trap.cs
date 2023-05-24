using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trap : MonoBehaviour
{
    [SerializeField] bool InstaKill;
    [SerializeField] float Damage;
    VidaSocial PlayerLife;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (InstaKill)
            {
                Debug.Log("InstaKill");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                PlayerLife = collision.gameObject.GetComponent<VidaSocial>();
                PlayerLife.TakeDamage(Damage);
            }
        }
    }
}
