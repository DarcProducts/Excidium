using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour, ICauseDamage
{
    [SerializeField] float damage;
    [Range(0f, 1f)] [SerializeField] float camaraShakeIntensity;
    
    public float GetDamage() 
    {
        CameraShaker.S.Trigger(camaraShakeIntensity);
        return damage;
    }
}
