using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 250.0f;
    float walkForce = 10.0f;
    float maxWalkSpeed = 2.0f;

    int jumps = 1;

    public float powerUpTime = 0f;
    public bool hasCoconut = false;
    public bool hasMango = false;


    bool isJumping = false;
    bool isAttacking = false;


    public GameObject attackRange;
    CircleCollider2D attackCircle;

    public void stopJump()
    {
        isJumping = false;
    }

    public void stopAttack()
    {
        isAttacking = false;
        attackRange.SetActive(false);
    }


    //when player collides with powerups, apply them, also handle jumping
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Reset Jump counter
        if(collision.gameObject.tag == "Branch")
        {
            if (hasMango)
            {
                jumps = 2;
            }
            else
            {
                jumps = 1;
            }

        }


        if(collision.gameObject.tag == "Coconut")
        {
            hasCoconut = true;
            hasMango = false; //only allow one powerup at a time
            powerUpTime = 10f;

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Mango")
        {
            hasMango = true;
            hasCoconut = false;//only allow one powerup at a time
            powerUpTime = 10f;

            Destroy(collision.gameObject);
        }
    }



    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();

        attackCircle = attackRange.GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        //handle any powerups
        if (powerUpTime > 0)
        {
            powerUpTime -= Time.deltaTime;  //decrement timer

            if (hasCoconut)
            {
                //increase attack range
                attackCircle.radius = 1f;
            }


            //when powerups run out, reset values
            if(powerUpTime <= 0)
            {
                attackCircle.radius = 0.5f;
                hasCoconut = false;
                hasMango = false;
            }

        }




        // Jump

        //only allow jumps if jump counter has room
        if (jumps > 0)
        {
            isJumping = false;
            this.animator.SetBool("isJumping", false);
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) //comparing directly to 0 doesn't work for some reason
            {
                this.rigid2D.AddForce(transform.up * this.jumpForce);
                this.animator.SetBool("isJumping", true);
                isJumping = true;
                this.animator.speed = 2.0f;
                jumps -= 1; //decrement jump counter
            }


        }




        if (Input.GetMouseButtonDown(0))
        {
            this.animator.SetTrigger("TriggerAttack");
            isAttacking = true;
            this.animator.speed = 2.0f;

            attackRange.SetActive(true);

        }



        // move left and right
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        // decide PC's speed
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        // limit PC's speed and avoid acceleration.
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        // reverse spring according to the direction
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        
        if (isJumping || isAttacking)
        {
            this.animator.speed = 2.0f;
        }
        else
        {
            this.animator.speed = speedx / 2.0f;
        }

        
      


    }
}
