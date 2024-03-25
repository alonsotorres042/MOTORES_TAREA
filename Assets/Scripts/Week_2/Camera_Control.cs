using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour
{
    public Week_2_Player PLayer;
    void FixedUpdate()
    {
        if(PLayer.transform.position.x >= 8.32f)
        {
            Level2();
        }
        else
        {
            Level1();
        }
    }
    public void Level1()
    {
        transform.position = new Vector3(0, 1, -10);
    }
    public void Level2()
    {
        transform.position = new Vector3(16.91f, 1, -10);
    }
}
