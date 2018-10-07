using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    public bool Right = true;
    public bool jump = false;
    public float dashcount = 0;

    public float Force = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;
    public Transform groundCheck;

    private bool grounded = false;
    private Rigidbody2D rigid;
	private Animator anim;

    // Use this for initialization
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //sér hvort maður sé á gólfinu til að hoppa
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetButtonDown("Jump") && grounded || Input.GetKey(KeyCode.UpArrow) && grounded || Input.GetKey(KeyCode.W) && grounded)
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        if (h * rigid.velocity.x < maxSpeed)
            rigid.AddForce(Vector2.right * h * Force);

        if (Mathf.Abs(rigid.velocity.x) > maxSpeed)
            rigid.velocity = new Vector2(Mathf.Sign(rigid.velocity.x) * maxSpeed, rigid.velocity.y);

        if (h > 0 && !Right)
            Flip();
        else if (h < 0 && Right)
            Flip();

        if (jump)
        {
            rigid.AddForce(new Vector2(maxSpeed, jumpForce));
            jump = false;
        }
    }


    void Flip()
    {
        //flippar characterinum og sprite-inu ef ýtt er á hægri eða vinstri takkanum
        Right = !Right;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
