using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private Image playerImage;
    private CharacterController characterController;
    private float velocity;
    private Vector3 initPosition;
    public float gravity;
    public float jump;

    // Start is called before the first frame update
    void Start()
    {
        playerImage = GetComponent<Image>();
        initPosition = new Vector3(30.0f, 30.0f, 0.0f);
        playerImage.transform.position = initPosition;
        velocity = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (playerImage.transform.position.y <= initPosition.y)
        {
            if (velocity < 0.0f)
            {
                velocity = 0.0f;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("ジャンプします");
                velocity = jump;
            }
        }
        else if (playerImage.transform.position.y > initPosition.y) 
        {
            velocity = velocity - gravity * Time.deltaTime;
        }
        playerImage.transform.position = new Vector3(playerImage.transform.position.x, playerImage.transform.position.y + velocity * Time.deltaTime, 0.0f);

    }
}
