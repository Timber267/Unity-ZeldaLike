using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool active;
    public BoolValue storedValue;
    public Sprite activeSprite;
    private SpriteRenderer mySprite;
    public Door myDoor;


    // Start is called before the first frame update
    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        active = storedValue.RuntimeValue;
        if (active)
        {
            ActivateSwitch();
        }
    }

    public void ActivateSwitch()
    {
        active = true;
        storedValue.RuntimeValue = active;
        myDoor.OpenDoor();
        mySprite.sprite = activeSprite;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Is player?7
        if (collision.CompareTag("Player"))
        {
            ActivateSwitch();
        }
    }
}
