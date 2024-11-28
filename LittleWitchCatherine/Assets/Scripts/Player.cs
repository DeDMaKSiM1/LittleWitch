using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float BaseSpeed = 1f;

    private Rigidbody2D rbody;
    private Animator animator;
    private Vector2 movement;

    private readonly float runMultiply = 1.5f;
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
        bool isMoving = movement != Vector2.zero;

        animator.SetBool(IsWalking, isMoving);
        //�������� �� ��������
        if (!isMoving)
        {
            animator.SetBool(IsWalking, false);
            return;
        }
        //������������ ������� ��������
        if (movement.magnitude > 1)
            movement.Normalize();

        float speed = BaseSpeed;
        //�������� �� ���
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool(IsRunning, true);
            speed *= runMultiply;
        }
        else
        {
            animator.SetBool(IsRunning, false);
        }
        //��������� �������� �������� ��� �������� ��������
        animator.SetFloat(HorizontalMovingValue, movement.x);
        animator.SetFloat(VerticleMovingValue, movement.y);       

        rbody.MovePosition(rbody.position + speed * Time.fixedDeltaTime * movement);
    }
}


