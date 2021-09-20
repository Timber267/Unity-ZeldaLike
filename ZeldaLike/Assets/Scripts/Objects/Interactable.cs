using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool playerInRange;
    public Signal interactionIcon;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !collision.isTrigger)
        {
            playerInRange = true;
            interactionIcon.Raise();
            //Debug.Log("Player in range");
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !collision.isTrigger)
        {

            playerInRange = false;
            interactionIcon.Raise();
            //Debug.Log("Player left range");
        }
    }
}
