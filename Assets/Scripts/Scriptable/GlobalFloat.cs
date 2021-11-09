using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Variables/New Global Float")]
public class GlobalFloat : ScriptableObject
{
    [SerializeField] float currentValue = 0;
    [SerializeField] bool broadcastOnValueChange = true;
    [SerializeField] bool reset;
    [SerializeField] float resetValue;
    public UnityAction<float> OnValueChanged;

    void OnDisable()
    {
        if (reset)
            currentValue = resetValue;
    }


    public float Value
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
