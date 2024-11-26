using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float Speed = 1f;
    private Rigidbody2D rbody;
    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        //if()
        var input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Debug.Log(input);
        //rbody.AddForce(input);
        rbody.MovePosition(input);
    }
}
