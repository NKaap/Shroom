using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towers : MonoBehaviour
{
    [SerializeField] private Animator animationController;

    public float maxHealth = 100;
    public float currentHealth;
    public float attackCoolDown;
    public int dmgToDo;
    public bool canAttack;
    public Transform enemy;
    public Animator animator;
    public void EnemyDied() {
            animationController.SetBool("Attack", false);
            SetState(TowerState.Idle);
    }

    public enum TowerState {
        Idle,
        Attack,
    }

    void SetState(TowerState newTowerState) {
        switch (newTowerState) {
            case TowerState.Attack:
            animationController.SetBool("DoDmg", true);
            StartCoroutine(SetAttackToFalse());
            break;
            case TowerState.Idle:
            animationController.SetBool("DoDmg", false);
            break;
        }
    }

    IEnumerator SetAttackToFalse() {
        yield return new WaitForSeconds(attackCoolDown);
        DoDamage();
        SetState(TowerState.Attack);
        
    }

    public virtual void DoDamage() {
        enemy.gameObject.GetComponent<EnemyProperties>().DoDamage(dmgToDo);

    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "enemy") {
            animationController.SetBool("Attack", true);
            enemy = other.transform;
            SetState(TowerState.Attack);
            print("het werkt");
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "enemy") {
            animationController.SetBool("Attack", false);
            SetState(TowerState.Idle);
            enemy = null;
        }
    }
}
