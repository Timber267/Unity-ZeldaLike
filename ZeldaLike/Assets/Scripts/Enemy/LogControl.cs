using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogControl : EnemyControl
{
    public Rigidbody2D myRigidbody;

    [Header("Target Variables")]
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;

    [Header("Animator")]
    public Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        myAnimator.SetBool("wakeUp", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }

    public virtual void CheckDistance()
    {
        if ((Vector3.Distance(target.position, transform.position) <= chaseRadius)
            && (Vector3.Distance(target.position, transform.position) > attackRadius))
        {
            if(currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime);
                changeAnimation(temp - transform.position); 
                myRigidbody.MovePosition(temp);
                ChangeState(EnemyState.walk);
                myAnimator.SetBool("wakeUp", true);
            }
        } else if(Vector3.Distance(target.position, transform.position) >= chaseRadius)
        {
            myAnimator.SetBool("wakeUp", false);
        }
    }

    public void SetAnimatorFloat(Vector2 setVector)
    {
        myAnimator.SetFloat("moveX", setVector.x);
        myAnimator.SetFloat("moveY", setVector.y);
    }

    public void changeAnimation(Vector2 direction)
    {
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if(direction.x > 0)
            {
                SetAnimatorFloat(Vector2.right);
            } else if(direction.x < 0)
            {
                SetAnimatorFloat(Vector2.left);
            }
        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                SetAnimatorFloat(Vector2.up);
            }
            else if (direction.y < 0)
            {
                SetAnimatorFloat(Vector2.down);
            }
        }
    }

    public void ChangeState(EnemyState newState)
    {
        if(currentState != newState)
        {
            currentState = newState;
        }
    }
}
