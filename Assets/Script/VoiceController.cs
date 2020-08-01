using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace touch_game
{

    public class VoiceController : MonoBehaviour
    {
        //宣言
        public AudioSource voiceController;

        //ジャンプの時の声
        public AudioClip jump01, jump02, jump03, jump04, jump05, jump06;
        private Dictionary<int, AudioClip> jump;
        public AudioClip doubleJump;


        //タイトルコール
        public AudioClip title;

        public void Start()
        {
            //ゲーム環境の設定

            jump = new Dictionary<int, AudioClip>{
                {1, jump01},
                {2, jump02},
                {3, jump03},
                {4, jump04},
                {5, jump05},
                {6, jump06},
            };
        }

        public void resetVoice()
        {

        }

        private AudioClip selectRandomClip(AudioClip[] voices)
        {

            AudioClip voice = null;
            float randomNumber = Random.Range(0.0f, 1.0f);
            float arraylength = voices.Length;

            for (int i = 0; i < arraylength; ++i)
            {
                if (randomNumber * arraylength <= i + 1)
                {
                    voice = voices[i];
                    break;
                };
            }
            return voice;
        }

        //外部呼び出し用のFunction定義
        public void playVoiceTitle()   { voiceController.PlayOneShot(title); }
        public void playVoiceReady()   { }

        public void playVoiceJump(int level) { voiceController.PlayOneShot(jump[level]); }

        public void playVoiceDoubleJump() { voiceController.PlayOneShot(doubleJump); }


        // Update is called once per frame
        void Update()
        {

        }
    }
}