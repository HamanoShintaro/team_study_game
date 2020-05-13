using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace touch_game
{

    public class Result : MonoBehaviour
    {

        public bool displayFlg;
        public CanvasGroup result;
        public float speed;

        public Image dogImage;
        public Image catImage;
        public Image penguinImage;
        public Image lionImage;
        public Image ladybugImage;
        public Image dinosaurImage;

        public Text dogCount;
        public Text catCount;
        public Text penguinCount;
        public Text lionCount;
        public Text ladybugCount;
        public Text dinosaurCount;

        public Sprite dogBehind;
        public Sprite dogFront;
        public Sprite catBehind;
        public Sprite catFront;
        public Sprite penguinBehind;
        public Sprite penguinFront;
        public Sprite lionBehind;
        public Sprite lionFront;
        public Sprite ladybugBehind;
        public Sprite ladybugFront;
        public Sprite dinosaurBehind;
        public Sprite dinosaurFront;

        public CanvasGroup lionPanel;
        public CanvasGroup ladybugPanel;
        public CanvasGroup dinosaurPanel;

        private float alpha;
        private bool oneTimeFlg = true;

        // Start is called before the first frame update
        void Start()
        {
            result = GetComponent<CanvasGroup>();
        }

        // Update is called once per frame
        void Update()
        {
            if (displayFlg == true)
            {
                if (oneTimeFlg)
                {
                    Debug.Log("結果反映処理を開始します");
                    Debug.Log(GameController.instance.Counter["dog"]);

                    oneTimeFlg = false;

                    int dogNum = GameController.instance.Counter["dog"];
                    int catNum = GameController.instance.Counter["cat"];
                    int penguinNum = GameController.instance.Counter["penguin"];
                    int lionNum = GameController.instance.Counter["lion"];
                    int ladybugNum = GameController.instance.Counter["ladybug"];
                    int dinosaurNum = GameController.instance.Counter["dinosaur"];

                    //dogの処理
                    dogCount.text = ConvertToFullWidth(dogNum.ToString()) + "ひき";
                    if (dogNum == 0)
                    {
                        dogImage.sprite = dogBehind;
                    }
                    else
                    {
                        dogImage.sprite = dogFront;
                    }
                    PlayerPrefs.SetInt("dog", PlayerPrefs.GetInt("dog") + dogNum);


                    //catの処理
                    catCount.text = ConvertToFullWidth(catNum.ToString()) + "ひき";
                    if (catNum == 0)
                    {
                        catImage.sprite = catBehind;
                    }
                    else
                    {
                        catImage.sprite = catFront;
                    }
                    PlayerPrefs.SetInt("cat", PlayerPrefs.GetInt("cat") + catNum);

                    //penguinの処理
                    penguinCount.text = ConvertToFullWidth(penguinNum.ToString()) + "ひき";
                    if (penguinNum == 0)
                    {
                        penguinImage.sprite = penguinBehind;
                    }
                    else
                    {
                        penguinImage.sprite = penguinFront;
                    }
                    PlayerPrefs.SetInt("penguin", PlayerPrefs.GetInt("penguin") + penguinNum);

                    //lionの処理
                    lionCount.text = ConvertToFullWidth(lionNum.ToString()) + "ひき";
                    if (lionNum == 0)
                    {
                        lionImage.sprite = lionBehind;
                    }
                    else
                    {
                        lionImage.sprite = lionFront;
                    }
                    PlayerPrefs.SetInt("lion", PlayerPrefs.GetInt("lion") + lionNum);
                    if(PlayerPrefs.GetInt("lion") == 0)
                    {
                        lionPanel.alpha = 0.0f;
                    }
                    else
                    {
                        lionPanel.alpha = 1.0f;
                    }

                    //ladybugの処理
                    ladybugCount.text = ConvertToFullWidth(ladybugNum.ToString()) + "ひき";
                    if (ladybugNum == 0)
                    {
                        ladybugImage.sprite = ladybugBehind;
                    }
                    else
                    {
                        ladybugImage.sprite = ladybugFront;
                    }
                    PlayerPrefs.SetInt("ladybug", PlayerPrefs.GetInt("ladybug") + ladybugNum);
                    if (PlayerPrefs.GetInt("ladybug") == 0)
                    {
                        ladybugPanel.alpha = 0.0f;
                    }
                    else
                    {
                        ladybugPanel.alpha = 1.0f;
                    }

                    //dinosaurの処理
                    dinosaurCount.text = ConvertToFullWidth(dinosaurNum.ToString()) + "ひき";
                    if (dinosaurNum == 0)
                    {
                        dinosaurImage.sprite = dinosaurBehind;
                    }
                    else
                    {
                        dinosaurImage.sprite = dinosaurFront;
                    }
                    PlayerPrefs.SetInt("dinosaur", PlayerPrefs.GetInt("dinosaur") + dinosaurNum);
                    if (PlayerPrefs.GetInt("dinosaur") == 0)
                    {
                        dinosaurPanel.alpha = 0.0f;
                    }
                    else
                    {
                        dinosaurPanel.alpha = 1.0f;
                    }
                }
                else if (result.alpha < 1.0f)
                {
                    result.alpha += speed * Time.deltaTime;
                    if(result.alpha == 1.0f)
                    {
                        GameController.instance.voiceController.playVoiceResult();
                    }
                }
            }
        }

        public void onClick() {
            result.alpha = 0.0f;
            oneTimeFlg = true;
            displayFlg = false;
            GameController.instance.Start();
        }

        static public string ConvertToFullWidth(string halfWidthStr)
        {
            const int ConvertionConstant = 65248;
            string fullWidthStr = null;

            for (int i = 0; i < halfWidthStr.Length; i++)
            {
                fullWidthStr += (char)(halfWidthStr[i] + ConvertionConstant);
            }

            return fullWidthStr;
        }
    }
}