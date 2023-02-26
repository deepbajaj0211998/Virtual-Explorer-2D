using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class psword : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int swordDamage = 10;
    public float swordCooldown = 1.0f;
    public GameObject swordPrefab;
    public float swordOffset = 1.0f;

    private bool canAttack = true;
    private Animator animator;
    private GameObject sword;
    private Vector3 mousePos;

    private void Start()
    {
        animator = GetComponent<Animator>();
        sword = Instantiate(swordPrefab, transform.position, Quaternion.identity);
        sword.transform.parent = transform;
        sword.transform.localPosition = new Vector3(swordOffset, 0, 0);
    }

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        sword.transform.right = mousePos - transform.position;

        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            animator.SetTrigger("Attack");
            Attack();
            canAttack = false;
            Invoke("ResetAttack", swordCooldown);
        }
    }

    private void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            // Deal damage to enemy
            enemy.GetComponent<enemy1>().TakeDamage(swordDamage);
        }
    }

    private void ResetAttack()
    {
        canAttack = true;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
