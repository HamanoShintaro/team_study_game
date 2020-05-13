using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace touch_game
{

    public class VoiceController : MonoBehaviour
    {
        //宣言
        public AudioSource voiceController;

        //動物の名前
        public AudioClip dog, cat, penguin, lion, ladybug, dinosaur;
        public AudioClip dog_man, cat_man, penguin_man, lion_man, ladybug_man, dinosaur_man;
        public Dictionary<string, AudioClip> animalNames;

        //男性声フラグ
        private bool manFlg = false;

        //タイトルコール
        public AudioClip title, title1, title2, title3, title_man;

        //ゲーム開始
        public AudioClip ready, ready1, ready2, ready3, ready_man;
        public AudioClip start, start1, start2, start_man;

        //ゲーム終了前
        public AudioClip hully, hully1, hully2, hully3, hully_man;

        //ゲーム終了
        public AudioClip end, end1, end2, end_man;
        public AudioClip result, result1, result2, result3, result_man;

        //ずかんタップ
        public AudioClip picture, picture1, picture2, picture3;

        public void resetVoice()
        {
            //男女抽選
            if(Random.Range(0.0f,1.0f) < 0.2f)
            {
                manFlg = true;
            }
            else
            {
                manFlg = false;
            }

            
            if (manFlg) {
                //男性声を設定
                //女性声を設定
                title = title_man;
                ready = ready_man;
                start = start_man;
                hully = hully_man;
                end = end_man;
                result = result_man;
                picture = selectRandomClip(new AudioClip[] { picture1, picture2, picture3 });

                //図鑑用 voiceFile の設定定義
                animalNames = new Dictionary<string, AudioClip>{
                    {"dog", dog_man},
                    {"cat", cat_man},
                    {"penguin", penguin_man},
                    {"lion", lion_man},
                    {"ladybug", ladybug_man},
                    {"dinosaur", dinosaur_man},
                };

                //音量の初期処理
                voiceController.volume = 0.8f;

            }
            else {
                //女性声を設定
                title = selectRandomClip(new AudioClip[] { title1, title2, title3 });
                ready = selectRandomClip(new AudioClip[] { ready1, ready2, ready3 });
                start = selectRandomClip(new AudioClip[] { start1, start2 });
                hully = selectRandomClip(new AudioClip[] { hully1, hully2, hully3 });
                end = selectRandomClip(new AudioClip[] { end1, end2 });
                result = selectRandomClip(new AudioClip[] { result1, result2, result3 });
                picture = selectRandomClip(new AudioClip[] { picture1, picture2, picture3 });

                //図鑑用 voiceFile の設定定義
                animalNames = new Dictionary<string, AudioClip>{
                    {"dog", dog},
                    {"cat", cat},
                    {"penguin", penguin},
                    {"lion", lion},
                    {"ladybug", ladybug},
                    {"dinosaur", dinosaur},
                };

                //音量の初期処理
                voiceController.volume = 1.0f;
            }

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
        public void playVoiceReady()   { voiceController.PlayOneShot(ready); }
        public void playVoiceStart()   { voiceController.PlayOneShot(start); }
        public void playVoiceHully()   { voiceController.PlayOneShot(hully); }
        public void playVoiceEnd()     { voiceController.PlayOneShot(end); }
        public void playVoicePicture() { voiceController.PlayOneShot(picture); }

        public void playVoiceResult() {
            voiceController.clip = result;
            voiceController.PlayDelayed(1.0f);
        }

        public void playVoiceAnimals(string animal) {
            voiceController.PlayOneShot(animalNames[animal]);
        }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}