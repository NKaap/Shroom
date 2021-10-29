using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towers : MonoBehaviour {
    [SerializeField] private Animator animationController;

    public float maxHealth = 100;
    public float currentHealth;
    public float attackCoolDown;
    public float particleCooldown;
    public int dmgToDo;
    public int costs;
    public bool isAttacking;
    public GameObject particle;
    private bool spawnParticle = false;
    public List<EnemyProperties> enemies = new List<EnemyProperties>();
    private GameObject newParticle;
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
            if (isAttacking) {
                StartCoroutine(SetAttackToFalse());
                StartCoroutine(PlayParticle());
            }
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
    IEnumerator PlayParticle() {
        yield return new WaitForSeconds(1f);
        particle.SetActive(true);
        yield return new WaitForSeconds(particleCooldown);
        particle.SetActive(false);
    }
    //dit doet damage aan alle enemies die in de trigger zitten door ze in de lijst te zien staan
    public virtual void DoDamage() {
        for (int i = 0; i < enemies.Count; i++) {
            enemies[i].DoDamage(dmgToDo, this);
        }
    }
    //dit switched de state naar attack en voegt de enemie toe aan de lijst die hier boven word gebruikt
    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("enemy")) {
            animationController.SetBool("Attack", true);
            if (!isAttacking) {
                isAttacking = true;
                SetState(TowerState.Attack);
            }
            enemies.Add(other.gameObject.GetComponent<EnemyProperties>());
        }
    }
    //dit switched de state weer terug naar idle en het verwijderd de enemie weer uit de lijst
    public void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("enemy")) {
            particle.SetActive(false);
            enemies.Remove(other.gameObject.GetComponent<EnemyProperties>());
            if (enemies.Count == 0) {
                animationController.SetBool("Attack", false);
                SetState(TowerState.Idle);
                isAttacking = false;
            }
        }
    }
    //dit removed ook de enemie uit de lijst, dit word alleen aangeroepen als de enemie dood gaat
    public void RemoveEnemy(EnemyProperties enemy) {
        enemies.Remove(enemy);
    }
}
