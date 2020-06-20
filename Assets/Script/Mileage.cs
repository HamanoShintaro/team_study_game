using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class Mileage : MonoBehaviour
{
    public Text MileageText;
    public int AdditionTime;
    public float min; 


    // Start is called before the first frame update
    void Start()
    {
        MileageText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        MileageText.text = AdditionTime.ToString() + "m";
        min += Time.deltaTime * 4;

        if (min >= 1.0)
        {
            AdditionTime += 1;
            Debug.Log(AdditionTime);
            min = 0;
        }
    }
}
