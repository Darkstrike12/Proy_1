using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jefeww_Idle_BH : StateMachineBehaviour
{
    private JefeWW jefe;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        jefe = animator.GetComponent<JefeWW>();
        jefe.CurrentAttkTimer = jefe.AttkTimer;
        animator.SetInteger("AttackOrder", Random.Range(1, 11));
        animator.SetInteger("ShootingTimes", Random.Range(1, jefe.MaxShootingTimes + 1));
        animator.SetInteger("ShootCounter", animator.GetInteger("ShootingTimes"));
        animator.ResetTrigger("ShootEnd");
        AudioManager.instance.PlayEnvironmentSfx("Boss_Idle");
        //jefe.FacePlayer();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        jefe.FacePlayer();
        jefe.CurrentAttkTimer -= Time.deltaTime;
        if (jefe.CurrentAttkTimer <= 0)
        {
            jefe.AttkOrder = animator.GetInteger("AttackOrder");
            switch (jefe.AttkOrder)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    //Correr
                    animator.SetBool("RunStart", true);
                    break;
                case 6:
                case 7:
                case 8:
                    //Disparo Normal
                    animator.SetTrigger("ShootStart");
                    break;
                case 9:
                case 10:
                    //Disparo Especial
                    animator.SetTrigger("SpecialShoot");
                    break;
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
