using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Evolution : MonoBehaviour
{
    Image ImageChange;
    Vector2 WidthAndHeight;
    Vector2 Position;
    public Text Mileage;
    public String MileageText;
    public Sprite Image1;
    public Sprite Image2;

    // Start is called before the first frame update
    void Start()
    {
        ImageChange = gameObject.GetComponent<Image>();
        WidthAndHeight = gameObject.GetComponent<RectTransform>().sizeDelta;
        Position = gameObject.GetComponent<RectTransform>().anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        MileageText = Mileage.text.ToString();
        
        if (MileageText == "10m")
        {
            ImageChange.sprite = Image1;
        }

        if (MileageText == "25m")
        {
            ImageChange.sprite = Image2;
            WidthAndHeight.x = 200;
            WidthAndHeight.y = 200;
            Position.y = -270;
            GetComponent<RectTransform>().sizeDelta = WidthAndHeight;
            GetComponent<RectTransform>().anchoredPosition = Position;
        }

    }
}
