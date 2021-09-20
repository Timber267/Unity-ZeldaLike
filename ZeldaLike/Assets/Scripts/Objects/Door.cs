using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public enum DoorType
{
    keyDoor,
    enemyDoor,
    buttonDoor
}


public class Door : Interactable
{
    [Header("Door variables")]
    public DoorType thisDoorType;
    public bool open = false;
    public Inventory playerInventory;
    public SpriteRenderer doorSprite;
    public BoxCollider2D doorCollider;




    public void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("attack") && playerInRange)
        {
            if(playerInRange && (thisDoorType == DoorType.keyDoor)){
                //Does the Player has a key?
                if(playerInventory.numberOfKeys > 0)
                {
                    //Remove a player key
                    playerInventory.numberOfKeys--;
                    //Do the Open Method
                    OpenDoor();
                }

            }
        }
    }


    public void OpenDoor()
    {
        //Turn off the Door SpriteRenderer
        doorSprite.enabled = false;
        //set open True
        open = true;
        //Turn off door box collider
        doorCollider.enabled = false;
    }

    public void CloseDoor()
    {

    }


}
