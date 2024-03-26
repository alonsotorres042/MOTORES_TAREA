using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Week_1_Player : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private Vector3 Speed;
    public float Velocity;

    RaycastHit hit;
    int RayDistance;
    public LayerMask Layers;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        RayDistance = 200;
        Speed = Vector3.zero;
        Velocity = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Speed * Velocity;
    }
    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, Speed, out hit, RayDistance, Layers))
        {
            Debug.DrawRay(transform.position, Speed * RayDistance, Color.yellow);
            if (hit.transform.tag == "Shape")
            {
                Debug.Log(hit.transform.gameObject.name + ", " + hit.transform.position + ", " + hit.transform.tag + ", Sprite");
            }else if (hit.transform.tag == "Color")
            {
                Debug.Log(hit.transform.gameObject.name + ", " + hit.transform.position + ", " + hit.transform.tag + ", Color");
            }
        }
        else
        {
            Debug.DrawRay(transform.position, Speed * RayDistance, Color.white);
        }
    }
    public void Movement(InputAction.CallbackContext context)
    {
        Speed = context.ReadValue<Vector3>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Shape")
        {
            _spriteRenderer.sprite = collision.transform.GetComponent<SpriteRenderer>().sprite;
        }else if(collision.transform.tag == "Color")
        {
            _spriteRenderer.color = collision.transform.GetComponent<SpriteRenderer>().color;
        }
    }
}