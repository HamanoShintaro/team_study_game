using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class Mileage : MonoBehaviour
{
    public Text MileageText;
    public int mileageCount;
    public float min;
    public int Evo1;
    public int Evo2;
    public int Evo3;
    private float mileageCountSpeed = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        MileageText = GetComponent<Text>();
    }

    private void OnEnable()
    {
        mileageCount = 0;
        MileageText.text = mileageCount.ToString() + "m";
    }

    // Update is called once per frame
    void Update()
    {
        MileageText.text = mileageCount.ToString() + "m";
        min += Time.deltaTime * 4;

        if (min >= mileageCountSpeed)
        {
            mileageCount += 1;
            //Debug.Log(mileageCount);
            min = 0;
        }

        if (mileageCount >= Evo1)
        {
            mileageCountSpeed = 0.2f;
        }
        else if (mileageCount >= Evo2)
        {
            mileageCountSpeed = 0.4f;
        }
        else if (mileageCount >= Evo3)
        {
            mileageCountSpeed = 0.6f;
        }
    }
}
