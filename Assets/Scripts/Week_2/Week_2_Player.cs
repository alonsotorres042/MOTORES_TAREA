using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Week_2_Player : MonoBehaviour
{
    //MOVEMENT
    Vector3 Speed;
    public float Velocity;

    //JUMP
    public float Thurst;
    Vector3 JumpDirection;
    Rigidbody MyRB;
    int Extrajumps;
    public bool IsJumping = false;

    //RAYCAST
    RaycastHit hit;
    float RaycastLenght;
    public LayerMask Layers;

    // Start is called before the first frame update
    void Start()
    {
        Velocity = 0.2f;
        MyRB = GetComponent<Rigidbody>();

        RaycastLenght = 0.5f;
        Extrajumps = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        transform.position = transform.position + Speed * Velocity;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, RaycastLenght, Layers))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.red);
            Debug.Log("Did Hit");
            IsJumping = false;
            Extrajumps = 2;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * RaycastLenght, Color.white);
            Debug.Log("Did not Hit");
            IsJumping = true;
        }
    }
    public void Movement(InputAction.CallbackContext context)
    {
        Speed = context.ReadValue<Vector2>();
    }
    public void Jump(InputAction.CallbackContext context)
    {
        JumpDirection = context.ReadValue<Vector3>();
        if (context.performed && IsJumping == true && Extrajumps > 0)
        {
            MyRB.AddForce(JumpDirection * Thurst);
            Extrajumps--;
        }
        else if(context.performed && IsJumping == false && Extrajumps > 0)
        {
            MyRB.AddForce(JumpDirection * Thurst);
        }
    }
}