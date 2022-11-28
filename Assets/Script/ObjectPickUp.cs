using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pick Up Data")]
public class ObjectPickUp : ScriptableObject
{
    public bool isPickedUp;
    public string nameObject;
}
