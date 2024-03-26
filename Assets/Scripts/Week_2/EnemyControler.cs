using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    public string Axis;
    public float Speed;
    private Vector3 Velocity;
    public float TimeToMove;
    public string ThisColor;
    // Start is called before the first frame update
    void Start()
    {
        if (Axis == "Horizontal")
        {
            Velocity = new Vector3(1,0,0);
        }
        else if (Axis == "Vertical")
        {
            Velocity = new Vector3(0, 1, 0);
        }
        StartCoroutine(Movement());
    }
    void FixedUpdate()
    {
        transform.position = transform.position + Velocity * Speed;
    }
    public IEnumerator Movement()
    {
        while(true)
        {
            yield return new WaitForSeconds(TimeToMove);
            Velocity = Velocity * -1;
        }
    }
}