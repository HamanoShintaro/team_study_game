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
    private int EvoFlg;
    private float mileageCountSpeed;

    private void OnEnable()
    {
        mileageCountSpeed = 0.8f;
        MileageText = GetComponent<Text>();
        mileageCount = 0;
        MileageText.text = mileageCount.ToString() + "m";
        EvoFlg = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MileageText.text = mileageCount.ToString() + "m";
        min += Time.deltaTime * 4;

        if (min >= mileageCountSpeed && EvoFlg == 0)
        {
            mileageCount += 1;
            min = 0;
        }
        else if (min >= mileageCountSpeed && EvoFlg == 1)
        {
            mileageCount += 4;
            min = 0;
        }
        else if (min >= mileageCountSpeed && EvoFlg == 2)
        {
            mileageCount += 8;
            min = 0;
        }
        else if (min >= mileageCountSpeed && EvoFlg == 3)
        {
            mileageCount += 16;
            min = 0;
        }

        if (mileageCount >= Evo1 && EvoFlg == 2)
        {
            EvoFlg += 1;
            mileageCountSpeed = 0.2f;
        }
        else if (mileageCount >= Evo2 && EvoFlg == 1)
        {
            EvoFlg += 1;
            mileageCountSpeed = 0.4f;
        }
        else if (mileageCount >= Evo3 && EvoFlg == 0)
        {
            EvoFlg += 1;
            mileageCountSpeed = 0.6f;
        }
    }
}
