using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;
    public float knockTime;
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("breakable") && this.gameObject.CompareTag("hitbox"))
        {
            collision.GetComponent<PotControl>().Smash();
        }

        //if (collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("Player"))
        //{
        Rigidbody2D hit = collision.GetComponent<Rigidbody2D>();
            
        if (hit != null)
        {
            
            if (collision.gameObject.CompareTag("enemy") && collision.isTrigger )
            {
                Vector2 deltaPosition = hit.transform.position - transform.position;
                deltaPosition = deltaPosition.normalized * thrust;
                hit.AddForce(deltaPosition, ForceMode2D.Impulse);
                hit.GetComponent<EnemyControl>().currentState = EnemyState.stagger;
                collision.GetComponent<EnemyControl>().Knock(hit, knockTime, damage);
                Debug.Log("Enemy knockTime: " + knockTime);
                Debug.Log("Enemy thrust: " + thrust);
                Debug.Log("Enemy Impulse: " + deltaPosition);
            }
            if (collision.gameObject.CompareTag("Player"))
            {
                Vector2 deltaPosition = hit.transform.position - transform.position;
                deltaPosition = deltaPosition.normalized * thrust;
                hit.AddForce(deltaPosition, ForceMode2D.Impulse);
                if (collision.GetComponent<PlayerMovement>().currentState != PlayerState.stagger) { 
                    hit.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
                    collision.GetComponent<PlayerMovement>().Knock(knockTime, damage);
                }
            }
        }
        //}
    }


}
