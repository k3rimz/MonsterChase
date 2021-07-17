using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float moveForce = 12;
    [SerializeField]
    private float jumpForce = 11f;
    [SerializeField]
    private float maxVelocity = 25f;


    private float movementX;

    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anim;

    private string WALK_ANIMATION = "walk";

    private bool isGrounded = true;

    private string ground_tag = "Ground";

    private string enemy_tag = "Enemy";


    private void awake()
    {

    }


    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        animatePlayer();
    }

    private void FixedUpdate()
    {
        PlayerJump();
    }


    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;

    }

    void animatePlayer()
    {

        if (movementX > 0)
        {
            anim.SetBool("walk", true);
        }
        else if (movementX < 0)
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }

    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            //Debug.Log("jump pressed");
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(ground_tag))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag(enemy_tag))
        {
            Destroy(gameObject);
        }

    }



}
