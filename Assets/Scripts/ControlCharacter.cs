using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCharacter : MonoBehaviour
{
    Animator _anim;

    private bool atack;
    public bool grounded;
    private float inputY;
    private float inputX;
    public float jumpPower;
    public Rigidbody2D rb2d;

    public bool walking;
    public bool jump;

    Collider2D collision;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _anim.SetBool("walking", walking);
        _anim.SetBool("atack", atack);
        //_anim.SetBool("jump", jump);
    }

    /// <summary>
    /// En esta función creamos los movimientos
    /// dependiendo de los botones presionados
    /// </summary>
    void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            float direction = Input.GetAxis("Horizontal") <= 0 ? -180f : 0f;
            transform.Translate(Vector2.right * 3f * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, direction);
            walking = true;
        }
        else
        {
            walking = false;
        }

        if ((Input.GetAxis("Vertical") > 0) && grounded)
        {
            inputY = Input.GetAxisRaw("Vertical");
            rb2d.velocity = Vector2.up * jumpPower;
        }

        atack = Input.GetKey(KeyCode.R) ? true : false;
    }
}
