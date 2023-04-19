using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaguarController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float walkSpeed = 1.0f;

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

        GameObject player = GameObject.FindWithTag("Player");
        float playerLocation = player.transform.position.x;
        if ((Mathf.Abs(this.transform.position.x - playerLocation) <= 3) && (Mathf.Abs(this.transform.position.y - player.transform.position.y) <= 3))
        {
            int key = 0;
            if (this.transform.position.x > playerLocation)
            {
                transform.Translate(Vector2.left * Time.deltaTime * walkSpeed);
                key = -1;


            }

            else if (this.transform.position.x < playerLocation)
            {
                transform.Translate(Vector2.right * Time.deltaTime * walkSpeed);
                key = 1;
            }

            transform.localScale = new Vector3(key, 1, 1);

        }
        

    }
}
