using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float walkForce = 5.0f;
    float maxWalkSpeed = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float playerLocation = player.transform.position.x;
        int key = 0;
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
}
