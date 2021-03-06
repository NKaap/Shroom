using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehavior : StateMachineBehaviour
{
    public bool attackEnemy;
    //public GameObject tower;
    public int dmgDone;
    public float attackCoolDown;

    public EnemyProperties enemyProperties;
    public Towers tower;

    private Animator animator;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator newAnimator, AnimatorStateInfo stateInfo, int layerIndex) {
        //animator = newAnimator;
        //int iD = Animator.StringToHash("AD");
        //tower.DoDamage();
        //animator.SetBool("DoDmg", true);
        //CoRoutineCreator.coRoutineCreator.StartCoroutine(SetAttackToFalse());




        ////Debug.Log(animator.GetCurrentAnimatorStateInfo(layerIndex).shortNameHash);
        ////Debug.Log(stateInfo.tag);
        //Debug.Log(iD.ToString() + ", " + stateInfo.nameHash.ToString());
        //if (stateInfo.IsTag("hoi")) {
        //    Debug.Log("Starte");
        //    if (tower.enemy == null) {
        //        Debug.Log("Apply damge");
        //        animator.SetTrigger("NoEnemy");
        //        return;
        //    }
        //    Debug.Log("Doing damage");
            
        //}
    }

    IEnumerator SetAttackToFalse() {
        yield return new WaitForSeconds(attackCoolDown);
        animator.SetBool("DoDmg", false);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
       // enemyProperties.enemyHealth -= tower.dmgToDo;
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
