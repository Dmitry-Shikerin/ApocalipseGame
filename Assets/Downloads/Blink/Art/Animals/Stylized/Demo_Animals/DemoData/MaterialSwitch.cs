﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwitch : MonoBehaviour
{
    public Material[] Materials;
    public Renderer Renderer;
    private int matIndex= -1;

    public float delay = 2;
    private float nextMaterial;

    private bool ready;
    public AudioSource audio;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            ready = true;
            audio.Play();
        }
    }

    private void FixedUpdate()
    {
        if(!ready) return;
        if (Time.time >= nextMaterial)
        {
            nextMaterial = Time.time + delay;

            matIndex++;
            if (Materials.Length - 1 < matIndex) matIndex = 0;
            Renderer.material = Materials[matIndex];
        }
    }
}
