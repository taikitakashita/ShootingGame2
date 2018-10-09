using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoblinController : MonoBehaviour
{
    private GameObject m_damageImage;
    private ResultTextController m_resultTextController;
    private PowerController m_powerController;
    private Animator m_anim;

    [SerializeField]
    private float m_moveSpeed;

    [SerializeField]
    private int m_enemyDamage;

    [SerializeField]
    private int m_moveStopDistance;

    private AudioSource m_audioSource;

    [SerializeField]
    private AudioClip m_attackSound;

    // Use this for initialization
    void Start()
    {
        m_anim = GetComponent<Animator>();
        m_anim.SetInteger("battle", 1);

        m_resultTextController = FindObjectOfType<ResultTextController>();
        m_powerController = FindObjectOfType<PowerController>();

        m_damageImage = GameObject.Find("DamageImage");
        m_damageImage.GetComponent<Image>().color = Color.clear;

        m_audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 NowPosition = transform.position;
        Vector3 TargetPosition = GameObject.Find("Player").transform.position;

        float distance = Vector3.Distance(NowPosition, TargetPosition);
        float step = m_moveSpeed * Time.deltaTime;

        this.transform.LookAt(TargetPosition);

        if (distance > m_moveStopDistance )
        {
            transform.position = Vector3.MoveTowards(NowPosition, TargetPosition, step);
            m_anim.SetInteger("moving", 2);
        }
        else
        {
            m_anim.SetInteger("moving", 0);

            if (m_resultTextController.EndState == false)
            {
                int num = Random.Range(1, 300);
                if (num < 2)
                {
                    m_anim.SetInteger("moving", 3);
                    m_damageImage.GetComponent<Image>().color = new Color(0.5f, 0f, 0f, 0.5f);
                    m_powerController.NowPowerDown(m_enemyDamage);
                    m_audioSource.PlayOneShot(m_attackSound);
                }
                m_damageImage.GetComponent<Image>().color = Color.Lerp(m_damageImage.GetComponent<Image>().color, Color.clear, Time.deltaTime);
            }
        }
    }
}
