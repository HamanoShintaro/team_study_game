using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Evolution : MonoBehaviour
{
    public Mileage mileage;
    public GameObject penguin1;
    public GameObject penguin2;
    public GameObject penguin3;
    public GameObject penguin4;
    private GameObject Player;

    // Start is called before the first frame update
    void OnEnable()
    {
        Player = Instantiate(penguin1, transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (mileage.mileageCount >= mileage.Evo1)
        {
            Destroy(Player);
            Player = Instantiate(penguin4, transform);
        }
        else if (mileage.mileageCount >= mileage.Evo2)
        {
            Destroy(Player);
            Player = Instantiate(penguin3, transform);
        }
        else if (mileage.mileageCount >= mileage.Evo3)
        {
            Destroy(Player);
            Player = Instantiate(penguin2, transform);
        }
    }

    private void OnDisable()
    {
        Destroy(Player);
    }
}
