using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Jefeww_Run_BH : StateMachineBehaviour
{
    private JefeWW jefe;
    Rigidbody2D rigidbody;
    [SerializeField] float MovementSpeed;
    [SerializeField] float RunningTime;
    float CurrentRunningTime;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        jefe = animator.GetComponent<JefeWW>();
        rigidbody = jefe.GetComponentInParent<Rigidbody2D>();
        CurrentRunningTime = RunningTime;

        jefe.FacePlayer();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.transform.position = Vector2.MoveTowards(animator.transform.position, jefe.Player.position, MovementSpeed * Time.deltaTime);
        rigidbody.velocity = new Vector2(MovementSpeed, rigidbody.velocity.y) * animator.transform.right;
        CurrentRunningTime -= Time.deltaTime;
        //Debug.Log("Running Timer" + CurrentRunningTime);
        if (CurrentRunningTime <= 0)
        {
            animator.SetTrigger("Stun");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rigidbody.velocity = new Vector2(0f, rigidbody.velocity.y);
        animator.SetBool("RunStart", false);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
