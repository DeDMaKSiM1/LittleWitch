using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float Speed = 1f;

    private Rigidbody2D rbody;
    private Vector2 movement;
    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Debug.Log(movement);
    }
    private void FixedUpdate()
    {        
        if (movement.magnitude > 1)
            movement.Normalize();
        rbody.MovePosition(rbody.position + Speed * Time.fixedDeltaTime * movement);

    }
}
