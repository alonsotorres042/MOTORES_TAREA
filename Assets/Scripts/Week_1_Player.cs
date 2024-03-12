using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Week_1_Player : MonoBehaviour
{
    private Vector3 Speed = Vector3.zero;
    public int Velocity = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Speed * Velocity;
    }
    /*void Movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Speed.x = -1;
        }else if (Input.GetKey(KeyCode.D))
        {
            Speed.x = 1;
        }else if (Input.GetKey(KeyCode.W))
        {
            Speed.y = 1;
        }else if(Input.GetKey(KeyCode.S))
        {
            Speed.y = -1;
        }
        else
        {
            Speed = Vector2.zero;
        }
        transform.position = (Speed * Velocity) + transform.position;
    }*/

    public void Movement(InputAction.CallbackContext context)
    {
        Speed = context.ReadValue<Vector3>();
        Debug.Log(Speed);
    }
}