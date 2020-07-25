using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainStage : MonoBehaviour
{
    public GameObject BlockField1;
    public GameObject BlockField2;
    public Text textCountdown;
    public Mileage mileage;
    public GameObject Result;

    void OnEnable()
    {
        BlockField1.SetActive(true);
        BlockField2.SetActive(true);
        textCountdown.gameObject.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerPrefs.SetInt("MileageTotalRecord", PlayerPrefs.GetInt("MileageTotalRecord", 0) + mileage.mileageCount);

        if (PlayerPrefs.GetInt("MileageHighestRecord", 0) < mileage.mileageCount)
        {
            Debug.Log("最高記録");
            PlayerPrefs.SetInt("MileageHighestRecord", mileage.mileageCount);
        }

        PlayerPrefs.SetInt("MileageNewestRecord", mileage.mileageCount);

        PlayerPrefs.Save();

        mileage.mileageCount = 0;

        this.gameObject.SetActive(false);
        Result.SetActive(true);
    }

}
