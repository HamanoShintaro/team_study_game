using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public GameObject MileageNewestRecord;
    public GameObject NewRecordImage;
    public Image ResultBackground;
    public Sprite image1;
    public Sprite image2;
    public Sprite image3;
    public Sprite image4;
    public int Evo1;
    public int Evo2;
    public int Evo3;
    private int NewestRecord;

    void OnEnable()
    {
        NewRecordImage.SetActive(false);
        NewestRecord = PlayerPrefs.GetInt("MileageNewestRecord", 0);

        if (Evo1 <= NewestRecord)
        {
            ResultBackground.sprite = image1;
        }

        else if (Evo2 <= NewestRecord)
        {
            ResultBackground.sprite = image2;
        }

        else if (Evo3 <= NewestRecord)
        {
            ResultBackground.sprite = image3;
        }

        else
        {
            ResultBackground.sprite = image4;
        }

        if (PlayerPrefs.GetInt("MileageHighestRecord", 0) == NewestRecord)
        {
            NewRecordImage.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Text MileageNewestRecordText = MileageNewestRecord.GetComponent<Text>();

        MileageNewestRecordText.text = NewestRecord.ToString() + "m";
    }
}
