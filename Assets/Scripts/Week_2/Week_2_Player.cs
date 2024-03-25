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
    public string CurrentColor;

    //GENERAL DATA
    float life;

    // Start is called before the first frame update
    void Start()
    {
        Velocity = 0.1f;
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
            RaycastLenght = 0.5f;
            if(hit.transform.gameObject.tag == "Platform" && hit.transform.gameObject.GetComponent<PlatformControl>().ThisColor == CurrentColor)
            {
                hit.transform.gameObject.layer = 8;
            }
            if (hit.transform.gameObject.layer != 8)
            {
                Extrajumps = 2;
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * RaycastLenght, Color.white);
            IsJumping = true;
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            if (collision.gameObject.GetComponent<PlatformControl>().ThisColor == CurrentColor)
            {
                collision.gameObject.layer = 8;
            }
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
            RaycastLenght = 1;
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
        CurrentColor = "Red";
    }
    public void ChageToBlue()
    {
        MyMR.material = ColorData.Blue;
        CurrentColor = "Blue";
    }
    public void ChageToGreen()
    {
        MyMR.material = ColorData.Green;
        CurrentColor = "Green";
    }
}