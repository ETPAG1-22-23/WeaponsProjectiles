using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animController;
    float moveSpeed_horizontal = 400f;
    float moveSpeed_vertical = 0.5f;
    float horizontal_value;
    float vertical_value;
    [SerializeField] bool is_jumping = false;
    [SerializeField] bool can_jump = false;
    [SerializeField] float jumpforce = 10f;
    float current = 50.0f;
    float target = 300.0f;
    [Range(0, 1)][SerializeField] float smooth_time = 0.5f;
    Vector2 ref_velocity = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animController = GetComponent<Animator>();
        Debug.Log(Mathf.Lerp(current, target, 0));
    }

    // Update is called once per frame
    void Update()
    {
        horizontal_value = Input.GetAxis("Horizontal");

        animController.SetFloat("speed", Mathf.Abs (horizontal_value));
        sr.flipX = horizontal_value < 0;

        vertical_value = Input.GetAxis("Vertical");
        if (Input.GetButtonDown("Jump") && can_jump)
        {
            is_jumping = true;
            animController.SetBool("jumping", true);
        }
    }
    void FixedUpdate()
    {
        if (is_jumping && can_jump)
        {
            is_jumping = false;
            rb.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
            can_jump = false;
        }
        Vector2 target_velocity = new Vector2(horizontal_value * moveSpeed_horizontal * Time.fixedDeltaTime, rb.velocity.y);
        rb.velocity = Vector2.SmoothDamp(rb.velocity, target_velocity, ref ref_velocity, smooth_time);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        can_jump = true;
        Debug.Log(collision.gameObject.tag);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        animController.SetBool("jumping", false);
    }
}
