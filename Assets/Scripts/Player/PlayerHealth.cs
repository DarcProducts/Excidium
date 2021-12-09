using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static UnityAction KillPlayer;
    [SerializeField] float immuneDuration;
    [SerializeField] Color onHitColor = Color.red;
    [Range(0f, 1f)] [SerializeField] float hitBlinkTime = .2f;
    [SerializeField] float maxHealth = 10;
    [SerializeField] GameObject deathObject;
    [SerializeField] GameObject leftEye, rightEye;
    [SerializeField] GameObject midBody;
    [SerializeField] GameObject tail;
    [SerializeField] float playerSpawnDelay = 3f;
    [SerializeField] UnityEvent<GameObject> OnDied;
    bool isImmune = false;
    float _currentHealth;
    public float health => _currentHealth;
    SpriteRenderer sRend;
    bool spawnedPlayer = false;
    bool hasDied = false;

    Color originalColor = Color.white;
    SpriteRenderer midRend, tailRend, lEyeRend, rEyeRend;

    void Awake()
    {
        sRend = GetComponent<SpriteRenderer>();
        midRend = midBody.GetComponent<SpriteRenderer>();
        tailRend = tail.GetComponent<SpriteRenderer>();
        lEyeRend = leftEye.gameObject.GetComponent<SpriteRenderer>();
        rEyeRend = rightEye.gameObject.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
         _currentHealth = maxHealth;
        originalColor = sRend.color;
    }

    void OnEnable() => KillPlayer += Death;

    void OnDisable() => KillPlayer -= Death;

    public void DamageHealth(float amount)
    {
        if (!isImmune)
        {
            _currentHealth -= amount;

        if (_currentHealth < maxHealth / 8)
            {
                if (Random.value > .5f)
                    leftEye.SetActive(false);
                else
                    rightEye.SetActive(false);
            }
            
        if (_currentHealth <= 0)
            Death();
        }
    }

    public void SetMaxHealth(float newValue) => maxHealth = newValue;

    public void Death()
    {
        if (!hasDied)
        {
            hasDied = true;
            Instantiate(deathObject, transform.position, Quaternion.identity);
        }
        Collider2D playerCol = GetComponent<Collider2D>();
        playerCol.enabled = false;
        sRend.enabled = false;
        leftEye.SetActive(false);
        rightEye.SetActive(false);
        midBody.SetActive(false);
        tail.SetActive(false);
        CameraFollow.S.NullTarget();
        if (!spawnedPlayer)
        {
            spawnedPlayer = true;
            StartCoroutine(nameof(SpawnPlayer));
        }
    }

    IEnumerator SpawnPlayer()
    {
        yield return new WaitForSeconds(playerSpawnDelay);
        GameManager.S.SpawnNewPlayer(PlayerRigidMovement.currentSpawnLocation);
        hasDied = false;
        spawnedPlayer = false;
    }

    void ResetGame() => SceneManager.LoadScene("Body");

    void OnCollisionEnter2D(Collision2D other) {
        ICauseDamage damage = other.gameObject.GetComponent<ICauseDamage>();
        if (damage != null)
        {
            DamageHealth(damage.GetDamage());
            if (!isImmune)
            {
                isImmune = true;
                if (gameObject.activeInHierarchy)
                    StartCoroutine(nameof(WasHit));
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        ICauseDamage damage = other.GetComponent<ICauseDamage>();
        if (damage != null)
        {
            DamageHealth(damage.GetDamage());
            if (!isImmune)
            {
                isImmune = true;
                if (gameObject.activeInHierarchy)
                    StartCoroutine(nameof(WasHit));
            }
        }
    }

    IEnumerator WasHit()
    {
        StartCoroutine(nameof(FadeToTransparent));
        sRend.color = onHitColor;
        yield return new WaitForSeconds(immuneDuration);
        sRend.color = originalColor;
        isImmune = false;
    }

    IEnumerator FadeToTransparent()
    {
        SetRendsFalse();        
        yield return new WaitForSeconds(hitBlinkTime);
        SetRendsTrue();
    }

    void SetRendsTrue()
    {
        sRend.enabled = true;
        midRend.enabled = true;
        tailRend.enabled = true;
        lEyeRend.enabled = true;
        rEyeRend.enabled = true;
    }

    void SetRendsFalse()
    {
        sRend.enabled = false;
        midRend.enabled = false;
        tailRend.enabled = false;
        lEyeRend.enabled = false;
        rEyeRend.enabled = false;
    }
}