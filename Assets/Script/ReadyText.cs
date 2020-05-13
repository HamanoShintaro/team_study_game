using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace touch_game
{
    public class ReadyText : MonoBehaviour
    {

        public bool displayFlg;
        public Text readyText;

        public float spanTime;
        private float currentTime = 0.0f;

        // Start is called before the first frame update
        void Start()
        {
            readyText = GetComponent<Text>();
        }

        // Update is called once per frame
        void Update()
        {
            if (displayFlg == true)
            {

                currentTime += Time.deltaTime;

                if (currentTime < spanTime )
                {
                    readyText.text = "　　　　　　";
                }
                else if (currentTime < spanTime * 2)
                {
                    if (readyText.text != "よーい　　　")
                    {
                        GameController.instance.voiceController.playVoiceReady();
                        readyText.text = "よーい　　　";
                    }
                }
                else if (currentTime < spanTime * 3)
                {
                    readyText.text = "よーい・　　";
                }
                else if (currentTime < spanTime * 4)
                {
                    readyText.text = "よーい・・　";
                }
                else if (currentTime < spanTime * 5)
                {
                    readyText.text = "よーい・・・";
                }
                else
                {
                    displayFlg = false;
                    currentTime = 0f;
                }

                if (displayFlg == false)
                {
                    if (readyText.text != "")
                    {
                        readyText.text = "";
                    }
                }
            }
        }
    }
}