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


    bool isJumping = false;
    bool isAttacking = false;


    public GameObject attackRange;

    public void stopJump()
    {
        isJumping = false;
    }

    public void stopAttack()
    {
        isAttacking = false;
        attackRange.SetActive(false);
    }

    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Jump
        if (this.rigid2D.velocity.y < 0.0001)
        {
            isJumping = false;
            this.animator.SetBool("isJumping", false);
            if (Input.GetKeyDown(KeyCode.Space)) //comparing directly to 0 doesn't work for some reason
            {
                this.rigid2D.AddForce(transform.up * this.jumpForce);
                this.animator.SetBool("isJumping", true);
                isJumping = true;
                this.animator.speed = 2.0f;

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

        
        
        /**
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("MonkeyWalk"))
        {
            this.animator.speed = speedx / 2.0f;
        }

        else
        {
            this.animator.speed = 2.0f;
        }
        **/


    }
}
