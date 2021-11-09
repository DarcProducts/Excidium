using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Variables/New Global Bool")]
public class GlobalBool : ScriptableObject
{
    [SerializeField] bool currentValue = false;
    [SerializeField] bool broadcastOnValueChange = true;
    [SerializeField] bool reset;
    [SerializeField] bool resetValue;
    public UnityAction<bool> OnValueChanged;

    void OnDisable()
    {
        if (reset)
            currentValue = resetValue;
    }


    public bool Value
    {
        get { return currentValue; }
        set
        {
            currentValue = value;
            if (broadcastOnValueChange)
                OnValueChanged?.Invoke(currentValue);
        }
    }
}
