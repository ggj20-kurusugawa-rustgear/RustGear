using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fun : MonoBehaviour
{
    public GameObject m_connect_Gear;
    public GameObject[] m_dusts;

    public AudioClip m_moveFun;
    bool m_move;
    AudioSource m_audioSource;
    public ParticleSystem m_particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        m_move = false;
        m_audioSource = this.gameObject.AddComponent<AudioSource>();
        m_audioSource.volume = 0.5f;
        m_particleSystem.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        // 接続した歯車が動いているとき
        if(m_connect_Gear.GetComponent<Gear>().m_move)
        {
            for (int i = 0; i < m_dusts.Length; i++)
            {
                m_dusts[i].transform.position += transform.right * -0.05f;
                m_dusts[i].transform.localRotation = Quaternion.Euler(0, 0, Time.fixedTime * 1000);
            }
            if (!m_move)
            {
                m_audioSource.PlayOneShot(m_moveFun);
                m_particleSystem.Play();
            }
            m_move = true;
        }
    }
}
