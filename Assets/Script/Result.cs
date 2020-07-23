using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public GameObject MileageNewestRecord;
    private int NewestRecord;

    void OnEnable()
    {
        NewestRecord = PlayerPrefs.GetInt("MileageNewestRecord", 0);
    }

    // Update is called once per frame
    void Update()
    {
        Text MileageNewestRecordText = MileageNewestRecord.GetComponent<Text>();

        MileageNewestRecordText.text = NewestRecord.ToString() + "m";
    }
}
