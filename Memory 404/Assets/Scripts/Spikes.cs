﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public Player player;

    void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
       if (col.CompareTag("Player"))
        {
            player.Damage(1);
            StartCoroutine(player.Knockback(0.1f, -100, player.transform.position));
        }
    }

}
