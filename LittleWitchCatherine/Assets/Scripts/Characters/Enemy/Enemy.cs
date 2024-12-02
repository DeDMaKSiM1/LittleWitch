using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float BaseSpeed = 0.25f;
    private Rigidbody2D rbody;
    private Animator animator;
    private Vector2 movement;


    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        StartCoroutine(MovementCoroutine());
    }


    private IEnumerator MovementCoroutine()
    {
        while (true)
        {
            int directionX = Random.Range(-1, 2);
            int directiony = Random.Range(-1, 2);
            movement = new Vector2(directionX, directiony);
            rbody.MovePosition(rbody.position + movement * BaseSpeed);
            Debug.Log(movement * BaseSpeed);

            yield return new WaitForSeconds(1f);
        }
    }

}
