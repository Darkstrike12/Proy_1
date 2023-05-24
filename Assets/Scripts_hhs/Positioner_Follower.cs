using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Positioner_Follower : MonoBehaviour
{
    public GameObject[] positioner;
    private int currentPositionIndex = 0;
    public float speed = 3f;


    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(positioner[currentPositionIndex].transform.position, transform.position) < .1f)
        {
            currentPositionIndex++;
            if(currentPositionIndex >= positioner.Length)
            {
                currentPositionIndex = 0;
            }  
        }
        transform.position = Vector2.MoveTowards(transform.position, positioner[currentPositionIndex].transform.position, Time.deltaTime * speed);
    }
}
