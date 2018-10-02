using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    //EnemyPrefabを入れる
    [SerializeField]
    private GameObject[] m_enemyArray;

    //Enemyの出現数
    public int m_maxEnemy;

    //出現させたEnemyの数
    private int m_enemyNum;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int Enemy_posx = Random.Range(-40, 40);
        int Enemy_posz = Random.Range(40, 50);

        int num = Random.Range(1, 200);

        if (m_enemyNum < m_maxEnemy)
        {
            if (1 <= num && num <= 3)
            {
                //Enemy1_Prehubを生成
                GameObject enemy1 = Instantiate(m_enemyArray[0]) as GameObject;
                enemy1.transform.position = new Vector3(Enemy_posx, 0, Enemy_posz);
                m_enemyNum += 1;
            }
            else if (4 <= num && num <= 6)
            {
                //Enemy2_Prehubを生成
                GameObject enemy2 = Instantiate(m_enemyArray[1]) as GameObject;
                enemy2.transform.position = new Vector3(Enemy_posx, 0, Enemy_posz);
                m_enemyNum += 1;
            }
            else if (7 <= num && num <= 9)
            {
                //Enemy3_Prehubを生成
                GameObject enemy3 = Instantiate(m_enemyArray[2]) as GameObject;
                enemy3.transform.position = new Vector3(Enemy_posx, 0, Enemy_posz);
                m_enemyNum += 1;
            }
        }
    }
}
