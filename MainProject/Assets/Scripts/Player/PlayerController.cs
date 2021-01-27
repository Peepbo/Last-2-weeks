using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Order")]
    public int index = 0;
    [Space]

    public float moveSpeed;
    float saveSpeed;
    public Animator anim;

    Rigidbody rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        saveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (index == ChoosePlayer.instance.order) PlayerMove();
        else
        {
            moveSpeed = 0;
            rigid.velocity = Vector3.zero;
        }
    }

    void PlayerMove()
    {
        moveSpeed = saveSpeed;

        Vector3 _angle = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 
                                     rigid.velocity.y,
                                     Input.GetAxis("Vertical") * moveSpeed);

        rigid.velocity = _angle;

        if (_angle != Vector3.zero &&
            (Mathf.Abs(Input.GetAxisRaw("Horizontal")) +
            Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.15f))
        {
            Vector3 _lookAngle = _angle;
            _lookAngle.y = 0;
            transform.rotation = Quaternion.LookRotation(_lookAngle);
        }

        RaycastHit hit;

        if (rigid.velocity == Vector3.zero)
            anim.SetInteger("animation", 1);
        else
            anim.SetInteger("animation", 2);
        //else if (Physics.Raycast(transform.position, Vector3.down, out hit, 2f))
        //{
        //    Debug.Log(hit.transform.name);

        //    anim.SetInteger("animation", 2);
        //}
        //else
        //{
        //    Debug.Log("jump");
        //    anim.SetInteger("animation", 3);
        //}

        Debug.DrawRay(transform.position, Vector3.down * 1f);

        if (Input.GetButtonDown("360_A_Button"))
        {
            //anim.SetInteger("animation", 3);
            rigid.AddForce(Vector3.up * 5f,ForceMode.Impulse);
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
        if (Input.GetButtonDown("360_LB_Button"))
        {
            Debug.Log("Player " + index);
            ChoosePlayer.instance.ChangeOrder();
        }
    }
}
