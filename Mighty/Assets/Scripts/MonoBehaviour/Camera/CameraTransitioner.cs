﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransitioner : MonoBehaviour {


    public GameObject gm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            gm.SetActive(true);
    }
}
