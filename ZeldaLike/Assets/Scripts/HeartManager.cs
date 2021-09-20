using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;
    public FloatValue HeartContianers;
    public FloatValue PlayerCurrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        InitHeart();
    }

    public void InitHeart()
    {
        for(int i = 0; i < HeartContianers.initialValue; i++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = fullHeart;
        }
    }

    public void UpdateHearts()
    {
        float tempHealth = PlayerCurrentHealth.RuntimeValue / 2;
        for (int i = 0; i < HeartContianers.initialValue; i++)
        {
            if(i <= tempHealth - 1)
            {
                hearts[i].sprite = fullHeart;
            }else if (i >= tempHealth){
                hearts[i].sprite = emptyHeart;
            }else
            {
                hearts[i].sprite = halfHeart;

            }
        }
    }

}
