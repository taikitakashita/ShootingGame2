using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private GameObject m_canvas;

    private GameObject m_powerSlider;
    private GameObject m_powerText;

    [SerializeField]
    private float m_moveSpeed;

    [SerializeField]
    private int[] m_enemyDamageArray;

    private Animator m_anim;

    // Use this for initialization
    void Start()
    {
        m_canvas = GameObject.Find("Canvas");
        m_powerSlider = GameObject.Find("PowerSlider");
        m_powerText = GameObject.Find("PowerText");

        m_anim = GetComponent<Animator>();
        m_anim.SetInteger("battle", 1);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 NowPosition = transform.position;
        Vector3 TargetPosition = GameObject.Find("Player").transform.position;

        float distance = Vector3.Distance(NowPosition, TargetPosition);
        float step = m_moveSpeed * Time.deltaTime;

        if (distance > 5)
        {
            transform.position = Vector3.MoveTowards(NowPosition, TargetPosition, step);
            m_anim.SetInteger("moving", 2);
            this.transform.LookAt(TargetPosition);
        }
        else
        {
            m_anim.SetInteger("moving", 0);
            int num = Random.Range(1, 300);
            if (num < 2)
            {
                m_anim.SetInteger("moving", 3);
                m_powerSlider.GetComponent<Slider>().value -= m_enemyDamageArray[0];
                m_powerText.GetComponent<Text>().text = "Power " + m_powerSlider.GetComponent<Slider>().value + " / 200";
            }
        }
    }
}
