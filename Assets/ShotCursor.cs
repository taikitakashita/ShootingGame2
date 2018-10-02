using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShotCursor : MonoBehaviour
{
    //　カーソルに使用するテクスチャ
    [SerializeField]
    private Texture2D cursor;

    private GameObject m_clearText;

    private GameObject m_enemyGenerator;
    private int m_maxEnemy;
    private int m_enemyNum = 0;


    void Start()
    {
        //　カーソルを自前のカーソルに変更
        Cursor.SetCursor(cursor, new Vector2(cursor.width / 2, cursor.height / 2), CursorMode.ForceSoftware);

        this.m_clearText = GameObject.Find("ClearText");

        m_enemyGenerator = GameObject.Find("EnemyGenerator");
        m_maxEnemy = m_enemyGenerator.GetComponent<EnemyGenerator>().m_maxEnemy;

    }

    void Update()
    {
        //　マウスの左クリックで撃つ
        if (Input.GetButtonDown("Fire1"))
        {
            Shot();
        }
        
        if (m_enemyNum == m_maxEnemy)
        {
            m_clearText.GetComponent<Text>().text = "Cleard !!";
            if (Input.GetMouseButtonDown(1))
            {
                SceneManager.LoadScene("GameScene");
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
            }
        }
    }
}