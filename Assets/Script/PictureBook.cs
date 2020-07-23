using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictureBook : MonoBehaviour
{
    public GameObject MileageTotalRecord;
    public GameObject MileageHighestRecord;
    private int TotalRecord;
    private int HighestRecord;

    void OnEnable()
    {
        TotalRecord = PlayerPrefs.GetInt("MileageTotalRecord", 0);
        HighestRecord = PlayerPrefs.GetInt("MileageHighestRecord", 0);
    }

    // Update is called once per frame
    void Update()
    {
        Text MileageTotalRecordText = MileageTotalRecord.GetComponent<Text>();
        Text MileageHighestRecordText = MileageHighestRecord.GetComponent<Text>();

        MileageTotalRecordText.text = TotalRecord.ToString() + "m";
        MileageHighestRecordText.text = HighestRecord.ToString() + "m";
    }
}
