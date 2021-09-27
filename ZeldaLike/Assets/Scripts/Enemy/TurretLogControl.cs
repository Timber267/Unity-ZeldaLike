using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLogControl : LogControl
{
    public GameObject projectile;
    public float fireDelay;
    private float fireDelaySec;
    public bool canFire = true;

    private void Update()
    {
        fireDelaySec -= Time.deltaTime;
        if(fireDelaySec<= 0)
        {
            canFire = true;
            fireDelaySec = fireDelay;
        }
    }

    public override void CheckDistance()
    {
        if ((Vector3.Distance(target.position, transform.position) <= chaseRadius)
            && (Vector3.Distance(target.position, transform.position) > attackRadius))
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                if (canFire)
                {
                    Vector3 tempVec = target.transform.position - transform.position;
                    GameObject current = Instantiate(projectile, transform.position, Quaternion.identity);
                    current.GetComponent<Projectile>().Launch(tempVec);
                    canFire = false;

                    ChangeState(EnemyState.walk);
                    myAnimator.SetBool("wakeUp", true);
                }
            }
        }
        else if (Vector3.Distance(target.position, transform.position) >= chaseRadius)
        {
            myAnimator.SetBool("wakeUp", false);
        }
    }


}
