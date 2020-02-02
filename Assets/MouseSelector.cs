using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSelector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray();
            RaycastHit hit = new RaycastHit();
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.Log("クリックしました");

            //マウスクリックした場所からRayを飛ばし、オブジェクトがあればtrue 
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
            {
                Debug.Log(hit.transform.name + "にHitしました");
                if (hit.collider.gameObject.CompareTag("Node"))
                {
                    hit.collider.gameObject.GetComponent<StageNode>().SceneChange();
                    Debug.Log("Nodeを選択しました");
                }
            }
        }
    }
}
