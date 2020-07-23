using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideShow : MonoBehaviour
{
    private float currentTime;
    private int controlCount;
    public GameObject slideShow1;
    public GameObject slideShow2;
    public GameObject slideShow3;
    public GameObject slideShow4;
    public GameObject slideShow;
    public GameObject mainStage;


    void OnEnable()
    {
        currentTime = 0f;
        controlCount = 0;
        slideShow1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >　3.0f && controlCount == 0)
        {
            controlCount += 1;
            slideShow1.SetActive(false);
            slideShow2.SetActive(true);
        }
        
        else if (currentTime > 6.0f && controlCount == 1)
        {
            controlCount += 1;
            slideShow2.SetActive(false);
            slideShow3.SetActive(true);
        }

        else if (currentTime > 9.0f && controlCount == 2)
        {
            controlCount += 1;
            slideShow3.SetActive(false);
            slideShow4.SetActive(true);
        }

        else if (currentTime > 12.0f && controlCount == 3)
        {
            slideShow4.SetActive(false);
            slideShow.SetActive(false);
            mainStage.SetActive(true);
        }
    }
}
