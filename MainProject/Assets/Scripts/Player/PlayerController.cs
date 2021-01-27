using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Order")]
    public int index = 0;
    [Space]

    [Header("Stat")]
    public float moveSpeed;
    public float jumpForce = 5f;
    [Space]
    public Animator anim;

    float saveSpeed;

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
            rigid.velocity = Vector3.down * 2f;
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

        Vector3 _checkVelocity = rigid.velocity;
        _checkVelocity.y = 0;

        if (_checkVelocity == Vector3.zero)
            anim.SetInteger("animation", 1);
        else
            anim.SetInteger("animation", 2);


        Debug.DrawRay(transform.position, Vector3.down * 1.5f);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f))
        {
            anim.SetBool("isGround", true);
        }
        else anim.SetBool("isGround", false);


        if (Input.GetButtonDown("360_A_Button"))
        {
            anim.SetTrigger("Jump");
            rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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
