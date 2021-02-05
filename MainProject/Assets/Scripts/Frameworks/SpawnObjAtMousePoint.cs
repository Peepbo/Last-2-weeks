using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjAtMousePoint : MonoBehaviour
{
    public GameObject obj;
    public int count;

    public bool isReverse = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            if (!isReverse)
            {
                Ray _ray;
                RaycastHit _hit;

                _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(_ray, out _hit))
                {
                    if (count < 5)
                    {
                        Instantiate(obj, _hit.point, Quaternion.identity);
                        count++;
                    }
                
                }
            }

        }
    }
}
