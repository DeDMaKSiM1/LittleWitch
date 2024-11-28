using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float Speed = 1f;

    private Rigidbody2D rbody;
    private Vector2 movement;
    private Animator animator;

    private readonly string HorizontalMovingValue = "HorizontalValue";
    private readonly string VerticleMovingValue = "VerticleValue";
    private readonly string IsRunning = "IsRunning";
    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    private void FixedUpdate()
    {       
        //idle
        if(movement == Vector2.zero)
        {
            animator.SetBool(IsRunning, false);
        }
        else
        {
            if (movement.magnitude > 1)
                movement.Normalize();
            animator.SetBool(IsRunning, true);
            animator.SetFloat(HorizontalMovingValue, movement.x);
            animator.SetFloat(VerticleMovingValue, movement.y);
            Debug.Log(movement);
            rbody.MovePosition(rbody.position + Speed * Time.fixedDeltaTime * movement);
        }
        
       


    }
}
