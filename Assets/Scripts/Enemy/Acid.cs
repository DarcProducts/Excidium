using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Acid : MonoBehaviour
{
    [SerializeField] ObjectPool acidDummyPool;
    [SerializeField] Vector2 amountToSpawn;
    [SerializeField] Vector2 minMaxSize;
    [SerializeField] Vector2 acidDuration;
    [SerializeField] float maxYValue = -10;
    public static UnityAction Splatter;
    public GameObject launchedFrom;
    Rigidbody2D rb;
    void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
        acidDummyPool = GameObject.FindGameObjectWithTag("AcidDummyPool").GetComponent<ObjectPool>();
    }

    void Update()
    {
        if (transform.position.y < maxYValue)
            gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (launchedFrom != null) 
            if (other.gameObject == launchedFrom) 
                return;
        Splatter?.Invoke();
        Vector2 currentVelocity = rb.velocity;
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth.KillPlayer?.Invoke();
            return;
        }
        int amount = Random.Range(Mathf.CeilToInt(amountToSpawn.x), Mathf.CeilToInt(amountToSpawn.y));
        for (int i = 0; i < amount; i++)
        {
            GameObject a = acidDummyPool.GetObject();
            AcidDummy aD = a.GetComponent<AcidDummy>();
                if (aD != null)
                    aD.duration = acidDuration;
            a.transform.position = transform.position;
            a.SetActive(true);
            a.GetComponent<Rigidbody2D>().AddForce(currentVelocity + new Vector2(-.5f, .5f), ForceMode2D.Impulse);
            a.transform.localScale = Vector3.one * Random.Range(minMaxSize.x, minMaxSize.y);
            gameObject.SetActive(false);
        }
    }
}


