using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = ("Variables/New Dialog String"))]
public class DialogString : ScriptableObject
{
    public string dialog;
    public float displayLength = 1.5f;
    public bool hasBeenRead = false;
}
