using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultTextController : MonoBehaviour {

    private GameObject m_resultText;
    private bool m_endState;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //クリアを表示する関数
    public void ClearText()
    {
        m_resultText = GameObject.Find("ResultText");
        m_resultText.GetComponent<Text>().color = new Color(1, 1, 1, 1);
        m_resultText.GetComponent<Text>().text = "Cleard !!";
        if (Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    //ゲームオーバーを表示する関数
    public void GameOverText()
    {
        m_resultText = GameObject.Find("ResultText");
        m_resultText.GetComponent<Text>().color = new Color(1, 0, 0, 1);
        m_resultText.GetComponent<Text>().text = "Game Over";
        if (Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    //EndStateの値をget,setするためのプロパティ
    public bool EndState
    {
        get { return m_endState; }
        set { m_endState = value; }
    }
}
