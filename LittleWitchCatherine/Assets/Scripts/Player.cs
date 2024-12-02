using Unity.Cinemachine;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float BaseSpeed = 1.8f;

    private Rigidbody2D rbody;
    private Animator animator;
    private Vector2 movement;
    private CinemachineCamera cinemaCamera;
  
    private const float runMultiply = 1.5f;
    private const string HorizontalMovingValue = "HorizontalValue";
    private const string VerticleMovingValue = "VerticleValue";
    private const string IsWalking = "IsWalking";
    private const string IsRunning = "IsRunning";

    private void Awake()
    {
        cinemaCamera = FindFirstObjectByType<CinemachineCamera>();
        cinemaCamera.Follow = transform;


    }
    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //Camera.main.transform.position = new Vector3(transform.position.x, transform.position.x, -11f);

    }
    private void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    private void FixedUpdate()
    {
        MovementCheck();
    }

    public void Interact()
    {
        
    }

    private void MovementCheck()
    {
        bool isMoving = movement != Vector2.zero;

        animator.SetBool(IsWalking, isMoving);
        //Проверка на движение
        if (!isMoving)
        {
            animator.SetBool(IsWalking, false);
            animator.SetBool(IsRunning, false);
            if (rbody.linearVelocity != Vector2.zero)
                rbody.linearVelocity = Vector2.zero;
            return;
        }
        //Нормализация вектора движения
        if (movement.magnitude > 1)
            movement.Normalize();

        float speed = BaseSpeed;
        //Проверка на бег
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool(IsRunning, true);
            speed *= runMultiply;
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


