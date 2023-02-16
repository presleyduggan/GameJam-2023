using UnityEngine;

public class CharacterController : MonoBehaviour {
    private Rigidbody2D rb;
    public float speed;

    public float walkSpeed;
    public float runSpeed;
    private float moveInput;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    public float jumpForce;
    //public float jumpTimeValue;

    public Animator characterAnimator;


    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;
        speed = walkSpeed;
        transform.SetParent(null);
        characterAnimator = GetComponent<Animator>();
        
    }

    private void Update() {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        // check if running
        if(Input.GetKey(KeyCode.LeftShift)){
            speed = runSpeed;
        } else{
            speed = walkSpeed;
        }

        // flip character

        if(moveInput > 0){
            transform.eulerAngles = new Vector3(0,0,0);
            characterAnimator.SetBool("isMoving", true);
        } else if(moveInput < 0){
            transform.eulerAngles = new Vector3(0,180,0);
            characterAnimator.SetBool("isMoving", true);
        } else {
            characterAnimator.SetBool("isMoving", false);
        }

        // jump
        if(isGrounded && Input.GetKeyDown(KeyCode.Space)){
            rb.velocity = Vector2.up * jumpForce;
            isJumping = true;
            jumpTimeCounter = jumpTime;
        }

        // hold jump
        if(Input.GetKey(KeyCode.Space) && isJumping){
            if(jumpTimeCounter > 0){
            rb.velocity = Vector2.up * jumpForce;
            jumpTimeCounter -= Time.deltaTime;
            } else{
                isJumping = false;
            }
        }

        if(Input.GetKeyUp(KeyCode.Space)){
            isJumping = false;
        }
    }

    private void FixedUpdate() {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }
}