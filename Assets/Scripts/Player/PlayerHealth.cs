using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float maxHealth = 10;
    [SerializeField] UnityEvent<GameObject> OnDied;
    float _currentHealth;
    public float health => _currentHealth;

    void Start() => _currentHealth = maxHealth;

    public void DamageHealth(float amount)
    {
        _currentHealth -= amount;

        if (_currentHealth <= 0)
            OnDied?.Invoke(gameObject);
    }

    public void SetMaxHealth(float newValue) => maxHealth = newValue;
}