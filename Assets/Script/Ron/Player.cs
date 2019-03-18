    using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour {

	public float maxJumpHeight = 3f;
	public float minJumpHeight = 1.5f;
	public float timeToJumpApex = .4f;
	public float accelerationTimeGrounded = .1f;
	public float accelerationTimeAirborneMultiplier = 2f;

    public float timeInvincible = 2f;
    public Joystick joystick;

    bool invincible;
    bool forceApplied;

    float moveSpeed = 6f;
    float gravity;
    float maxJumpVelocity;
    float minJumpVelocity;
    Vector3 velocity;
    Vector2 movementInput;
    float velocityXSmoothing;

    Animator animator;
    SpriteRenderer spriteRenderer;

    public  Direction direction;
    public bool facingRight;
    // dash
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;

    public bool isDashing;

    public bool canMove;


    Controller2D controller;

    public Transform startPosition;

    public static Player instance;

    // publics
    public bool isFacingRight()
    {
       
        return facingRight;

    }

    public Direction GetDirection()
    {

        return direction;
    }

    public void ApplyDamage(float damage)
    {
        if (!invincible)
        {

            Debug.Log("Player took damage" + damage);
            SetVelocity(Vector2.up * 8.0f);
            StartCoroutine(SetInvincible());
        }


    }

    // privates


    public void Awake()
    {
        instance = this;
        dashTime = startDashTime;
        isDashing = false;

    }


    private void Start()
    {
        canMove = false;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        controller = GetComponent<Controller2D>();
		//Initialize Vertical Values
		gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
    }

    private void Update()
    {
		GetInput ();
        Animation();
        Horizontal ();
       
        Vertical ();
		ApplyMovement ();

    }


    private void GetInput()
    {
        if (!canMove)
            return;
        if (!isDashing)
        {
        
                // enable for mobile analog control
                movementInput = new Vector2(joystick.Horizontal, joystick.Vertical);
                // enable for keyboard control
          //     movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }

        direction = facingRight ? Direction.LEFT : Direction.RIGHT;

        // if moving horizontally
        if (movementInput.x != 0)
        {

            //for fliping the sprite!!
            direction = movementInput.x > 0 ? Direction.RIGHT : Direction.LEFT;

            facingRight = movementInput.x < 0;
        }

        float verticalAimFactor = movementInput.y;
        if (controller.collisions.below)
        {
            verticalAimFactor = Mathf.Clamp01(verticalAimFactor);
        }

        // looking vertically
        if (verticalAimFactor != 0)
        {
            direction = verticalAimFactor > 0 ? Direction.UP : Direction.DOWN;

        }
            // for dashing
           

    
    }
    void Animation()
    {
         spriteRenderer.flipX = facingRight;


        animator.SetFloat("VelocityX", Mathf.Abs(movementInput.x));
        animator.SetFloat("VelocityY", Mathf.Sign(velocity.y));
        animator.SetFloat("Looking", General.Direction2Vector(direction).y);
        animator.SetBool("Grounded", controller.collisions.below);


    }
    private void Vertical()
    {

        if (forceApplied)
        {
            forceApplied = false;


        }

       else if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
        }
        // jumping calling jump input by pressing a button
		if(CrossPlatformInputManager.GetButtonDown("Jump") && controller.collisions.below && !isDashing || Input.GetButtonDown("Jump") && controller.collisions.below && !isDashing)
        {
            velocity.y = maxJumpVelocity;
        }

        if (CrossPlatformInputManager.GetButtonUp("Jump") || Input.GetButtonUp("Jump"))
        {
            if (velocity.y > minJumpVelocity)
            {
                velocity.y = minJumpVelocity;
            }
        }

		velocity.y += gravity * Time.deltaTime;

    }

    // call this on button;
   public void Dash()
    {
        if (!isDashing && velocity.y != 0)
        {
            isDashing = true;
            FindObjectOfType<CameraShake>().CameraShaker();


        }
       

    }

    private void Horizontal()
    {
        if (!isDashing)
        {
            float targetVelocityX = movementInput.x * moveSpeed;
            velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing,
                accelerationTimeGrounded * (controller.collisions.below ? 1.0f : accelerationTimeAirborneMultiplier));
        }
        else {
            if (dashTime <= 0f)
            {


                dashTime = startDashTime;
                isDashing = false;


            }
            else
            {
                dashTime -= Time.deltaTime;

                if (facingRight)
                {

                    float targetVelocityX = -1f * dashSpeed;
                    velocity.x = Mathf.SmoothDamp(-1f, targetVelocityX, ref velocityXSmoothing,
                        accelerationTimeGrounded * (controller.collisions.below ? 1.0f : accelerationTimeAirborneMultiplier));
                }
                else
                {

                    float targetVelocityX = 1f * dashSpeed;
                    velocity.x = Mathf.SmoothDamp(1f, targetVelocityX, ref velocityXSmoothing,
                        accelerationTimeGrounded * (controller.collisions.below ? 1.0f : accelerationTimeAirborneMultiplier));
                }
            }
        }
    }

   


    private void ApplyMovement()
    {
        controller.Move(velocity * Time.deltaTime);
    }

    private void SetVelocity(Vector2 v)
    {
        velocity = v;
        forceApplied = true;

    }

    private IEnumerator SetInvincible()
    {
        invincible = true;
        float elapsedTime = 0f;
        while (elapsedTime < timeInvincible)
        {

            spriteRenderer.enabled = !spriteRenderer.enabled;
            elapsedTime += 0.04f;
            yield return new WaitForSeconds(0.04f);
       

        }

        spriteRenderer.enabled = true;
        invincible = false;


    }

    public void ToStartPoint()
    {

        transform.position = startPosition.position;
    }

}
