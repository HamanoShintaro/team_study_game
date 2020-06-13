using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SpriteRandom : MonoBehaviour
{
    public int minHeight;
    public int maxHeight;
    public float block1Position;
    public float block2Position;
    public float block3Position;
    public float block4Position;
    public GameObject block1;
    public GameObject block2;
    public GameObject block3;
    public GameObject block4;


    void ChangeHeight()
    {
        //ランダムな高さを生成して設定
        int height = Random.Range(minHeight, maxHeight);
        block1.transform.localPosition = new Vector3(block1Position, height, 0.0f);
        block2.transform.localPosition = new Vector3(block2Position, height, 0.0f);
        block3.transform.localPosition = new Vector3(block3Position, height, 0.0f);
        block4.transform.localPosition = new Vector3(block4Position, height, 0.0f);
        Debug.Log(height);
    }

    //ScrollObjectスクリプトからのメッセージを受け取って高さを変更
    void OnScrollEnd()
    {
        ChangeHeight();
    }
}
