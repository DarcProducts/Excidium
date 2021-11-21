using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Variables/New Global Vector 2")]
public class GlobalVector2 : ScriptableObject
{
    public UnityAction<Vector2> OnValueChanged;
    [SerializeField] Vector2 value;
    [SerializeField] bool broadcastValueChange;
    [SerializeField] bool reset;
    [SerializeField] Vector2 resetValue;

    void OnDisable()
    {
        if (reset)
            this.value = resetValue;
    }

    public Vector2 Value
    {
        get => value;
        set
        {
            this.value = value;
            if (broadcastValueChange)
                OnValueChanged?.Invoke(this.value);
        }
    }
}
