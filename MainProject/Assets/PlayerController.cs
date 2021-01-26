using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Animator anim;
    Rigidbody rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 _angle = new Vector3(Input.GetAxis("Horizontal"), 0,
        Input.GetAxis("Vertical"));

        rigid.velocity = _angle * moveSpeed;

        if(_angle != Vector3.zero &&
            (Mathf.Abs( Input.GetAxisRaw("Horizontal")) + 
            Mathf.Abs( Input.GetAxisRaw("Vertical")) > 0.15f))
        {
            transform.rotation = Quaternion.LookRotation(_angle);
        }

        if(rigid.velocity == Vector3.zero) 
            anim.SetInteger("animation", 1);
        else 
            anim.SetInteger("animation", 2);


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
