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
    public bool isAttacking;
    public List<EnemyProperties> enemies = new List<EnemyProperties>(); 

    public void Update() {
        if (enemies.Count == 0) {
            animationController.SetBool("Attack", false);
            SetState(TowerState.Idle);
            isAttacking = false;
        }
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
        for (int i = 0; i < enemies.Count; i++) {
            enemies[i].DoDamage(dmgToDo, this);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("enemy")) {
            animationController.SetBool("Attack", true);
            if (!isAttacking) {
                SetState(TowerState.Attack);
                isAttacking = true;
            }
            enemies.Add(other.gameObject.GetComponent<EnemyProperties>());
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("enemy")) {
            animationController.SetBool("Attack", false);
            SetState(TowerState.Idle);
            enemies.Remove(other.gameObject.GetComponent<EnemyProperties>());
        }
    }
    public void RemoveEnemy(EnemyProperties enemy) {
        enemies.Remove(enemy);
    }
}
