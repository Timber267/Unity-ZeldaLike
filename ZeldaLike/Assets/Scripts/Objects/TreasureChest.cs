using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class TreasureChest : Interactable
{
    [Header("Contents")]
    public Item contents;
    public Inventory playerInventory;
    public bool isOpen;
    public BoolValue storedOpen;

    [Header("Signals and Dialog")]
    public Signal raiseItem;
    public GameObject dialogBox;
    public Text dialogText;

    [Header("Animation")]
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isOpen = storedOpen.RuntimeValue;

        if (isOpen)
        {
            anim.SetBool("opened", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("attack") && playerInRange)
        {
            if (!isOpen)
            {
                //Open the Chest
                OpenChest();
            }
            else
            {
                // Chest is already open
                BeenOpened();
            }



        }
    }

    public void OpenChest()
    {
        //Dialog window on
        dialogBox.SetActive(true);
        //Dialog text = content text
        dialogText.text = contents.itemDescription;
        //Content to Inventory
        playerInventory.AddItem(contents);
        playerInventory.currentItem = contents;
        //Raise Signal to player to animate
        raiseItem.Raise();
        //raise interactionIcon
        interactionIcon.Raise();
        //set Chest to opened
        isOpen = true;
        anim.SetBool("opened", true);
        storedOpen.RuntimeValue = isOpen;
    }

    public void BeenOpened()
    {
        //Dialog off
        dialogBox.SetActive(false);
        //raise signal to player to stop animating
        raiseItem.Raise();
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !collision.isTrigger && !isOpen)
        {
            playerInRange = true;
            interactionIcon.Raise();
            //Debug.Log("Player in range");
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !collision.isTrigger && !isOpen)
        {

            playerInRange = false;
            interactionIcon.Raise();
            //Debug.Log("Player left range");
        }
    }
}
