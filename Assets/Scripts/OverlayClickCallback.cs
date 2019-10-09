﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverlayClickCallback : MonoBehaviour
{
    public bool down;
    public bool read;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnMouseDown);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        down = true;
        read = false;
    }
    private void OnMouseUp()
    {
        down = false;
    }
}
