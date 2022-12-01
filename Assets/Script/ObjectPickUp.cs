using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Pick Up Data")]
public class ObjectPickUp : ScriptableObject
{
    public bool isPickedUp;
    public bool isPickMagicItem;
    public string nameObject;
    public Text textJutsu;
}
