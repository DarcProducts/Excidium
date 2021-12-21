using UnityEngine;

public class LiquidAcidSpawner : MonoBehaviour
{
    [SerializeField] ObjectPool acidPool;
    [SerializeField] Vector2 acidDropSize;
    [SerializeField] Sprite[] acidSpawnSprites;
    [SerializeField] Vector2 spawnTime = Vector2.one * 2;
    [SerializeField] float fallRate;
    [SerializeField] SpriteRenderer acidDripRenderer;
    float finalSpawnTime;
    float currentTime;

    void OnEnable()
    {
        finalSpawnTime = GetRandomSpawnTime();
        currentTime = 0;
    }

    void FixedUpdate()
    {
        currentTime += Time.fixedDeltaTime;
        acidDripRenderer.sprite = acidSpawnSprites[Mathf.Clamp((int) currentTime,(int) 0,(int) acidSpawnSprites.Length - 1)];
        if (currentTime > finalSpawnTime)
        {
            CreateBubbleOfAcid();
            currentTime = 0;
            finalSpawnTime = GetRandomSpawnTime();
        }
    }

    float GetRandomSpawnTime() => Random.Range(Mathf.Min(spawnTime.x, spawnTime.y), Mathf.Max(spawnTime.x, spawnTime.y));

    void CreateBubbleOfAcid()

    {
        GameObject acid = acidPool.GetObject();
        acid.transform.position = transform.position;
        float randSize = Random.Range(Mathf.Min(acidDropSize.x, acidDropSize.y), Mathf.Max(acidDropSize.x, acidDropSize.y));
        acid.transform.localScale = Vector2.one * randSize;
        acid.SetActive(true);
        Rigidbody2D aRB = acid.GetComponent<Rigidbody2D>();
        aRB.gravityScale = fallRate;
    }
}
