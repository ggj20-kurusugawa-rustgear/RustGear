using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearRotation : MonoBehaviour
{
    float speed;       //ギアの回転


    // Start is called before the first frame update
    void Start()
    {
        speed = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, speed);
    }
}
