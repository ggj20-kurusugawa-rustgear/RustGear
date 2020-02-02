using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gear : MonoBehaviour
{
    public GameObject[] m_connect_Rusts;
    public GameObject[] m_connect_Gears;

    AudioSource audioSource;
    public AudioClip sound_moving_gear;
    public AudioClip sound_not_moving_gear;

    public TextMesh powerCounter;
    public Text textCounter;
    public bool m_move;
    public int m_power = 1;
    float m_delay = 0;
    public float m_delayTime = 0;
    public float m_rotationDir;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = transform.parent.GetComponent<AudioSource>();
        if (m_connect_Rusts.Length != 0)
        {
            m_move = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // パワーが無かったら
        if (m_power == 0)
        {
            for (int i = 0; i < m_connect_Gears.Length; i++)
            {
                if(m_connect_Gears[i].GetComponent<Gear>().m_move)
                {
                    m_power = 1;
                    this.transform.Rotate(Vector3.back, Time.deltaTime * 100 * m_rotationDir);
                    break;
                }
            }
        }
        // パワーがあって、錆が無ければ
        else if(m_connect_Rusts.Length == 0)
        {
            m_move = true;
            this.transform.Rotate(Vector3.back, Time.deltaTime * 100 * m_rotationDir);
        }

        // 外からかかっているパワーの計算
        int power = 0;
        for (int i = 0; i < m_connect_Gears.Length; i++)
        {
            if(m_connect_Gears[i].GetComponent<Gear>().m_move == true)
            {
                power += m_connect_Gears[i].GetComponent<Gear>().m_power;
            }
        }

        if (power >= m_connect_Rusts.Length + 1)
        {
            m_delay += Time.deltaTime;
            if (m_delay >= m_delayTime && m_connect_Rusts.Length > 0)
            {
                RustRemovalAll();
            }
        }

        // テキストに表示
        powerCounter.text = power.ToString();

        powerCounter.transform.rotation = Quaternion.identity;
    }

    public void RustRemoval()
    {
        if(m_connect_Rusts.Length == 1 && m_power > 0)
        {
            Debug.Log("click moving gear");
            Debug.Log("count value=" + textCounter.text);
            String strCount = textCounter.text.Split(':')[1];
            int count = int.Parse(strCount);
            textCounter.text = "Count:"+(count + 1).ToString();
            audioSource.PlayOneShot(this.sound_moving_gear);
            Destroy(m_connect_Rusts[0]);
            Array.Resize<GameObject>(ref m_connect_Rusts,0);
        }
        else
        {
            if (!this.m_move) {
                audioSource.PlayOneShot(this.sound_not_moving_gear);
                Debug.Log("click not moving gear");
            }
        }
    }

    public void RustRemovalAll()
    {
        for (int i = 0; i < m_connect_Rusts.Length; i++)
        {
            Destroy(m_connect_Rusts[i]);
        }
        audioSource.PlayOneShot(this.sound_moving_gear);
        Array.Resize<GameObject>(ref m_connect_Rusts, 0);
    }

    public void RustRemoval(GameObject rust)
    {
        for (int i = 0; i < m_connect_Rusts.Length; i++)
        {
            if(m_connect_Rusts[i].gameObject == rust)
            {
                // 要素を削除する
                Array.Clear(m_connect_Rusts, i, 1);

                // 配列を詰める
                List<GameObject> list = new List<GameObject>(m_connect_Rusts);
                list.Remove(null);
                m_connect_Rusts = list.ToArray();

                return;
            }
        }
    }
}
