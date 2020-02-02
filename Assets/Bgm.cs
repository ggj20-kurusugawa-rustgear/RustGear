using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bgm : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // シーンが変わってもBGMが流れ続けるようにする
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
