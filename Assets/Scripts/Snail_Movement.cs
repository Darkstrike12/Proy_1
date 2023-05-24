using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail_Movement : MonoBehaviour
{
    public GameObject Player;
    public GameObject Run;
    public GameObject[] positioner;
    private int currentPositionIndex = 0;
    public float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
