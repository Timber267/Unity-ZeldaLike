using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Movement Stuff")]
    public float moveSpeed;
    public Vector2 directionTooMove;
    [Header("Lifetim")]
    public float lifetime;
    private float lifetimeSec;
    public Rigidbody2D myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        lifetimeSec = lifetime;   
    }

    // Update is called once per frame
    void Update()
    {
        lifetimeSec -= Time.deltaTime;
        if (lifetimeSec <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Launch(Vector2 initialVelo)
    {
        myRigidbody.velocity = initialVelo * moveSpeed;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}
