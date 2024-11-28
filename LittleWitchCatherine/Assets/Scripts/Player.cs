using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float BaseSpeed = 1f;

    private Rigidbody2D rbody;
    private Vector2 movement;
    private Animator animator;

    private readonly string HorizontalMovingValue = "HorizontalValue";
    private readonly string VerticleMovingValue = "VerticleValue";
    private readonly string IsWalking = "IsWalking";
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
        //Покой
        if (movement == Vector2.zero)
        {
            animator.SetBool(IsWalking, false);
            animator.SetBool(IsRunning, false);
        }
        //Движение
        else
        {
            //Нормализация вектора движения
            if (movement.magnitude > 1)
                movement.Normalize();

            //Проверка на движение
            animator.SetBool(IsWalking, true);
            //Проверка условия на бег
            var speed = BaseSpeed;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool(IsRunning, true);
                speed *= 2;
            }
            else
            {
                animator.SetBool(IsRunning, false);                
            }


            //Установка значения движения для анимаций движения
            animator.SetFloat(HorizontalMovingValue, movement.x);
            animator.SetFloat(VerticleMovingValue, movement.y);

            rbody.MovePosition(rbody.position + speed * Time.fixedDeltaTime * movement);
        }
    }

    private void SetAnimatorConditions()
    {

    }
}
