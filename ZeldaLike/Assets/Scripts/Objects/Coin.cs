using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : PowerUp
{
    public Inventory playerInventory;

    public void Start()
    {
        powerUpSignal.Raise();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            playerInventory.coins += 1;


            powerUpSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
