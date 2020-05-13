using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public Image image;
    private Color color;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        color = image.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Sin(Time.time * 3) >= 0) {
            color.a = 1.0f;
        }
        else
        {
            color.a = 0.0f;
        }
        image.color = color;
    }
}
