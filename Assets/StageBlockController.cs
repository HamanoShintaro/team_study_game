using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace touch_game
{
    public class StageBlockController : MonoBehaviour
    {
        public float scrollSpeed;
        private Image stageBlockImage;

        // Start is called before the first frame update
        void Start()
        {
            stageBlockImage = GetComponent<Image>();
        }

        // Update is called once per frame
        void Update()
        {
            stageBlockImage.transform.position = new Vector3(stageBlockImage.transform.position.x - scrollSpeed * Time.deltaTime, stageBlockImage.transform.position.y , 0.0f);
        }
    }
}