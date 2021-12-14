using System.Globalization;
using UnityEngine;

public class PussSack : MonoBehaviour, ICauseDamage
{
    [SerializeField] float duration;
    float currentDuration;
    SpriteRenderer sRend;
    [SerializeField] float touchedDamage;
    [SerializeField] Sprite startSprite;
    [SerializeField] Sprite fillingSprite1;
    [SerializeField] Sprite fillingSprite2;
    [SerializeField] Sprite openSprite;
    [SerializeField] ObjectPool pussPool;
    [SerializeField] float pussForce;
    [SerializeField] Vector2 pussDirection;
    [SerializeField] Vector2 pussSize;
    [Range(0f, 1f)] [SerializeField] float hitMagnitude;


    void Awake() => sRend = GetComponent<SpriteRenderer>();

    void Start() => currentDuration = duration;

    void FixedUpdate()
    {
        currentDuration = currentDuration < 0 ? 0 : currentDuration -= Time.fixedDeltaTime;

        if (currentDuration > duration / 1.5f)
            sRend.sprite = startSprite;
        else if ((currentDuration < duration / 1.5f && currentDuration > duration / 4))
            sRend.sprite = fillingSprite1;
        else if ((currentDuration < duration / 4 && currentDuration > duration / 6))
            sRend.sprite = fillingSprite2;
        else if (currentDuration < duration / 6)
            sRend.sprite = openSprite;

        if (currentDuration.Equals(0))
        {
            GameObject p = pussPool.GetObject();
            float pSize = Random.Range(Mathf.Min(pussSize.x, pussSize.y), Mathf.Max(pussSize.x, pussSize.y));
            p.transform.localScale = Vector3.one * pSize;
            Acid a = p.GetComponent<Acid>();
            float rotDir = Random.Range(-Mathf.Abs(pussDirection.x), Mathf.Abs(pussDirection.x));
            if (a != null)
                a.launchedFrom = this.gameObject;
            p.transform.position = transform.position;
            p.SetActive(true);
            Rigidbody2D pRB = p.GetComponent<Rigidbody2D>();
            if (pRB != null)
            {
                pRB.AddForce(pussForce * pussDirection, ForceMode2D.Impulse);
                pRB.AddTorque(rotDir * Mathf.Pow(pussForce, 2));
            }
            currentDuration = duration;
        }
    }

    public float GetDamage()
    {
       CameraShaker.S.Trigger(hitMagnitude);
       return touchedDamage;
    }
}
