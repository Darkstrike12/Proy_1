using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLimit : MonoBehaviour
{
    [SerializeField] bool ReestartLevel;
    [SerializeField] bool DestroyCollidingObject;
    [SerializeField] bool Visible;

    private void Awake()
    {
        if(!Visible)
        {

        }
        else
        {

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && ReestartLevel)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (DestroyCollidingObject)
        {
            Destroy(collision.gameObject);
        }
    }
}
