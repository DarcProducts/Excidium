using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float maxHealth = 10;
    [SerializeField] UnityEvent<GameObject> OnDied;
    [SerializeField] GameObject deathObject;
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

    public void SpawnDeathObject(GameObject location)
    {
        GameObject d = Instantiate(deathObject, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Acid"))
            SpawnDeathObject(gameObject);
    }
}