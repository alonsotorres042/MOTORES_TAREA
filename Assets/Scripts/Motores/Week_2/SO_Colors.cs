using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorData", menuName = "ScriptableObjects/Data", order = 1)]
public class ColorData : ScriptableObject
{
    public Material Red;
    public Material Green;
    public Material Blue;
}
