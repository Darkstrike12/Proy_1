using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jefeww_Shoot_BH : StateMachineBehaviour
{
    JefeWW jefe;
    //[SerializeField] public int ShootingTimes;
    //int ShootCounter;
    [SerializeField] GameObject FireballPrefab;

    IEnumerator ShootMultipleTimes (GameObject fireballPrefab)
    {
        Instantiate(fireballPrefab, jefe.ShootControler.transform.position, jefe.ShootControler.transform.rotation);
        yield return new WaitForSeconds(0.4f);
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        jefe = animator.GetComponent<JefeWW>();
        jefe.FacePlayer();
        if (animator.GetInteger("ShootCounter") <= 0)
        {
            animator.SetTrigger("ShootEnd");
            animator.ResetTrigger("ShootStart");
        }
        else
        {
            Instantiate(FireballPrefab, jefe.ShootControler.transform.position, jefe.ShootControler.transform.rotation);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("ShootCounter", animator.GetInteger("ShootCounter") - 1);
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
