using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static UnityAction KillPlayer;
    [SerializeField] float maxHealth = 10;
    [SerializeField] GameObject deathObject;
    [SerializeField] float maxY;
    [SerializeField] float spawnDelay;
    [SerializeField] AudioTrigger deathScream;
    [SerializeField] AudioSource fXSource;
    float _currentHealth;
    public float health => _currentHealth;
    bool hasDied = false;

    void Start() => _currentHealth = maxHealth;

    void OnEnable()
    {
        KillPlayer += Death;
        if (fXSource == null)
            fXSource = GameObject.FindWithTag("PlayerFXSource").GetComponent<AudioSource>();
    }

    void OnDisable()
    {
        StopAllCoroutines();
        KillPlayer -= Death;
    }

    void Update()
    {
        if (transform.position.y < maxY)
        {
            GameManager.S.SpawnPlayer(spawnDelay);
            Destroy(gameObject);
        }
    }

    public void DamageHealth(float amount)
    {
        _currentHealth -= amount;

        if (_currentHealth <= 0)
            Death();
    }

    public void SetMaxHealth(float newValue) => maxHealth = newValue;

    public void Death()
    {
        if (!hasDied)
        {
            hasDied = true;
            CameraFollow.S.NullTarget();
            DialogManager.S.ClearDialog();
            GameManager.S.ShowDeathScreen();
            DialogManager.S.StopDialog();
            if (deathScream != null && fXSource != null)
                deathScream.Trigger(fXSource);
            Instantiate(deathObject, transform.position, Quaternion.identity);
            GameManager.S.SpawnPlayer(spawnDelay);
            Destroy(gameObject);
        }
    }

    void RestartLevel() => SceneManager.LoadScene("Body");
}