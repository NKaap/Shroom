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
    //als de enimie lijst leeg is zet je de animatie weer op attack
    public void Update() {
        if (enemies.Count == 0) {
            animationController.SetBool("Attack", false);
            SetState(TowerState.Idle);
            isAttacking = false;
        }
    }
    //dit is gwn een lijst van de verschillende animaties
    public enum TowerState {
        Idle,
        Attack,
    }
    //dit triggert elke keer als de animatie switched en hij zet de iemurator aan, dit is een soort van wacht tijd
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
    //hier staat dus die wacht tijd en elke keer als de tijd is afgelopen attacked hij en doet hij de wacht tijd opniew tot de enemie dood is of uit de trigger is
    IEnumerator SetAttackToFalse() {
        yield return new WaitForSeconds(attackCoolDown);
        DoDamage();
        SetState(TowerState.Attack);
    }
    //dit doet damage aan alle enemies die in de trigger zitten door ze in de lijst te zien staan
    public virtual void DoDamage() {
        foreach (EnemyProperties enemy in enemies) {
            //enemy.DoDamage(dmgToDo, this);
        }
        enemies = new List<EnemyProperties>();
    }
    //dit switched de state naar attack en voegt de enemie toe aan de lijst die hier boven word gebruikt
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
    //dit switched de state weer terug naar idle en het verwijderd de enemie weer uit de lijst
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("enemy")) {
            if (enemies.Count == 0) {
                animationController.SetBool("Attack", false);
                SetState(TowerState.Idle);
                isAttacking = false;
            }
            enemies.Remove(other.gameObject.GetComponent<EnemyProperties>());
        }
    }
    //dit removed ook de enemie uit de lijst, dit word alleen aangeroepen als de enemie dood gaat
    public void RemoveEnemy(EnemyProperties enemy) {
        enemies.Remove(enemy);
    }
}
