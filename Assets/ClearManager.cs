using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearManager : MonoBehaviour
{
    bool m_lock = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.childCount == 0)
        {
            if(!m_lock)
            {
                SceneManager.LoadSceneAsync("ClearResult", LoadSceneMode.Additive);
            }
            m_lock = true;
        }
    }
}
