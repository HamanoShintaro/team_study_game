using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStage : MonoBehaviour
{
    public int minHeight;
    public int maxHeight;
    public float blockPosition;
    public GameObject block;

    // Start is called before the first frame update
    void Start()
    {
        ChangeHeight();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeHeight()
    {
        //ランダムな高さを生成して設定
        int height = Random.Range(minHeight, maxHeight);
        block.transform.localPosition = new Vector3(blockPosition, height, 0.0f);
        Debug.Log(height);
    }
}
