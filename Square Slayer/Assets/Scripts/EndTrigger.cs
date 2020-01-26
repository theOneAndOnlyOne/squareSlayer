﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{

    public GameManager gameManager;

    // Start is called before the first frame update
    void OnTriggerEnter2D()
    {
        Debug.Log("Player Tried to swim in Lava.");
        FindObjectOfType<Player>().die();

    }
}
