using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace touch_game
{
    public class EpisodeSlideShowController : MonoBehaviour
    {
        public GameObject EpisodeMain;

        public GameObject EpisodeSlideShow;

        public GameObject Episode1;

        public GameObject Episode2;

        public void ShowEpisode1()
        {
            this.EpisodeMain.SetActive(false);
            this.EpisodeSlideShow.SetActive(true);
            Episode1.SetActive(true);
        }

        public void ShowEpisode2()
        {
            this.EpisodeMain.SetActive(false);
            this.EpisodeSlideShow.SetActive(true);
            Episode2.SetActive(true);
        }

        public void CloseEpisode()
        {
            this.EpisodeMain.SetActive(true);
            this.EpisodeSlideShow.SetActive(false);
            this.Episode1.SetActive(false);
            this.Episode2.SetActive(false);
        }
    }
}