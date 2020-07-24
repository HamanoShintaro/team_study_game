﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainStage : MonoBehaviour
{
    public GameObject BlockField1;
    public GameObject BlockField2;
    public GameObject Penguin;
    public Text textCountdown;

    void OnEnable()
    {
        BlockField1.SetActive(true);
        BlockField2.SetActive(true);
        Penguin.SetActive(true);
        textCountdown.gameObject.SetActive(true);
    }

}
