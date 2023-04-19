using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float walkForce = 5.0f;
    float maxWalkSpeed = 0.2f;

    float middle;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Rigidbody2D playerRigid = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRigid.AddForce(collision.GetContact(0).normal * -400f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();

        middle = this.transform.position.x;



    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        float playerLocation = player.transform.position.x;
        if((Mathf.Abs(this.transform.position.x - playerLocation) <= 1) && (Mathf.Abs(this.transform.position.y - player.transform.position.y) <= 1))
        {
            int key = 1;
            float speedx = Mathf.Abs(this.rigid2D.velocity.x);
            if (this.transform.position.x > playerLocation)
            {
                key = -1;

            }

            else if (this.transform.position.x < playerLocation)
            {
                key = 1;
            }

            if (key == 1)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            this.animator.speed = speedx / 2.0f;

            if (speedx < this.maxWalkSpeed)
            {
                float speedt = Time.deltaTime;
                this.rigid2D.AddForce(transform.right * key * this.walkForce);
                speedt += speedt;
            }

            if (transform.position.y < -20)
            {
                Destroy(this.gameObject);
            }
        }
        
        /**
        GameObject player = GameObject.FindWithTag("Player");
        float playerLocation = player.transform.position.x;
        int key = 1;
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);
        if (this.transform.position.x > playerLocation)
        {
            key = -1;

        }

        else if (this.transform.position.x < playerLocation)
        {
            key = 1;
        }

        if (key == 1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        this.animator.speed = speedx / 2.0f;

        if (speedx < this.maxWalkSpeed)
        {
            float speedt = Time.deltaTime;
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
            speedt += speedt;
        }

        if (transform.position.y < -20)
        {
            Destroy(this.gameObject);
        }
        **/
    }
}
