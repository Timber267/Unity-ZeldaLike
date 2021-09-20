using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionIcon : MonoBehaviour
{
    public GameObject interactionIcon2;
    public bool interactionActive = false;

    public void ChangeInteractionIcon()
    {
        interactionActive = !interactionActive;

        if (interactionActive)
        {
            interactionIcon2.SetActive(true);
        }
        else
        {
            interactionIcon2.SetActive(false);
        }
    }
    /**
    public void Enable()
    {
        interactionIcon2.SetActive(true);
    }

    public void Disable()
    {
        interactionIcon2.SetActive(false);
    }
    **/

}
