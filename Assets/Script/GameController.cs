using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace touch_game
{
    public class GameController : MonoBehaviour
    {

        public float LEAST_TIME = 3.0f;
        public static GameController instance;
        public Spawner Spawner;
        public StartMenu StartMenu;
        public ReadyText ReadyText;
        public Image LeastTime;
        public Background background;
        public Background background_sub;
        public GameObject resultObj;
        public Result result;
        public Dictionary<string, int> Counter;
        public GameObject pictureBookObj;
        public PictureBook pictureBook;

        //音響用インスタンス
        public BgmController bgmController;
        public VoiceController voiceController;

        private void Awake()
        {
            instance = this;
        }
        // Start is called before the first frame update
        public void Start()
        {
            // ポイントの初期化
            Counter = new Dictionary<string, int>
            {
                {"dog", 0},
                {"cat", 0},
                {"penguin", 0},
                {"lion", 0},
                {"ladybug", 0},
                {"dinosaur", 0}
            };
            Debug.Log("スタート処理を行います");
            //初回処理 ユーザーデータの作成
            if (PlayerPrefs.HasKey("dog") == false) {
                Debug.Log("初回起動処理を開始します");
                PlayerPrefs.SetInt("dog", 0);
                PlayerPrefs.SetInt("cat", 0);
                PlayerPrefs.SetInt("penguin", 0);
                PlayerPrefs.SetInt("lion", 0);
                PlayerPrefs.SetInt("ladybug", 0);
                PlayerPrefs.SetInt("dinosaur", 0);
            }
            //ゲーム環境の設定
            this.voiceController.resetVoice();
            this.voiceController.playVoiceTitle();
            this.bgmController.StartTitleBgm();
            this.Spawner.spawnFlg = false;
            this.StartMenu.displayFlg = true;
            this.background.scrollFlg = true;
            this.background_sub.scrollFlg = true;
            this.result.displayFlg = false;
            this.resultObj.SetActive(false);
            this.pictureBookObj.SetActive(false);
        }

        public void ClickStart()
        {
            this.bgmController.StopBgm();
            this.StartMenu.displayFlg = false;
            this.ReadyText.displayFlg = true;
            this.background.scrollFlg = false;
            this.background_sub.scrollFlg = false;
            this.StartCoroutine(this.FullfillTime());
            this.StartCoroutine(this.GameStart());
        }

        public void ClickPictureBook()
        {
            this.StartMenu.displayFlg = false;
            callPictureBook();
        }

        public IEnumerator GameStart()
        {
            yield return new WaitForSeconds(ReadyText.spanTime * 5);
            this.bgmController.StartGameBgm();
            this.voiceController.playVoiceStart();
            this.Spawner.spawnFlg = true;

            float leastTime = LEAST_TIME;
            while (leastTime > 0)
            {
                if(leastTime < LEAST_TIME/3)
                {
                    this.bgmController.upPitch();
                    if (this.Spawner.coefficient != 0.3f)
                    {
                        this.voiceController.playVoiceHully();
                    }
                    this.Spawner.coefficient = 0.3f;
                }
                this.LeastTime.fillAmount = leastTime / LEAST_TIME;
                leastTime -= Time.deltaTime;
                yield return null;
            }
            this.voiceController.playVoiceEnd();
            this.StopGame();
        }

        public IEnumerator FullfillTime()
        {
            while(this.LeastTime.fillAmount < 1.0f) { 
                this.LeastTime.fillAmount += 0.02f;
                yield return new WaitForSeconds(0.02f);
            }
        }

        private void StopGame()
        {
            this.Spawner.spawnFlg = false;
            this.StartCoroutine(this.Spawner.DestroyAllChildren());
            this.LeastTime.fillAmount = 0f;
            callResult();
        }

        private void callResult()
        {
            Debug.Log("結果表示処理を実行します");
            this.background.scrollFlg = true;
            this.background_sub.scrollFlg = true;
            this.result.displayFlg = true;
            this.resultObj.SetActive(true);
            this.bgmController.StartTitleBgm();
        }

        private void callPictureBook()
        {
            this.background.scrollFlg = true;
            this.background_sub.scrollFlg = true;
            this.pictureBookObj.SetActive(true);
            this.pictureBook.displayFlg = true;
            this.bgmController.StartTitleBgm();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}