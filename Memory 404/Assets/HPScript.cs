using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPScript : MonoBehaviour
{
    public int health = 3;
    public int ilosckontenerow = 3;

    public Image[] hearts;
    public Sprite fullHP1;
    public Sprite emptyHP1;
    public Sprite fullHP2;
    public Sprite emptyHP2;
    public Sprite fullHP3;
    public Sprite emptyHP3;

    private void Update()
    {
        if (health > ilosckontenerow)
        {
            health = ilosckontenerow;
        }
        if (health == 3)
        {
            hearts[2].sprite = fullHP1;
            hearts[1].sprite = fullHP3;
            hearts[0].sprite = fullHP2;
        }
        if (health == 2)
        {
            hearts[2].sprite = fullHP1;
            hearts[1].sprite = emptyHP3;
            hearts[0].sprite = fullHP2;
        }
        if (health == 1)
        {
            hearts[2].sprite = fullHP1;
            hearts[1].sprite = emptyHP3;
            hearts[0].sprite = emptyHP2;
        }
        if (health == 0)
        {
            hearts[2].sprite = emptyHP1;
            hearts[1].sprite = emptyHP3;
            hearts[0].sprite = emptyHP2;
        }

    }
}
