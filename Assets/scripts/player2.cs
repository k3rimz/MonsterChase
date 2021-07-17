using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour
{
 
    [SerializeField]
    private float moveForceP2 = 12;
    [SerializeField]
    private float jumpForceP2 = 11f;
    [SerializeField]
    private float maxVelocityP2 = 25f;


    private float movementXP2;

    private Rigidbody2D myBodyP2;

    private SpriteRenderer srP2;

    private Animator animP2;

    private string WALK_ANIMATIONP2 = "player_2_walk";

    private bool isGrounded = true;

    private string ground_tag = "Ground";

    private string enemy_tag = "Enemy";


    private void awake()
    {

    }


    // Start is called before the first frame update
    void Start()
    {
        myBodyP2 = GetComponent<Rigidbody2D>();
        animP2 = GetComponent<Animator>();

        srP2 = GetComponent<SpriteRenderer>();
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
        movementXP2 = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementXP2, 0f, 0f) * Time.deltaTime * moveForceP2;

    }

    void animatePlayer()
    {

        if (movementXP2 > 0)
        {
            animP2.SetBool(WALK_ANIMATIONP2, true);
        }
        else if (movementXP2 < 0)
        {
            animP2.SetBool(WALK_ANIMATIONP2, true);
        }
        else
        {
            animP2.SetBool(WALK_ANIMATIONP2, false);
        }

    }
    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            //Debug.Log("jump pressed");
            isGrounded = false;
            myBodyP2.AddForce(new Vector2(0f, jumpForceP2), ForceMode2D.Impulse);
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

