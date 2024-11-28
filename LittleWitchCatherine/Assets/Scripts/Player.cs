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
        //�����
        if (movement == Vector2.zero)
        {
            animator.SetBool(IsWalking, false);
            animator.SetBool(IsRunning, false);
        }
        //��������
        else
        {
            //������������ ������� ��������
            if (movement.magnitude > 1)
                movement.Normalize();

            //�������� �� ��������
            animator.SetBool(IsWalking, true);
            //�������� ������� �� ���
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


            //��������� �������� �������� ��� �������� ��������
            animator.SetFloat(HorizontalMovingValue, movement.x);
            animator.SetFloat(VerticleMovingValue, movement.y);

            rbody.MovePosition(rbody.position + speed * Time.fixedDeltaTime * movement);
        }
    }

    private void SetAnimatorConditions()
    {

    }
}
