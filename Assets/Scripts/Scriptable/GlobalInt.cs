using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Variables/New Global Int")]
public class GlobalInt : ScriptableObject
{
    [SerializeField] int currentValue = 0;
    [SerializeField] bool broadcastOnValueChange = false;
    [SerializeField] bool reset;
    [SerializeField] int resetValue;
    public UnityAction<int> OnValueChanged;

    void OnDisable()
    {
        if (reset)
            currentValue = resetValue;
    }

    public int Value
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