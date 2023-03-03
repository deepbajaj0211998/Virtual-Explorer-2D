using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class psword : MonoBehaviour
{
    public Transform attackPoint;
    bool fir=false;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int swordDamage = 100;
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
        sword=swordPrefab;
    }

    private void Update()
    {
        // mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // mousePos.z = 0;
        // sword.transform.right = mousePos - transform.position;
        if(GetComponent<SpriteRenderer>().flipX==false && fir==true)
        {
            Attack();
            sword.GetComponent<LineRenderer>().SetPosition(0,(Vector2)attackPoint.position);
            sword.GetComponent<LineRenderer>().SetPosition(1,(Vector2)attackPoint.position + new Vector2(4f,0f));
        }
        else if(fir==true)
        {
            Attack();
            sword.GetComponent<LineRenderer>().SetPosition(0,new Vector2(attackPoint.position.x-1,attackPoint.position.y));
            sword.GetComponent<LineRenderer>().SetPosition(1,new Vector2(attackPoint.position.x-5,attackPoint.position.y));
        }

        // if (Input.GetMouseButtonDown(0) && canAttack)
        // {
        //     //animator.SetTrigger("Attack");
        //     Attack();
        //     canAttack = false;
        //     Invoke("ResetAttack", swordCooldown);
        // }
        if (Input.GetButtonDown("Fire1"))
        {
            fir=true;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            sword.SetActive(false);
            fir=false;
        }
        if(fir==true)
        {
            sword.SetActive(true);
        }
        
    }

    private void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            if(enemy.CompareTag("enemy"))
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
