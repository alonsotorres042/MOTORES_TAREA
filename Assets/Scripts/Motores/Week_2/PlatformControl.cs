using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControl : MonoBehaviour
{
    public string ThisColor;
    void Start()
    {
        StartCoroutine(RecoverCollision());
    }
    public IEnumerator RecoverCollision()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            this.gameObject.layer = 7;
        }
    }
}