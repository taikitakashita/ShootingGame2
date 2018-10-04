using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PowerController : MonoBehaviour {

    private GameObject m_powerSlider;
    private GameObject m_powerText;
    private ResultTextController m_resultTextController;

    [SerializeField]
    private int m_maxPower;

    [SerializeField]
    private int m_nowPower;

    // Use this for initialization
    void Start () {
        m_powerSlider = GameObject.Find("PowerSlider");
        m_powerSlider.GetComponent<Slider>().value = m_maxPower;

        m_powerText = GameObject.Find("PowerText");
        m_powerText.GetComponent<Text>().text = "Power " + m_maxPower + " / " + m_maxPower;
        m_resultTextController = FindObjectOfType<ResultTextController>();
    }
	
	// Update is called once per frame
	void Update () {

        float value = m_powerSlider.GetComponent<Slider>().value;

        if(value <= 0)
        {
            m_resultTextController.EndState = true;
            m_resultTextController.GameOverText();
        }
    }

    //現在の体力の値とスライダーを減らす関数
    public void NowPowerDown(int damage)
    {
        m_powerSlider = GameObject.Find("PowerSlider");
        m_powerText = GameObject.Find("PowerText");
        m_nowPower -= damage;

        m_powerSlider.GetComponent<Slider>().value = m_nowPower;
        m_powerText.GetComponent<Text>().text = "Power " + m_nowPower + " / " + m_maxPower;
    }

    //現在の体力の値とスライダーを増やす関数
    public void NowPowerUp(int power)
    {
        m_powerSlider = GameObject.Find("PowerSlider");
        m_powerText = GameObject.Find("PowerText");

        m_nowPower += power;

        if(m_nowPower > m_maxPower)
        {
            m_nowPower = m_maxPower;
        }
        m_powerSlider.GetComponent<Slider>().value = m_nowPower;
        m_powerText.GetComponent<Text>().text = "Power " + m_nowPower + " / " + m_maxPower;
    }
}
