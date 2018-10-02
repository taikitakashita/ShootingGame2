using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PowerController : MonoBehaviour {

    private GameObject m_powerSlider;
    private GameObject m_gameOverText;

    private float m_power = 200;

    // Use this for initialization
    void Start () {
        m_powerSlider = GameObject.Find("PowerSlider");
        m_gameOverText = GameObject.Find("GameOverText");
    }
	
	// Update is called once per frame
	void Update () {

        float value = m_powerSlider.GetComponent<Slider>().value;

        if(value <= 0)
        {
            this.m_gameOverText.GetComponent<Text>().text = "GameOver";
            if (Input.GetMouseButtonDown(1))
            {
                SceneManager.LoadScene("GameScene");
            }
        }
    }
}
