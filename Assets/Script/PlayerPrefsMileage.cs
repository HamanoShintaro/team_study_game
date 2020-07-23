using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefsMileage : MonoBehaviour
{
    public Text MileageTotalRecordText;
    public Text MileageHighestRecordText;
    public Text MileageNewestRecordText;
    private int MileageTotalRecord;
    private int MileageHighestRecord;
    private int MileageNewestRecord;

    // Start is called before the first frame update
    void OnEnable()
    {
        MileageTotalRecord = PlayerPrefs.GetInt("MileageTotalRecord", 0);
        MileageHighestRecord = PlayerPrefs.GetInt("MileageHighestRecord", 0);
        MileageNewestRecord = PlayerPrefs.GetInt("MileageNewestRecord", 0);
    }

    // Update is called once per frame
    void Update()
    {
        MileageTotalRecordText = GetComponent<Text>();
        MileageHighestRecordText = GetComponent<Text>();
        MileageNewestRecordText = GetComponent<Text>();
        MileageTotalRecordText.text = MileageTotalRecord.ToString() + "m";
        MileageHighestRecordText.text = MileageHighestRecord.ToString() + "m";
        MileageNewestRecordText.text = MileageNewestRecord.ToString() + "m";
    }
}
