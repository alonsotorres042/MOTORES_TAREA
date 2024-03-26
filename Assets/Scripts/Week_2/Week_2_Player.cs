using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEditor.UI;

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
    public bool CanChangeColor;

    //GENERAL DATA
    int Level;
    float MaxLife;
    public float CurrentLife;

    //TIMER
    public Timer ThisTimer;
    public UIManager MyUIManager;

    // Start is called before the first frame update
    void Start()
    {
        Velocity = 0.1f;
        MyRB = GetComponent<Rigidbody>();
        MyMR = GetComponent<MeshRenderer>();
        CanChangeColor = true;

        RaycastLenght = 0.5f;
        Extrajumps = 2;

        MaxLife = 10;
        CurrentLife = MaxLife;
        Level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentLife <= 0)
        {
            DEATH();
        }
    }
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
        if(collision.gameObject.tag == "Enemy" && collision.gameObject.GetComponent<EnemyControler>().ThisColor != CurrentColor)
        {
            CurrentLife--;
        }
        else if(collision.gameObject.tag == "Enemy" && collision.gameObject.GetComponent<EnemyControler>().ThisColor == CurrentColor)
        {
            CanChangeColor = false;
        }
        if(collision.gameObject.tag == "FinishItem")
        {
            VICTORY();
            MyUIManager.VICTORY();
        }
    }
    void OnCollisionExit(Collision collision)
    {
        CanChangeColor = true;
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
            RaycastLenght = 0.5f;
            Extrajumps--;
        }
        else if(context.performed && IsJumping == false && Extrajumps > 0)
        {
            MyRB.AddForce(JumpDirection * Thurst);
        }
    }
    public void ChageToRed()
    {
        if(CanChangeColor)
        {
            MyMR.material = ColorData.Red;
            CurrentColor = "Red";
        }
    }
    public void ChageToBlue()
    {
        if (CanChangeColor)
        {
            MyMR.material = ColorData.Blue;
            CurrentColor = "Blue";
        }
    }
    public void ChageToGreen()
    {
        if (CanChangeColor)
        {
            MyMR.material = ColorData.Green;
            CurrentColor = "Green";
        }
    }
    public void DEATH()
    {
        transform.position = new Vector2(-8.25f, -2.4f);
        CurrentLife = 10;
    }
    public void VICTORY()
    {
        ThisTimer.DetenerTemporizador();
    }
}