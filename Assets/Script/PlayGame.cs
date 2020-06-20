using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGame : MonoBehaviour
{
    private float speed = 0.1f;  //透明化の速さ
    public bool displayFlg = false;
    private float alpha;
    public CanvasGroup playGame;

    // Start is called before the first frame update
    void Start()
    {
        playGame = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (displayFlg == true)
        {
            if (playGame.alpha < 1.0f)
            {
                playGame.alpha = alpha;
                alpha += speed;
            }
        }
        if (displayFlg == false)
        {
            if (playGame.alpha > 0f)
            {
                playGame.alpha = 0;
                alpha = 0f;
            }
        }
    }
}
