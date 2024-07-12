using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    public int hp;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp > numOfHearts)
        {
            hp = numOfHearts;
        }


        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < hp)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
