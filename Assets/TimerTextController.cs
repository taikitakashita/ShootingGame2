using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerTextController : MonoBehaviour
{
    private GameObject m_timerText;
    private GameObject m_gameOverText;

    [SerializeField]
    private float m_remainingTime;

    // Use this for initialization
    void Start()
    {
        this.m_timerText = GameObject.Find("TimerText");
        this.m_gameOverText = GameObject.Find("GameOverText");
    }

    // Update is called once per frame
    void Update()
    {
        if (m_remainingTime >= 0)
        {
            m_remainingTime -= Time.deltaTime;
            int seconds = (int)m_remainingTime;
            m_timerText.GetComponent<Text>().text = "Time " + seconds + "s";
        }
        else
        {
            m_gameOverText.GetComponent<Text>().text = "GameOver";
            if (Input.GetMouseButtonDown(1))
            {
                SceneManager.LoadScene("GameScene");
            }
        }
    }
}