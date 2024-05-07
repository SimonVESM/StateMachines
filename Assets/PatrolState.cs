using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PatrolState : StateMachineBehaviour
{
    [SerializeField]
    float rotationSpeed = 5f;
    public GameObject gameObject;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponentInChildren<Renderer>().material.color = Color.green;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    bool SeeEnemy(Animator animator)
    {
        bool result = false;
        RaycastHit hit;
        float viewDistance = 12;

        if (Physics.Raycast(animator.transform.position, animator.transform.forward, out hit, viewDistance))
        {
            if (hit.transform.tag == "Player")
            {
                result = true;
            }
        }

        return result;
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

