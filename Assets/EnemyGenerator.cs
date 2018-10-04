using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    //EnemyPrefabを入れる
    [SerializeField]
    private GameObject[] m_enemyArray;

    //Enemyの出現数
    [SerializeField]
    private int m_maxEnemy;

    //出現させたEnemyの数
    private int m_enemyNum;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Enemyを出現させる座標の設定
        int Enemy_posx = Random.Range(-30, 30);
        int Enemy_posz = Random.Range(40, 50);

        int num = Random.Range(1, 200);

        if (m_enemyNum < m_maxEnemy)
        {
            if (1 <= num && num <= 4)
            {
                //Enemy1を生成
                GameObject enemy1 = Instantiate(m_enemyArray[0]) as GameObject;
                enemy1.transform.position = new Vector3(Enemy_posx, 0, Enemy_posz);
                m_enemyNum += 1;
            }
            else if (5 <= num && num <= 6)
            {
                //Enemy2を生成
                GameObject enemy2 = Instantiate(m_enemyArray[1]) as GameObject;
                enemy2.transform.position = new Vector3(Enemy_posx, 10, Enemy_posz);
                m_enemyNum += 1;
            }
            else if (7 <= num && num <= 9)
            {
                //Enemy3を生成
                GameObject enemy3 = Instantiate(m_enemyArray[2]) as GameObject;
                enemy3.transform.position = new Vector3(Enemy_posx, 0, Enemy_posz);
                m_enemyNum += 1;
            }
        }
    }

    //MaxEnemyの値をget,setするためのプロパティ
    public int MaxEnemy
    {
        get { return m_maxEnemy; }
        private set { m_maxEnemy = value; }
    }
}
