using System.Timers;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f; 
    [SerializeField] float xClamp = 3f; 
    [SerializeField] float zClamp = 2f; 

    Vector2 movement;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector3 currentPosition = rb.position;
        Vector3 moveDirection = new Vector3(movement.x,  0f, movement.y);
        Vector3 newPostion = currentPosition + moveDirection * (moveSpeed * Time.fixedDeltaTime);

        newPostion.x = Mathf.Clamp(newPostion.x, -xClamp, xClamp);
        newPostion.z = Mathf.Clamp(newPostion.z, - zClamp, zClamp);


        rb.MovePosition(newPostion);
    }
}
