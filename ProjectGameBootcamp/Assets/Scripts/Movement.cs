using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Collider2D colliderCrouch;
    public Collider2D colliderBody;
    public Transform groundCheck;
    public LayerMask groundLayer;
    //[SerializeField] private Animator anim;
    public float groundRadius = 0.15f;
    bool isGrounded;    
    float speed = 5f;
    public Rigidbody2D rb;
    private bool facingRight = true;
    //float mx, my;
    [SerializeField] float jumpPower;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        colliderCrouch.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // my = Input.GetAxisRaw("Vertical");
        //mx = Input.GetAxisRaw("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
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
           // anim.SetTrigger("Move");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            position.x += speed * Time.deltaTime;
            //sanim.SetTrigger("Move");
        }
        transform.position = position;
        if (Input.GetKeyDown(KeyCode.S))
        {
            colliderCrouch.enabled = true;
            colliderBody.enabled = false;

            jumpPower = 0;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            colliderBody.enabled = true;
            colliderCrouch.enabled = false;
            jumpPower = 5;
        }
        FlipController();
    }
    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }

    private void FlipController()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePos.x < transform.position.x && facingRight)
            Flip();
        else if (mousePos.x > transform.position.x && !facingRight)
            Flip();
    }


    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}
