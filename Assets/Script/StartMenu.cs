using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace touch_game { 

    public class StartMenu : MonoBehaviour
    {
        private float speed = 0.1f;  //透明化の速さ
        public bool displayFlg = false;
        private float alpha;
        public CanvasGroup startMenu;

        // Start is called before the first frame update
        void Start()
        {
            startMenu = GetComponent<CanvasGroup> ();
        }

        // Update is called once per frame
        void Update()
        {
            if(startMenu.alpha < 1.0f)
            { 
                startMenu.alpha = alpha;
                alpha += speed;
            }
        }
    }
}