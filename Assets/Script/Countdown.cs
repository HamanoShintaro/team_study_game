using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
	public Text textCountdown;
	public GameObject mileage;


	// Start is called before the first frame update
	void Start()
    {
		mileage.gameObject.SetActive(false);
		StartCoroutine(CountdownCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	IEnumerator CountdownCoroutine()
	{

		textCountdown.text = "3";
		yield return new WaitForSeconds(1.0f);

		textCountdown.text = "2";
		yield return new WaitForSeconds(1.0f);

		textCountdown.text = "1";
		yield return new WaitForSeconds(1.0f);

		textCountdown.text = "GO!";
		yield return new WaitForSeconds(1.0f);

		textCountdown.text = "";
		textCountdown.gameObject.SetActive(false);
		mileage.gameObject.SetActive(true);

	}

}
