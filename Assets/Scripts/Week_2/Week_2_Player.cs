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

    //CHAGGE COLOR MECHANIC
    MeshRenderer MyMR;
    public ColorData ColorData;

    //GENERAL DATA
    float life;

    // Start is called before the first frame update
    void Start()
    {
        Velocity = 0.2f;
        MyRB = GetComponent<Rigidbody>();
        MyMR = GetComponent<MeshRenderer>();

        RaycastLenght = 0.5f;
        Extrajumps = 2;

        life = 10;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = transform.position + Speed * Velocity;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, RaycastLenght, Layers))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.red);
            IsJumping = false;
            Extrajumps = 2;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * RaycastLenght, Color.white);
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
    public void ChageToRed()
    {
        MyMR.material = ColorData.Red;
    }
    public void ChageToBlue()
    {
        MyMR.material = ColorData.Blue;
    }
    public void ChageToGreen()
    {
        MyMR.material = ColorData.Green;
    }
}