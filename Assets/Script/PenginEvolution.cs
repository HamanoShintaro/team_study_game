using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace touch_game
{
    public class PenginEvolution : MonoBehaviour
    {
        public Image[] pengin = new Image[4];

        public Mileage Mileage;

        public void OnEnable()
        {
            //全部黒塗りにする
            foreach (Image pen in pengin)
            {
                pen.color = new Color(0, 0, 0);
            }

            int penginLevel = this.CheckPenginLevel();

            //到達したペンギンのレベルまで黒塗りを解除する
            for (int i = 0;i < penginLevel; i++)
            {
                pengin[i].color = new Color(255, 255, 255, 255);
            }
        }

        private int CheckPenginLevel()
        {
            int Level = 1;

            int HighestRecord = PlayerPrefs.GetInt("MileageHighestRecord", 0);

            if (Mileage.Evo1 <= HighestRecord)
            {
                Level = 4;
            }
            else if (Mileage.Evo2 <= HighestRecord)
            {
                Level = 3;
            }
            else if (Mileage.Evo3 <= HighestRecord)
            {
                Level = 2;
            }

            return Level;
        }
    }
}