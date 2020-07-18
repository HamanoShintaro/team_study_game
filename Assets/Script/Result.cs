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
        
        // Start is called before the first frame update
        void Start()
        {
            result = GetComponent<CanvasGroup>();
        }

        // Update is called once per frame
        void Update()
        {
           
        }

        public void onClick() {
            result.alpha = 0.0f;
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