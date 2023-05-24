using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class LevelLimit : MonoBehaviour
{
    [SerializeField] bool RestartLevel;
    [SerializeField] bool DestroyCollidingObject;
    [SerializeField] bool Visible;

    TilemapRenderer tileRender;

    private void Awake()
    {
        tileRender = GetComponent<TilemapRenderer>();
        if(!Visible)
        {
            tileRender.enabled = false;
        }
        else
        {
            tileRender.enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && RestartLevel)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (DestroyCollidingObject)
        {
            Destroy(collision.gameObject);
        }
    }
}
