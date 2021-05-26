using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    #region Public Variables
    public Transform rayCast;
    public LayerMask raycastMask;
    public float rayCastLength;
    public float minAttackDistance;
    public float moveSpeed;
    public float timer; // For cooldown between attacks
    #endregion

    #region Private Variables
    private RaycastHit2D hit;
    private GameObject target;
    private Animator anim;
    private float distance; //Stores distance between Player and enemy
    private bool attackMode;
    private bool inRange; //Checks if Player is within range
    private bool cooldownAtk; //Checks if Enemy is in cooldown
    private float intTimer;
    #endregion

    void Awake()
    {
        intTimer = timer;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(inRange)
        {
            hit = Physics2D.Raycast(rayCast.position, Vector2.left, rayCastLength, raycastMask);
            RaycastDebugger();
        }

        //When Player is detected
        if(hit.collider != null)
        {
            EnemyLogic();
        }
        else if(hit.collider == null)
        {
            inRange = false;
        }

        if(inRange == false)
        {
            anim.SetBool("canMove", false);
            StopAttack();
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.tag == "Player")
        {
            target = trig.gameObject;
            inRange = true;
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);

        if(distance > minAttackDistance)
        {
            Move();
            StopAttack();
        }
        else if(minAttackDistance >= distance && cooldownAtk == false)
        {
            Attack();
        }

        if(cooldownAtk)
        {
            Cooldown();
            anim.SetBool("Attack", false);
        }
    }

    void Move()
    {
        anim.SetBool("canMove", true);

        if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Bee_Attack"))
        {
            Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        timer = intTimer;
        attackMode = true;

        anim.SetBool("canMove", false);
        anim.SetBool("Attack", true);
    }

    void StopAttack()
    {
        cooldownAtk = false;
        attackMode = false;

        anim.SetBool("Attack", false);
    }
    void RaycastDebugger()
    {
        if(distance > minAttackDistance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.red);
        }
        else if (distance > minAttackDistance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.green);
        }
    }

    public void Cooldown()
    {
        timer -= Time.deltaTime;

        if(timer <= 0 && cooldownAtk && attackMode)
        {
            cooldownAtk = false;
            timer = intTimer;

        }
    }
    public void TriggerCooling()
    {
        cooldownAtk = true;
    }

    
}
