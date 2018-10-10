using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {

    GameObject m_stopButton;
    GameObject m_startButton;
    GameObject m_retryButton;


    // Use this for initialization
    void Start () {
        m_stopButton = GameObject.Find("StopButton");
        m_startButton = GameObject.Find("StartButton");
        m_retryButton = GameObject.Find("RetryButton");

        m_startButton.SetActive(false);
        m_retryButton.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void StopButtonDown()
    {
        m_stopButton.SetActive(false);
        m_startButton.SetActive(true);
        m_retryButton.SetActive(true);

        Time.timeScale = 0;
    }

    public void StartButtonDown()
    {
        m_stopButton.SetActive(true);
        m_startButton.SetActive(false);
        m_retryButton.SetActive(false);

        Time.timeScale = 1;
    }

    public void RetryButtonDown()
    {
        m_stopButton.SetActive(true);
        m_startButton.SetActive(false);
        m_retryButton.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }
}
