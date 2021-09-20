using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolLogControl : LogControl
{
    public Transform[] path;
    public int currentPoint;
    public Transform currentGoal;
    public float goalRadius;

    public override void CheckDistance()
    {
        if ((Vector3.Distance(target.position, transform.position) <= chaseRadius)
            && (Vector3.Distance(target.position, transform.position) > attackRadius))
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime);
                changeAnimation(temp - transform.position);
                myRigidbody.MovePosition(temp);
                //ChangeState(EnemyState.walk);
                myAnimator.SetBool("wakeUp", true);
            }
        }
        else if (Vector3.Distance(target.position, transform.position) >= chaseRadius)
        {
            if(Vector3.Distance(transform.position, path[currentPoint].position) >= goalRadius)
            {

                Vector3 temp = Vector3.MoveTowards(transform.position, path[currentPoint].position, enemySpeed * Time.deltaTime);
                changeAnimation(temp - transform.position);
                myRigidbody.MovePosition(temp);
            } else
            {
                ChangeGoal();
            }

        }
    }

    private void ChangeGoal()
    {
        if(currentPoint == (path.Length - 1))
        {
            currentPoint = 0;
            currentGoal = path[0];
        } else
        {
            currentPoint++;
            currentGoal = path[currentPoint];
        }
    }
}
