using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace touch_game
{
    public class BgmController : MonoBehaviour
    {
        public AudioSource bgmController;
        public AudioClip titleBgm;
        public AudioClip gameBgm;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void resetAudio()
        {
            bgmController.pitch = 1.0f;
            bgmController.Stop();
        }

        public void StartTitleBgm()
        {
            if(bgmController.clip != titleBgm) { 
                resetAudio();
                bgmController.volume = 0.2f;
                bgmController.clip = titleBgm;
                bgmController.PlayDelayed(1.0f);
            }
        }

        public void StartGameBgm()
        {
            resetAudio();
            bgmController.volume = 0.2f;
            bgmController.clip = gameBgm;
            bgmController.PlayDelayed(0.5f);
        }

        public void upPitch()
        {
            bgmController.pitch = 1.3f;
        }

        public void StopBgm()
        {
            bgmController.Stop();
        }
    }
}