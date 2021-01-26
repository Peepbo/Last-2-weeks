using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = new Vector3(
            Input.GetAxis("Horizontal") * moveSpeed,
            0,
            Input.GetAxis("Vertical") * moveSpeed
            );

        if (Input.GetButtonDown("360_A_Button"))
        {
            Debug.Log("Button Down A button!");
        }
        if (Input.GetButtonDown("360_B_Button"))
        {
            Debug.Log("Button Down B button!");
        }
        if (Input.GetButtonDown("360_X_Button"))
        {
            Debug.Log("Button Down X button!");
        }
        if (Input.GetButtonDown("360_Y_Button"))
        {
            Debug.Log("Button Down Y button!");
        }
    }
}
