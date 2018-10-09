using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShotCursor : MonoBehaviour
{
    //　カーソルに使用するテクスチャ
    [SerializeField]
    private Texture2D cursor;

    private EnemyGenerator m_enemyGenerator;
    private ResultTextController m_resultTextController;
    private PowerController m_powerController;

    //敵の最大数と倒した数の変数
    private int m_maxEnemy;
    private int m_enemyNum;

    [SerializeField]
    private GameObject m_item;

    [SerializeField]
    private int m_itemPower;

    void Start()
    {
        //　カーソルを自前のカーソルに変更
        Cursor.SetCursor(cursor, new Vector2(cursor.width / 2, cursor.height / 2), CursorMode.ForceSoftware);

        //MaxEnemyの値の取得
        m_enemyGenerator = FindObjectOfType<EnemyGenerator>();
        m_maxEnemy = m_enemyGenerator.MaxEnemy;

        m_resultTextController = FindObjectOfType<ResultTextController>();

        m_powerController = FindObjectOfType<PowerController>();
    }

    void Update()
    {
        // すべての敵を倒したらクリアを表示する
        if (m_enemyNum == m_maxEnemy)
        {
            m_resultTextController.EndState = true;
            m_resultTextController.ClearText();
        }
        else
        {
            if (m_resultTextController.EndState == false)
            {
                //　マウスの左クリックで撃つ
                if (Input.GetButtonDown("Fire1"))
                {
                    Shot();
                }
            }

        }
    }

    //　敵を撃つ
    void Shot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 hitPosition;
        GameObject hitParticle = GameObject.Find("HitParticle");

        if (Physics.Raycast(ray, out hit, 30f, LayerMask.GetMask("Enemy")))
        {
            hit.collider.gameObject.GetComponentInChildren<Canvas>().GetComponentInChildren<Slider>().value -= 1;

            if (hit.collider.gameObject.GetComponentInChildren<Canvas>().GetComponentInChildren<Slider>().value == 0)
            {
                //敵のオブジェクトを消す
                hitPosition = hit.collider.gameObject.GetComponent<Collider>().bounds.center;
                Destroy(hit.collider.gameObject);
                m_enemyNum += 1;

                //敵を倒した時のParticleを再生する。
                hitParticle.transform.position = new Vector3(hitPosition.x, hitPosition.y, hitPosition.z);
                hitParticle.GetComponent<ParticleSystem>().Play();

                //回復アイテムを落とす

                int num = Random.Range(1, 100);
                if (num <= 20)
                {
                    GameObject item = Instantiate(m_item) as GameObject;
                    item.transform.position = new Vector3(hitPosition.x, hitPosition.y, hitPosition.z);
                    float itemRotx = Random.Range(0, 360);
                    float itemRoty = Random.Range(0, 360);
                    float itemRotz = Random.Range(0, 360);
                    item.transform.rotation = Quaternion.Euler(itemRotx, itemRoty, itemRotz);
                }
            }
        }
        if (Physics.Raycast(ray, out hit, 30f, LayerMask.GetMask("Item")))
        {
            Destroy(hit.collider.gameObject);
            m_powerController.NowPowerUp(m_itemPower);
        }
    }

    //EnemyNumの値をget,setするためのプロパティ
    public int EnemyNum
    {
        get { return m_enemyNum; }
        private set { m_enemyNum = value; }
    }
}