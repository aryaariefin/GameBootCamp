using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Collider2D colliderhead;
    public Transform groundCheck;
    public LayerMask groundLayer;
    bool isGrounded;
    float speed = 5f;
    public Rigidbody2D rb;
    //float mx, my;
    [SerializeField] float jumpPower;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // my = Input.GetAxisRaw("Vertical");
        //mx = Input.GetAxisRaw("Horizontal");
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1.0f, 0.15f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            Debug.Log("SPACE");
            //rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
        /*}else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(mx, my) * speed;
        }*/
        Vector3 position = transform.position;

        // Update the position of the player based on the input
        if (Input.GetKey(KeyCode.A))
        {
            position.x -= speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            position.x += speed * Time.deltaTime;
        }
        transform.position = position;
        if (Input.GetKeyDown(KeyCode.S))
        {
            colliderhead.enabled = false;
            jumpPower = 0;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            colliderhead.enabled = true;
            jumpPower = 5;
        }
    }
}
