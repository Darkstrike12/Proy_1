using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jefeww_Special_Shoot_BH : StateMachineBehaviour
{
    JefeWW jefe;
    [SerializeField] GameObject FireballPrefab;
    [SerializeField] float ShootTime;
    float CurrentShootTime;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        jefe = animator.GetComponent<JefeWW>();
        CurrentShootTime = ShootTime;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        jefe.FacePlayer();
        Instantiate(FireballPrefab, jefe.ShootControler.transform.position, jefe.ShootControler.transform.rotation);
        CurrentShootTime -= Time.deltaTime;
        if(CurrentShootTime <=0 )
        {
            animator.SetTrigger("Stun");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
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
