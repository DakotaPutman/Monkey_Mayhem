using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float flySpeed = 1.5f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
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
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * flySpeed);

    }
}
