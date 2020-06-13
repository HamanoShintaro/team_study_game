using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    public float scrollSpeed;
    public bool scrollFlg;

    public Image background;
    public Image opposedBackground;
    public Image mainPanesl;

    private Vector3 initPosition;
    private Vector3 initPositionSub;
    private float leftLine;

    public bool subFlg = false;

    void Start()
    {
        if (subFlg == true)
        {
            initPosition = opposedBackground.transform.position;
            initPositionSub = background.transform.position;
        }
        else
        {
            initPosition = background.transform.position;
            initPositionSub = opposedBackground.transform.position;
        }
        leftLine = (initPosition.x - initPositionSub.x) / 2;
    }
    void Update()
    {
        if (scrollFlg) { 
            Move();
        }else if(subFlg == false && transform.position != initPosition)
        {
            background.rectTransform.position = initPosition;
        }else if(subFlg == true && transform.position != initPositionSub)
        {
            background.rectTransform.position = initPositionSub;
        }
    }

    void Move()
    {
        transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime);   //X軸方向にスクロール
        //カメラの左端から完全に出たら、右端に瞬間移動
        if (transform.position.x < leftLine)
        {
            transform.position = initPositionSub;
        }
    }
}