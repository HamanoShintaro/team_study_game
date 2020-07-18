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