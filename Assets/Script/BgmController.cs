using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace touch_game
{
    public class BgmController : MonoBehaviour
    {
        public AudioSource bgmController;

        // AudioClipの宣言
        public AudioClip title;
        public AudioClip stage0101, stage0102, stage0201, stage0202, stage0301, stage0302, stage0401, stage0402, stage0501, stage0502, stage0601, stage0602;

        private Dictionary<int, AudioClip> stageBGM;

        public float fadeSpeed;

        // Start is called before the first frame update
        void Start()
        {
            initGameBGM();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void initGameBGM() {

            // ゲームの音声の初期設定
            stageBGM = new Dictionary<int, AudioClip>{
                {1, selectRandomClip(new AudioClip[] { stage0101, stage0102 })},
                {2, selectRandomClip(new AudioClip[] { stage0201, stage0202 })},
                {3, selectRandomClip(new AudioClip[] { stage0301, stage0302 })},
                {4, selectRandomClip(new AudioClip[] { stage0401, stage0402 })},
                {5, selectRandomClip(new AudioClip[] { stage0501, stage0502 })},
                {6, selectRandomClip(new AudioClip[] { stage0601, stage0602 })},
             };
        }

        public void resetAudio()
        {
            bgmController.Stop();
            bgmController.pitch = 1.0f;
            bgmController.volume = 0.2f;
        }

        public IEnumerator fadeOutAudio()
        {
            while (bgmController.volume > 0.0f) {
                bgmController.volume -= fadeSpeed * Time.deltaTime;
                yield return new WaitForSeconds(0.02f);
            }
            bgmController.Stop();
            resetAudio();
        }

        public IEnumerator fadeInAudio(AudioClip audioClip)
        {
            bgmController.volume = 0.0f;
            bgmController.clip = audioClip;
            bgmController.Play();
            while (bgmController.volume < 0.2f)
            {
                bgmController.volume += fadeSpeed * Time.deltaTime;
                yield return new WaitForSeconds(0.02f);
            }
        }
        public IEnumerator transitionAudio(AudioClip audioClip)
        {
            while (bgmController.volume > 0.0f)
            {
                bgmController.volume -= fadeSpeed * Time.deltaTime;
                yield return new WaitForSeconds(0.02f);
            }
            bgmController.Stop();
            resetAudio();

            bgmController.clip = audioClip;
            bgmController.Play();
            while (bgmController.volume < 0.2f)
            {
                bgmController.volume += fadeSpeed * Time.deltaTime;
                yield return new WaitForSeconds(0.02f);
            }
        }


        public void StartTitleBgm()
        {
            if(bgmController.clip != title) { 
                resetAudio();
                bgmController.volume = 0.2f;
                bgmController.clip = title;
                bgmController.PlayDelayed(2.0f);
            }
        }

        public void StartGameBgm(int level)
        {
            if (bgmController.clip != stageBGM[level]) {
                this.StartCoroutine(this.transitionAudio(stageBGM[level]));
            }
        }

        public void upPitch()
        {
            bgmController.pitch = 1.3f;
        }

        public void StopBgm()
        {
            bgmController.Stop();
        }

        private AudioClip selectRandomClip(AudioClip[] clips)
        {

            AudioClip clip = null;
            float randomNumber = Random.Range(0.0f, 1.0f);
            float arraylength = clips.Length;

            for (int i = 0; i < arraylength; ++i)
            {
                if (randomNumber * arraylength <= i + 1)
                {
                    clip = clips[i];
                    break;
                };
            }
            return clip;
        }
    }
}