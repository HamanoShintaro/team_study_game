using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace touch_game
{
    public class EpisodeSlideShow2 : MonoBehaviour
    {
        private int TapCount = 0;
        public GameObject[] Slide = new GameObject[4];
        public EpisodeSlideShowController EpisodeSlideShowController;
        public GameObject EpisodeMain;

        /*void OnEnable()
        {
            TapCount = 0;
            this.Slide[0].SetActive(true);
            for (int i = 1; i < Slide.Length; i++)
            {
                Slide[i].SetActive(false);
            }
        }*/
        public void TapCountUp()
        {
            TapCount++;
            enabled = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (TapCount == Slide.Length)
            {
                EpisodeSlideShowController.CloseEpisode();
                TapCount = 0;
            }
            else
            {
                foreach (GameObject g in Slide)
                {
                    g.SetActive(false);
                }

                this.Slide[TapCount].SetActive(true);
                enabled = false;
            }
        }
    }
}